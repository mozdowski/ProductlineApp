import { useContext } from 'react';
import { ConfirmationPopupContext } from '../../context/popupContext';

export const useConfirmationPopup = () => useContext(ConfirmationPopupContext);

export {};
