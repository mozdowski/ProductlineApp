import { useEffect, useState } from 'react';
import OrdersTemplate from '../components/templates/OrdersTemplate';
import { OrdersRecord } from '../interfaces/orders/OrdersPageInteface';
import { useOrdersService } from '../hooks/orders/useOrdersService';
import { mapOrderStatusToString } from '../helpers/mappers';
import { toast } from 'react-toastify';
import { useConfirmationPopup } from '../hooks/popups/useConfirmationPopup';
import { usePopup } from '../hooks/popups/usePopup';
import DropFileInput from '../components/atoms/inputs/dropFileInput/DropFileInput';
import { OrderDocument } from '../interfaces/orders/orderDocumentsResponse';
import JSZip from 'jszip';
import { saveAs } from 'file-saver';

export default function Orders() {
  const [showCompletedOrders, setShowCompletedOrders] = useState<boolean>(false);
  const [searchValue, setSearchValue] = useState('');
  const [orders, setOrders] = useState<OrdersRecord[] | undefined>(undefined);
  const { ordersService } = useOrdersService();
  const [refreshRecords, setRefreshRecords] = useState<boolean>(false);
  const { showConfirmation } = useConfirmationPopup();
  const { openPopup, hidePopup } = usePopup();

  useEffect(() => {
    setOrders(undefined);
    ordersService.getOrdersList().then((res) => {
      const orderRecords: OrdersRecord[] = res.orders.map((order) => ({
        orderID: order.orderId,
        orderDate: new Date(order.creationDate),
        shipToDate: new Date(order.maxDeliveryDate as Date),
        client: order.billingAddress.firstName + ' ' + order.billingAddress.lastName,
        price: order.totalPrice,
        quantity: order.quantity,
        statusText: mapOrderStatusToString(order.status),
        status: order.status,
        shippingAddress: order.shippingAddress,
        items: order.items,
      }));
      setOrders(orderRecords);
    });
  }, [refreshRecords]);

  const handleClickTypeOrdersButton = (showCompleted: boolean) => {
    setShowCompletedOrders(showCompleted);
    setRefreshRecords(!refreshRecords);
  };

  const searchTableOrders = (e: { target: { value: React.SetStateAction<string> } }) => {
    setSearchValue(e.target.value);
  };

  const handleMarkOrderAsCompleted = async (orderId: string) => {
    await handleMarkOrderAsCompletedConfirmationPopup(orderId);
  };

  const handleMarkOrderAsCompletedConfirmationPopup = async (orderId: string) => {
    const confirmationText = 'Czy na pewno chcesz oznaczyć zamówienie jako zrealizowane?';
    showConfirmation(confirmationText, async () => await markOrderAsCompleted(orderId));
  };

  const markOrderAsCompleted = async (orderId: string) => {
    try {
      const res = await ordersService.markOrderAsCompleted(orderId);
      toast.success('Zamówienie zrealizowane');
    } catch {
      toast.error('Błąd podczas zamykania zamówiena');
    }
    setShowCompletedOrders(false);
  };

  const searchOrders = orders
    ? orders.filter((order) => {
        return (
          order.orderID.toLowerCase().indexOf(searchValue) >= 0 ||
          order.orderDate.getDate().toString().indexOf(searchValue) >= 0 ||
          order.shipToDate.getDate().toString().indexOf(searchValue) >= 0 ||
          order.client.toLowerCase().indexOf(searchValue) >= 0 ||
          order.price.toString().toLowerCase().indexOf(searchValue) >= 0 ||
          order.quantity.toString().toLowerCase().indexOf(searchValue) >= 0 ||
          order.statusText.indexOf(searchValue) >= 0
        );
      })
    : undefined;

  const handleOpenOrderFilesPopup = async (orderId: string) => {
    const documents = await getOrderDocuments(orderId);
    if (!documents) return;

    openPopup(
      <DropFileInput
        onFilesSubmit={(serverFiles: string[], uploadedFileList: File[]) =>
          handleSubmitOrderFiles(orderId, serverFiles, uploadedFileList)
        }
        orderDocuments={documents}
      />,
    );
  };

  const getOrderDocuments = async (orderId: string): Promise<OrderDocument[] | undefined> => {
    try {
      const documentsResponse = await ordersService.getOrderDocuments(orderId);
      return documentsResponse.orderDocuments;
    } catch {
      toast.error('Błąd przy pobieraniu dokumentów');
    }
  };

  const handleSubmitOrderFiles = async (
    orderId: string,
    serverFiles: string[],
    uploadedFileList: File[],
  ) => {
    try {
      const updateDocumentsPromisesPool = Promise.all([
        ...uploadedFileList.map((x) => {
          const data: FormData = new FormData();
          data.append('document', x);

          return ordersService.attachDocumentToOrder(orderId, data);
        }),
        ordersService.updateOrderDocuments(orderId, {
          documentIds: serverFiles,
        }),
      ]);

      await toast.promise(updateDocumentsPromisesPool, {
        pending: 'Trwa aktualizowanie dokumentów...',
        success: `Pomyślnie zaktualizowano dokumenty dla zamówienia ${orderId}`,
        error: 'Błąd podczas aktualizowania dokumentów',
      });
    } catch {
      toast.error('Błąd podczas aktualizowania dokumentów');
    }

    hidePopup();
  };

  const handleFilesDownload = async (orderId: string) => {
    const documents = await getOrderDocuments(orderId);
    if (!documents) return;

    const zip = new JSZip();

    for (const doc of documents) {
      const response = await fetch(doc.url);
      const blob = await response.blob();
      zip.file(doc.name, blob);
    }

    const content = await zip.generateAsync({ type: 'blob' });
    saveAs(content, `order-${orderId}-documents.zip`);
  };

  return (
    <OrdersTemplate
      orderRecords={searchOrders}
      handleClickTypeOrdersButton={handleClickTypeOrdersButton}
      searchValue={searchValue}
      onChange={searchTableOrders}
      showCompletedOrders={showCompletedOrders}
      markOrderAsCompleted={handleMarkOrderAsCompleted}
      onOpenOrderFilesPopup={handleOpenOrderFilesPopup}
      onFilesDownload={handleFilesDownload}
    />
  );
}
