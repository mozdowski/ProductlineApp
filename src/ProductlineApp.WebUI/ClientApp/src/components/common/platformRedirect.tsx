import { useEffect } from 'react';
import { useNavigate, useParams, useSearchParams } from 'react-router-dom';
import { useUserService } from '../../hooks/user/useUserService';
import { GainAccessTokenRequest } from '../../interfaces/platforms/gainAccessTokenRequest';
import { toast } from 'react-toastify';

const PLatformRedirect = () => {
  const navigate = useNavigate();
  const { platformId } = useParams<string>();
  const [searchParams, setSearchParams] = useSearchParams();
  const { userService } = useUserService();

  useEffect(() => {
    const fetchData = async () => {
      const code = searchParams.get('code');

      if (code && platformId) {
        const data: GainAccessTokenRequest = {
          code: code,
        };
        try {
          const result = await userService.gainAccessToken(platformId, data);
          toast.success('Pomyślnie podłączono platformę');
        } catch {
          toast.error('Nie udało się podłączyć platformy');
        }
      } else {
        toast.error('Nie udało się podłączyć platformy: nieprawidłowe dane platformy');
      }
    };

    fetchData();
    navigate('/');
  }, [navigate]);

  return null;
};

export default PLatformRedirect;
