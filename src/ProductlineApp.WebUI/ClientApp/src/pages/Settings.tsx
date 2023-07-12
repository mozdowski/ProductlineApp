import { useEffect, useState } from 'react';
import SettingsTemplate from '../components/templates/SettingsTemplate';
import { useAuth } from '../hooks/auth/useAuth';
import { usePlatforms } from '../hooks/platforms/usePlatforms';
import { useUserService } from '../hooks/user/useUserService';

export default function Settings() {
  const [image, setImage] = useState<File | null>(null);
  const { user } = useAuth();
  const { platforms } = usePlatforms();
  const { userService } = useUserService();
  const [platformConnections, setPlatformConnections] = useState<string[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const connections = await userService.getUserConnections()
      setPlatformConnections(connections);
    }

    fetchData();
  }, []);

  const showImage = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (!e.target.files) return;

    setImage(e.target.files[0]);
  };

  const handleDisconnect = (platformName: string) => {};

  return (
    <SettingsTemplate
      platformsAuthUrl={platforms}
      image={image}
      showImage={showImage}
      UserImage={user?.avatar}
      onDisconnect={handleDisconnect}
      userConnections={platformConnections}
    />
  );
}
