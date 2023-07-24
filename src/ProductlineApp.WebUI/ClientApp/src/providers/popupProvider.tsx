import { ReactNode, useState } from 'react';
import {
  ConfirmationPopupContext,
  ConfirmationPopupContextProps,
  PopupContext,
  PopupContextProps,
} from '../context/popupContext';
import ConfirmationPopup from '../components/common/confirmationPopup/confirmationPopup';
import { IconButton } from '@mui/material';
import CloseIcon from '@mui/icons-material/Close';

interface PopupProviderProps {
  children: ReactNode;
}

export const PopupProvider: React.FC<PopupProviderProps> = ({ children }) => {
  const [popupContent, setPopupContent] = useState<React.ReactNode | null>(null);
  const [confirmationPopupContent, setConfirmationPopupContent] = useState<React.ReactNode | null>(
    null,
  );

  const openPopup = (content: React.ReactNode) => {
    setPopupContent(content);
  };

  const hidePopup = () => {
    setPopupContent(null);
    setConfirmationPopupContent(null);
  };

  const showConfirmation = (question: string, onConfirm: () => void) => {
    const handleConfirm = () => {
      onConfirm();
      hidePopup();
    };

    const handleCancel = () => {
      hidePopup();
    };

    const confirmationContent = (
      <ConfirmationPopup text={question} onCancel={handleCancel} onConfirm={handleConfirm} />
    );

    setConfirmationPopupContent(confirmationContent);
  };

  const popupContextValue: PopupContextProps = {
    openPopup,
    hidePopup,
  };

  const confirmationPopupContextValue: ConfirmationPopupContextProps = {
    showConfirmation,
  };

  return (
    <PopupContext.Provider value={popupContextValue}>
      <ConfirmationPopupContext.Provider value={confirmationPopupContextValue}>
        {children}
        {confirmationPopupContent && <>{confirmationPopupContent}</>}
        {popupContent && (
          <div className="overlayPopup">
            <div className="popup">
              <div className="closeButton">
                <IconButton
                  onClick={hidePopup}
                  sx={{
                    float: 'right',
                    marginRight: '-20px',
                    marginTop: '-20px',
                  }}
                >
                  <CloseIcon />
                </IconButton>
              </div>
              {popupContent}
            </div>
          </div>
        )}
      </ConfirmationPopupContext.Provider>
    </PopupContext.Provider>
  );
};

export {};
