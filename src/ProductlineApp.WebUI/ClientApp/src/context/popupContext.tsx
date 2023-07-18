import React, { createContext } from 'react';

export interface PopupContextProps {
  openPopup: (content: React.ReactNode) => void;
  hidePopup: () => void;
}

export const PopupContext = createContext<PopupContextProps>({
  openPopup: () => {},
  hidePopup: () => {},
});

export interface ConfirmationPopupContextProps {
  showConfirmation: (question: string, onConfirm: () => void) => void;
}

export const ConfirmationPopupContext = createContext<ConfirmationPopupContextProps>(
  {} as ConfirmationPopupContextProps,
);

export {};
