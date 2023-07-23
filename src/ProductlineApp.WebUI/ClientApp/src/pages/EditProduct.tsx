import { useEffect, useState } from 'react';
import { ProductForm } from '../interfaces/products/productForm';
import { useProductsService } from '../hooks/products/useProductsService';
import { useNavigate, useParams } from 'react-router-dom';
import * as Yup from 'yup';
import { toast } from 'react-toastify';
import EditProductTemplate from '../components/templates/EditProductTemplate';
import { ProductEditForm } from '../interfaces/products/productEditForm';
import { Photo } from '@mui/icons-material';
import { EditProductRequest } from '../interfaces/products/editProductRequest';

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
      return (value as Array<Photo>).length > 0;
    }),
});

export interface Photo {
  id: number;
  url: string;
  source: PhotoSource;
}

export enum PhotoSource {
  SERVER,
  UPLOADED,
}

export default function EditProduct() {
  const { productsService } = useProductsService();
  const navigate = useNavigate();
  const { productId } = useParams<string>();

  const [uploadedPhotos, setUploadedPhotos] = useState<Record<number, File>>({});

  const [productForm, setProductForm] = useState<ProductEditForm>({
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
    const photos: Photo[] = [];
    const files = event.target.files;
    const maxId = Math.max(...productForm.photos.map((o) => o.id)) + 1;

    if (files) {
      for (let i = 0; i < files.length; i++) {
        const uploadedUrl = URL.createObjectURL(files[i]);
        const id = maxId + i;
        photos.push({
          id: id,
          url: uploadedUrl,
          source: PhotoSource.UPLOADED,
        });

        setUploadedPhotos((prevData) => ({
          ...prevData,
          [id]: files[i],
        }));
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

    const editProductRequestData: EditProductRequest = {
      sku: productForm.sku,
      name: productForm.name,
      categoryName: productForm.category,
      price: productForm.price,
      quantity: productForm.quantity,
      brandName: productForm.brand,
      description: productForm.description,
      condition: productForm.condition,
      imageFile:
        productForm.photos[0].source === PhotoSource.UPLOADED
          ? (uploadedPhotos[productForm.photos[0].id] as File)
          : undefined,
      imageUrl:
        productForm.photos[0].source === PhotoSource.SERVER ? productForm.photos[0].url : undefined,
      gallery: productForm.photos
        .slice(1)
        .filter((x) => x.source === PhotoSource.SERVER)
        .map((x) => x.url),
    };

    const uploadedFiles = Object.values(uploadedPhotos);

    console.log(editProductRequestData);

    try {
      const productResponse = await toast.promise(
        Promise.all([
          productsService.updateProduct(productId as string, editProductRequestData),
          ...uploadedFiles.map((photo) => {
            const addImageToGalleryFormData: FormData = new FormData();
            addImageToGalleryFormData.append('image', photo);
            return productsService.addImageToGallery(
              productId as string,
              addImageToGalleryFormData,
            );
          }),
        ]),
        {
          pending: 'Edytowanie produktu...',
          success: 'Pomyślnie edytowano produkt',
          error: 'Wystąpił błąd przy edycji produktu',
        },
      );

      navigate('/products');
    } catch (err: any) {
      toast.error('Wystąpił błąd przy edycji produktu');
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

  useEffect(() => {
    if (!productId) return;
    productsService.getProduct(productId).then((res) => {
      const product = res.product;
      const productEditForm: ProductEditForm = {
        sku: product.sku,
        name: product.name,
        category: product.category,
        price: product.price,
        quantity: product.quantity,
        brand: product.brand,
        description: product.description,
        condition: product.condition,
        photos: [product.imageUrl, ...product.gallery].map((x, index) => ({
          id: index,
          url: x,
          source: PhotoSource.SERVER,
        })),
      };
      setProductForm(productEditForm);
      console.log(res);
    });
  }, []);

  return (
    <EditProductTemplate
      uploadProductPhotos={selectImages}
      photos={productForm.photos}
      onSubmit={handleSubmit}
      productForm={productForm}
      onChange={handleChange}
      errors={errors}
      onPhotoMove={handleMovePhoto}
      onPhotoDelete={handleDeletePhoto}
    />
  );
}
