import { useEffect, useState } from 'react';
import SettingsTemplate from '../components/templates/SettingsTemplate';
import { useAuth } from '../hooks/auth/useAuth';
import { usePlatforms } from '../hooks/platforms/usePlatforms';
import { useUserService } from '../hooks/user/useUserService';
import { DisconnectPlatformRequest } from '../interfaces/user/disconnectPlatformRequest';
import { toast } from 'react-toastify';
import { ChangePasswordForm } from '../interfaces/settings/changePasswordForm';
import { ChangePasswordRequest } from '../interfaces/user/changePasswordRequest';
import { log } from 'console';
import { TabTitle } from '../helpers/changePageTitle';

export default function Settings() {
  TabTitle('productline. Ustawienia');

  const [image, setImage] = useState<File | undefined>();
  const { user, updateAvatar } = useAuth();
  const { platforms } = usePlatforms();
  const { userService } = useUserService();
  const [platformConnections, setPlatformConnections] = useState<string[]>([]);
  const [reloadPage, setReloadPage] = useState<boolean>(false);

  useEffect(() => {
    const fetchData = async () => {
      const connections = await userService.getUserConnections();
      setPlatformConnections(connections);
    };

    fetchData();
  }, [reloadPage]);

  /*const showImage = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (!e.target.files) return;

    setImage(e.target.files[0]);
  };
  */

  const handleDisconnect = async (platformId: string) => {
    try {
      const data: DisconnectPlatformRequest = {
        platformId: platformId,
      };
      // eslint-disable-next-line @typescript-eslint/no-unused-vars
      const response = await userService.disconnectPlatformConnection(data);
      toast.success('Usunięto połączenie z platformą');
      setReloadPage(!reloadPage);
    } catch {
      toast.error('Błąd przy usuwaniu platformy');
    }
  };

  const handlePasswordChange = async (data: ChangePasswordForm) => {
    try {
      const requestData: ChangePasswordRequest = {
        oldPassword: data.oldPassword,
        newPassword: data.newPassword,
      };

      // eslint-disable-next-line @typescript-eslint/no-unused-vars
      const response = await userService.changePassword(requestData);
      toast.success('Zmieniono hasło');
    } catch {
      toast.error('Błąd przy zmianie hasła');
    }
  };

  const handleAvatarChange = async (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.item(0);
    if (!file) return;

    try {
      const formData = new FormData();
      formData.append('avatar', file);

      const response = await userService.updateAvatar(formData);

      setImage(file);
      updateAvatar(response.url);

      toast.success('Zmieniono zdjecie profilowe');
    } catch {
      toast.error('Błąd przy zmianie zdjecia');
    }
  };

  return (
    <SettingsTemplate
      platformsAuthUrl={platforms}
      image={image}
      UserImage={user?.avatar}
      onDisconnect={handleDisconnect}
      userConnections={platformConnections}
      onPasswordChange={handlePasswordChange}
      UserName={user?.name as string}
      UserEmail={user?.email as string}
      changeAvatar={handleAvatarChange}
    />
  );
}
