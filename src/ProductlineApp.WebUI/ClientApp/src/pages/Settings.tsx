import { useState } from 'react';
import SettingsTemplate from '../components/templates/SettingsTemplate';
import { useAuth } from '../hooks/auth/useAuth';

export default function Settings() {
  const [image, setImage] = useState<File | null>(null);
  const { user } = useAuth();


  const showImage = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (!e.target.files) return;

    setImage(e.target.files[0]);
  };

  return <SettingsTemplate image={image} showImage={showImage} UserImage={user?.avatar} />;
}
