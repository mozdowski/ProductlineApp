import { ChangeEvent, SetStateAction, useState } from 'react';
import AddProductTemplate from '../components/templates/AddProductTemplate';

export default function AddProduct() {
  const [selectedPhotos, setSelectedPhotos] = useState<FileList | null>(null);
  const [photoPreviews, setPhotosPreviews] = useState<Array<string>>([]);

  const selectImages = (event: React.ChangeEvent<HTMLInputElement>) => {
    let photos: Array<string> = [];
    let files = event.target.files;

    if (files) {
      for (let i = 0; i < files.length; i++) {
        photos.push(URL.createObjectURL(files[i]));
      }

      setSelectedPhotos(files);
      setPhotosPreviews(photos);
    }
  };

  console.log("hahahh");

  return <AddProductTemplate uploadProductPhotos={selectImages} photos={photoPreviews} />;
}
