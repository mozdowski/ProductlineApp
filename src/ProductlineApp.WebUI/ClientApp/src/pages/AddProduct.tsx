import { ChangeEvent, SetStateAction, useState } from 'react';
import AddProductTemplate from '../components/templates/AddProductTemplate';
import { AddProductRequest } from '../interfaces/products/addProductRequest';
import { ProductCondition } from '../enums/productCondition';
import { ProductForm } from '../interfaces/products/productForm';
import { useProductsService } from '../hooks/products/useProductsService';
import { useNavigate } from 'react-router-dom';

export default function AddProduct() {
  const { productsService } = useProductsService();
  const navigate = useNavigate();
  const [selectedPhotos, setSelectedPhotos] = useState<FileList | null>(null);
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
  });

  const selectImages = (event: React.ChangeEvent<HTMLInputElement>) => {
    const photos: Array<string> = [];
    const files = event.target.files;

    if (files) {
      for (let i = 0; i < files.length; i++) {
        photos.push(URL.createObjectURL(files[i]));
      }

      setSelectedPhotos(files);
      setPhotosPreviews(photos);
    }
  };

  const handleSubmit = async (event: React.FormEvent<HTMLFormElement>): Promise<void> => {
    event.preventDefault();

    const photos: FileList = selectedPhotos as FileList;

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

    navigate('/products');
  };

  const handleChange = (name: string, value: number | string) => {
    setProductForm((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  return (
    <AddProductTemplate
      uploadProductPhotos={selectImages}
      photos={photoPreviews}
      onSubmit={handleSubmit}
      productForm={productForm}
      onChange={handleChange}
    />
  );
}
