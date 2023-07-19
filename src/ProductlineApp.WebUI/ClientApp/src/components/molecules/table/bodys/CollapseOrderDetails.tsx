import './css/CollapseOrderDetails.css';
import { ShippingAddress } from '../../../../interfaces/orders/shippingAddress';
import { Address } from '../../../../interfaces/common/address';
import { OrderItem } from '../../../../interfaces/orders/orderItem';

export const CollapseOrderDetails = ({
  shippingAddress,
  address,
  items,
}: {
  shippingAddress: ShippingAddress;
  address: Address;
  items: OrderItem[];
}) => {
  return (
    <tr className="orderDetailsWrapper">
      <td></td>
      <td colSpan={2}>
        <div className="orderItems">
          <h1 className="orderItemsSectionLabel">Zamówione Produkty:</h1>
          <ul className="orderItemsList">
            {items.map((item) => (
              <li>
                <div className="orderItemDetails">
                  <img className="orderItemImage" src={item?.imageUrl} />
                  <h1>SKU:</h1>
                  <h2>{item.sku}</h2>
                  <h1>Cena:</h1>
                  <h2>{item.unitPrice} zł</h2>
                  <h1>Ilość:</h1>
                  <h2>{item.quantity}</h2>
                </div>
              </li>
            ))}
          </ul>
        </div>
      </td>
      <td></td>
      <td></td>
      <td></td>
      <td colSpan={3}>
        <div className="orderShipingAddress">
          <h1 className="orderShipingAddressSectionLabel">Dane zamawiającego:</h1>
          <ul className="orderShipingAddressData">
            <li>
              <h1>Imię i Nazwisko:</h1>
              <h2>{shippingAddress.firstName + ' ' + shippingAddress.lastName}</h2>
            </li>
            <li>
              {shippingAddress.phoneNumber !== null ? (
                <>
                  <h1>Numer telefonu:</h1>
                  <h2>{shippingAddress.phoneNumber}</h2>
                </>
              ) : (
                ''
              )}
            </li>
            <li>
              {address.city !== '' ? (
                <>
                  <h1>Miasto:</h1>
                  <h2>{address.city}</h2>
                </>
              ) : (
                ''
              )}
            </li>
            <li>
              {address.streetName !== '' ? (
                <>
                  <h1>Ulica:</h1>
                  <h2>{address.streetName}</h2>
                </>
              ) : (
                ''
              )}
            </li>
            <li>
              {address.streetNumber !== '' ? (
                <>
                  <h1>Numer domu:</h1>
                  <h2>{address.streetNumber}</h2>
                </>
              ) : (
                ''
              )}
            </li>
            <li>
              {address.zip !== '' ? (
                <>
                  <h1>Kod pocztowy:</h1>
                  <h2>{address.zip}</h2>
                </>
              ) : (
                ''
              )}
            </li>
            <li>
              {address.country !== '' ? (
                <>
                  <h1>Kraj:</h1>
                  <h2>{address.country}</h2>
                </>
              ) : (
                ''
              )}
            </li>
          </ul>
        </div>
      </td>
    </tr>
  );
};
