import * as React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea } from '@mui/material';
import './card.css';

interface ActionAreaCardProps {
  title: string;
  description: string;
  imageUrl: string | undefined;
}

const ActionAreaCard: React.FC<ActionAreaCardProps> = ({ title, description, imageUrl }) => {
  return (
    <div className="action-area-card">
      <Card sx={{ maxWidth: 345 }}>
        <CardActionArea>
          <CardMedia component="img" height="310" image={imageUrl} alt="allegro product img" />
          <CardContent>
            <Typography gutterBottom variant="h5" component="div">
              {title}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {description}
            </Typography>
          </CardContent>
        </CardActionArea>
      </Card>
    </div>
  );
};

export default ActionAreaCard;
