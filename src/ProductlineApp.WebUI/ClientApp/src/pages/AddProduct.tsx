import { useState } from 'react';
import AddProductTemplate from '../components/templates/AddProductTemplate';
import { AddProductRequest } from '../interfaces/products/addProductRequest';
import { PhotoFile, ProductForm } from '../interfaces/products/productForm';
import { useProductsService } from '../hooks/products/useProductsService';
import { useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { toast } from 'react-toastify';
import { TabTitle } from '../helpers/changePageTitle';

const productSchema = Yup.object().shape({
  sku: Yup.string().required('SKU jest wymagane'),
  name: Yup.string().required('Nazwa jest wymagana'),
  brand: Yup.string().required('Marka jest wymagana'),
  quantity: Yup.number().required('Ilość jest wymagana').positive('Ilość musi być dodatnia'),
  price: Yup.number().required('Cena jest wymagana').positive('Cena musi być dodatnia'),
  category: Yup.string().required('Kategoria jest wymagana'),
  condition: Yup.string().required('Stan jest wymagany'),
  description: Yup.string().required('Opis jest wymagany'),
  photos: Yup.mixed()
    .nullable()
    .test('file', 'Wymagane co najmniej jedno zdjęcie', (value) => {
      return (value as Array<PhotoFile>).length > 0;
    }),
});

export default function AddProduct() {

  TabTitle("productline. Dodaj Produkt")

  const { productsService } = useProductsService();
  const navigate = useNavigate();
  const [productForm, setProductForm] = useState<ProductForm>({
    sku: '',
    name: '',
    brand: '',
    quantity: 0,
    price: 0,
    category: '',
    condition: 0,
    description: '',
    photos: [],
  });
  const [errors, setErrors] = useState<Partial<ProductForm>>({});

  const validateForm = async () => {
    try {
      await productSchema.validate(productForm, { abortEarly: false });
      setErrors({});
      return true;
    } catch (validationErrors: any) {
      const errors: Partial<ProductForm> = {};
      validationErrors.inner.forEach((error: any) => {
        errors[error.path as keyof ProductForm] = error.message;
      });
      setErrors(errors);
      return false;
    }
  };

  const selectImages = (event: React.ChangeEvent<HTMLInputElement>) => {
    const photos: PhotoFile[] = [];
    const files = event.target.files;

    if (files) {
      for (let i = 0; i < files.length; i++) {
        photos.push({
          id: i,
          url: URL.createObjectURL(files[i]),
          file: files[i],
        });
      }

      setProductForm((prevData) => ({
        ...prevData,
        photos: [...prevData.photos, ...photos],
      }));
    }
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>): Promise<void> => {
    event.preventDefault();

    const isValid: boolean = await validateForm();

    if (!isValid) {
      toast.error('Formularz zawiera błędy', {
        position: toast.POSITION.TOP_RIGHT,
      });
      return;
    }

    const photos = productForm.photos;

    const newProductRequestData: AddProductRequest = {
      sku: productForm.sku,
      name: productForm.name,
      categoryName: productForm.category,
      price: productForm.price,
      quantity: productForm.quantity,
      brandName: productForm.brand,
      description: productForm.description,
      condition: productForm.condition,
      image: photos[0].file,
    };

    try {
      const productResponse = await productsService.addProduct(newProductRequestData);

      const addImageRequestPool: Promise<void>[] = [];

      for (let i = 0; i < photos.length; i++) {
        const photo = photos[i];
        const addImageToGalleryFormData: FormData = new FormData();
        addImageToGalleryFormData.append('image', photo.file);
        const request = productsService.addImageToGallery(
          productResponse.productId,
          addImageToGalleryFormData,
        );
        addImageRequestPool.push(request);
      }

      await Promise.all(addImageRequestPool);

      toast.success('Pomyślnie dodano produkt', {
        position: toast.POSITION.TOP_RIGHT,
      });
      navigate('/products');
    } catch (err: any) {
      toast.error('Wystąpił błąd przy dodawaniu produktu', {
        position: toast.POSITION.TOP_RIGHT,
      });
    }
  };

  const handleChange = (name: string, value: number | string) => {
    setProductForm((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleMovePhoto = (dragIndex: number, hoverIndex: number) => {
    const newOrder = [...productForm.photos];
    const draggedPhoto = newOrder[dragIndex];
    newOrder.splice(dragIndex, 1);
    newOrder.splice(hoverIndex, 0, draggedPhoto);
    setProductForm((prevData) => ({
      ...prevData,
      photos: newOrder,
    }));
  };

  const handleDeletePhoto = (index: number) => {
    const updatedPhotos = [...productForm.photos];
    updatedPhotos.splice(index, 1);
    setProductForm((prevData) => ({
      ...prevData,
      photos: updatedPhotos,
    }));
  };

  return (
    <>
      <title>Dodaj Produkt</title>
      <AddProductTemplate
        uploadProductPhotos={selectImages}
        photos={productForm.photos.map((x) => x.url)}
        onSubmit={handleSubmit}
        productForm={productForm}
        onChange={handleChange}
        errors={errors}
        onPhotoMove={handleMovePhoto}
        onPhotoDelete={handleDeletePhoto} /></>
  );
}
