import React from 'react';
import { DndProvider } from 'react-dnd';
import { HTML5Backend } from 'react-dnd-html5-backend';

interface DndProviderWrapperProps {
  children: React.ReactNode;
}

const DndProviderWrapper: React.FC<DndProviderWrapperProps> = ({ children }) => {
  return <DndProvider backend={HTML5Backend}>{children}</DndProvider>;
};

export default DndProviderWrapper;
