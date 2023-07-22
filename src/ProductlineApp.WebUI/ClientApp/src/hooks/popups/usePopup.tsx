import { useContext } from 'react';
import { PopupContext } from '../../context/popupContext';

export const usePopup = () => useContext(PopupContext);

export {};
