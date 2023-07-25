import { Chip, Avatar } from '@mui/material';
import { useDrag, useDrop } from 'react-dnd';
import './imageChip.css';

const ImageChipStyle = {
  width: '122px',
  height: '122px',
  border: 'none',
  position: 'relative',
  '& .MuiChip-deleteIcon': {
    margin: '-12px -13px auto auto',
    width: '22px',
    height: '22px',
    zIndex: 1,
    color: '#aab1c6',
    "&:hover": { color: "#FF4A4A" }
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
        variant="filled"
        onDelete={onDelete}
        avatar={
          <Avatar>
            <img src={imageUrl} key={id} className="productImagePreviev" alt="Product" />
          </Avatar>
        }
        sx={ImageChipStyle}
      />
    </div>
  );
};

export default ImageChip;
