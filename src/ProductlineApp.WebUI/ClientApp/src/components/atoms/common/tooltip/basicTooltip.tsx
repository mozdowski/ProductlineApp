import * as React from 'react';
import Tooltip from '@mui/material/Tooltip';

export interface BasicTooltipProps {
  children: React.ReactElement;
  title: string;
  placement?:
    | 'top'
    | 'bottom-end'
    | 'bottom-start'
    | 'bottom'
    | 'left-end'
    | 'left-start'
    | 'left'
    | 'right-end'
    | 'right-start'
    | 'right'
    | 'top-end'
    | 'top-start'
    | undefined;
}

const BasicTooltip: React.FC<BasicTooltipProps> = ({ children, title, placement }) => {
  return (
    <Tooltip title={title} placement={placement ? placement : 'top'} arrow>
      {children}
    </Tooltip>
  );
};

export default BasicTooltip;
