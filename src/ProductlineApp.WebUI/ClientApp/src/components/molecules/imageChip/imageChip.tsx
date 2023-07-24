import { Chip, Avatar } from '@mui/material';
import { useDrag, useDrop } from 'react-dnd';
import './imageChip.css';
import { ReactComponent as DeleteIcon } from '../../../assets/icons/deleteFile_icon.svg';

const ImageChipStyle = {
  width: '120px',
  height: '120px',
  border: 'none',
  position: 'relative',
  '& .MuiChip-deleteIcon': {
    margin: '-4px -4px auto auto',
    width: '10px',
    height: '10px',
    zIndex: 1,
  },
  '& .MuiChip-avatar': {
    width: '100%',
    height: '100%',
    borderRadius: '8px',
    margin: 0,
    position: 'absolute',
    backgroundColor: '#FFFFFF',
  },
};

interface ImageChipProps {
  onDelete: () => void;
  imageUrl: string;
  id: string;

  moveChip: (dragIndex: number, hoverIndex: number) => void;
  index: number;
}

const ImageChip: React.FC<ImageChipProps> = ({ imageUrl, id, onDelete, moveChip, index }) => {
  const [{ isDragging }, drag] = useDrag({
    type: 'ImageChip',
    item: { id, index },
    collect: (monitor) => ({
      isDragging: !!monitor.isDragging(),
    }),
  });

  const [, drop] = useDrop({
    accept: 'ImageChip',
    hover: (item: { id: string; index: number }) => {
      if (item.index !== index) {
        moveChip(item.index, index);
        item.index = index;
      }
    },
  });

  return (
    <div ref={(node) => drag(drop(node))} style={{ opacity: isDragging ? 0 : 1 }}>
      <Chip
        deleteIcon={<DeleteIcon />}
        variant="filled"
        onDelete={onDelete}
        avatar={
          <Avatar>
            <img src={imageUrl} key={id} className="productImage" alt="Product" />
          </Avatar>
        }
        sx={ImageChipStyle}
      />
    </div>
  );
};

export default ImageChip;
