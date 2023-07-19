import { useEffect, useState } from 'react';
import { AddProductRequest } from '../interfaces/products/addProductRequest';
import { ProductForm } from '../interfaces/products/productForm';
import { useProductsService } from '../hooks/products/useProductsService';
import { useNavigate, useParams } from 'react-router-dom';
import * as Yup from 'yup';
import { toast } from 'react-toastify';
import EditProductTemplate from '../components/templates/EditProductTemplate';
import { ProductsRecord } from '../interfaces/products/ProductsPageInteface';
import { ProductData } from '../interfaces/products/getProductsSKU';
import { ProductDtoResponse } from '../interfaces/products/getProductsResponse';

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
      return value instanceof FileList && value.length > 0;
    }),
});

export default function EditProduct() {
  const { productsService } = useProductsService();
  const navigate = useNavigate();
  const { productId } = useParams<string>();
  // const [selectedPhotos, setSelectedPhotos] = useState<FileList | null>(null);
  const [photoPreviews, setPhotosPreviews] = useState<Array<string>>([]);
  const [productForm, setProductForm] = useState<ProductForm>({
    sku: '',
    name: '',
    brand: '',
    quantity: 0,
    price: 0,
    category: '',
    condition: 0,
    description: '',
    photos: null,
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
    const photos: Array<string> = [];
    const files = event.target.files;

    if (files) {
      for (let i = 0; i < files.length; i++) {
        photos.push(URL.createObjectURL(files[i]));
      }

      setProductForm((prevData) => ({
        ...prevData,
        ['photos']: files,
      }));
      setPhotosPreviews(photos);
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

    const photos: FileList = productForm.photos as FileList;

    const newProductRequestData: AddProductRequest = {
      sku: productForm.sku,
      name: productForm.name,
      categoryName: productForm.category,
      price: productForm.price,
      quantity: productForm.quantity,
      brandName: productForm.brand,
      description: productForm.description,
      condition: productForm.condition,
      image: photos.item(0) as File,
    };

    try {
      const productResponse = await productsService.addProduct(newProductRequestData);

      const addImageRequestPool: Promise<void>[] = [];

      for (let i = 0; i < photos.length; i++) {
        const photo = photos[i];
        const addImageToGalleryFormData: FormData = new FormData();
        addImageToGalleryFormData.append('image', photo);
        const request = productsService.addImageToGallery(
          productResponse.productId,
          addImageToGalleryFormData,
        );
        addImageRequestPool.push(request);
      }

      await Promise.all(addImageRequestPool);

      toast.success('Pomyślnie edytowano produkt', {
        position: toast.POSITION.TOP_RIGHT,
      });
      navigate('/products');
    } catch (err: any) {
      toast.error('Wystąpił błąd przy edycji produktu', {
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


  useEffect(() => {
    if (!productId) return;
    productsService.getProduct(productId).then((res) => {
      const productData: ProductDtoResponse = {
        sku: productForm.sku,
        name: productForm.name,
        category: productForm.category,
        price: productForm.price,
        quantity: productForm.quantity,
        brand: productForm.brand,
        description: productForm.description,
        condition: productForm.condition,
        gallery: productForm.photos
      }
    });
  }, []);

  return (
    <EditProductTemplate
      uploadProductPhotos={selectImages}
      photos={photoPreviews}
      onSubmit={handleSubmit}
      productForm={productForm}
      onChange={handleChange}
      errors={errors} />
  );
}
