import { FormEvent, useState } from 'react';
import AddProductTemplate from '../components/templates/AddProductTemplate';
import { AddProductRequest } from '../interfaces/products/addProductRequest';
import { ProductForm } from '../interfaces/products/productForm';
import { useProductsService } from '../hooks/products/useProductsService';
import { useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { toast } from 'react-toastify';
import AddAuctionForm from '../components/organisms/forms/addAuctionForm/AddAuctionForm';
import { useOrdersService } from '../hooks/orders/useOrdersService';
import AddAuctionTemplate from '../components/templates/AddAuctionTemplate';
import { AuctionForm } from '../interfaces/auctions/auctionForm';

const allegroAuctionSchema = Yup.object().shape({
  name: Yup.string().required('Nazwa jest wymagana'),
  quantity: Yup.number().required('Ilość jest wymagana').positive('Ilość musi być dodatnia'),
  price: Yup.number().required('Cena jest wymagana').positive('Cena musi być dodatnia'),
  condition: Yup.string().required('Stan jest wymagany'),
  description: Yup.string().required('Opis jest wymagany'),
  photos: Yup.mixed()
    .nullable()
    .test('file', 'Wymagane co najmniej jedno zdjęcie', (value) => {
      return value instanceof FileList && value.length > 0;
    }),
});

export default function AddAuction() {
  const navigate = useNavigate();
  const [selectedPhotos, setSelectedPhotos] = useState<FileList | null>(null);
  const [photoPreviews, setPhotosPreviews] = useState<Array<string>>([]);

  const [auctionForm, setAuctionForm] = useState<AuctionForm>({
    sku: '',
    brand: '',
    name: '',
    condition: 0,
    quantity: 0,
    price: 0,
    description: '',
    photos: null,
    allegroProductIdea: 0,
  });
  const [errors, setErrors] = useState<Partial<AuctionForm>>({});

  const validateForm = async () => {
    try {
      await allegroAuctionSchema.validate(auctionForm, { abortEarly: false });
      setErrors({});
      return true;
    } catch (validationErrors: any) {
      const errors: Partial<AuctionForm> = {};
      validationErrors.inner.forEach((error: any) => {
        errors[error.path as keyof AuctionForm] = error.message;
      });
      setErrors(errors);
      return false;
    }
  };

  return (
    <AddAuctionTemplate
      uploadProductPhotos={undefined}
      photos={[]}
      onSubmit={function (event: FormEvent<HTMLFormElement>): void {
        throw new Error('Function not implemented.');
      }}
      auctionForm={auctionForm}
      onChange={function (name: string, value: string | number): void {
        throw new Error('Function not implemented.');
      }}
      errors={undefined}
      productsSKURecords={[]}
    />
  );
}
