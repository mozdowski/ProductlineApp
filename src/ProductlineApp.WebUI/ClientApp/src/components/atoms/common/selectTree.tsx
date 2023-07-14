import React, { useState } from 'react';
import { Select, MenuItem, FormControl, InputLabel, SelectChangeEvent } from '@mui/material';
import { TreeItem, TreeView } from '@mui/lab';
import { ChevronRight, ExpandMore } from '@mui/icons-material';
import { TreeSelectOption } from '../../../interfaces/common/treeSelectOption';

const TreeSelectStyle = {
  width: '316px',
  height: '44px',
  color: '#757575',
  fontFamily: 'Poppins, sans-serif',
  fontSize: '12px',
  fontWeight: 300,
  backgroundColor: '#f8f8f8',
  border: '1px solid #d8d8d8',
  borderRadius: '8px',
  padding: 'inherit',
  margin: 'auto',
  '& fieldset': {
    border: 'none',
  },
};

interface TreeSelectProps {
  options: TreeSelectOption[];
  value: string;
  onChange: (id: string, name: string) => void;
}

const TreeSelect: React.FC<TreeSelectProps> = ({ options, value, onChange }) => {
  const [selectedOption, setSelectedOption] = useState<string>(value ? value : '');
  const [isOpen, setIsOpen] = useState<boolean>(false);

  const handleTreeViewClick = (event: any, optionLabel: string) => {
    event.stopPropagation();
    onChange(event.target.value.toString(), optionLabel);
    setSelectedOption(optionLabel);
    setIsOpen(false);
  };

  const renderTree = (nodes: TreeSelectOption[]) => {
    return nodes.map((node) => {
      const { id, label, children } = node;

      return (
        <TreeView
          key={id}
          defaultCollapseIcon={<ExpandMore />}
          defaultExpandIcon={<ChevronRight />}
          onNodeToggle={(event, nodeIds) => {
            event.stopPropagation();
          }}
          sx={{ '& .MuiTreeItem-label': { cursor: 'pointer' } }}
        >
          {!children && (
            <MenuItem
              sx={{ height: '40px' }}
              key={id}
              value={id}
              onClick={(event) => handleTreeViewClick(event, label)}
            >
              {label}
            </MenuItem>
          )}
          {children && (
            <TreeItem
              key={id}
              nodeId={id}
              label={label}
              sx={{ cursor: 'pointer', '& .MuiTreeItem-content': { height: '40px' } }}
            >
              {renderTree(children)}
            </TreeItem>
          )}
        </TreeView>
      );
    });
  };

  return (
    <FormControl>
      <Select
        labelId="select-label"
        value={selectedOption}
        onClick={(event) => event.stopPropagation()}
        renderValue={(value) => value as string}
        sx={TreeSelectStyle}
        open={isOpen}
        onOpen={() => setIsOpen(true)}
        onClose={() => setIsOpen(false)}
      >
        <MenuItem
          sx={{ height: '40px' }}
          value=""
          onClick={(event) => handleTreeViewClick(event, '')}
        >
          {'Brak'}
        </MenuItem>
        {options && renderTree(options)}
      </Select>
    </FormControl>
  );
};

export default TreeSelect;
