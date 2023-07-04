import * as React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea } from '@mui/material';
import './card.css';
import AllegroIcon from '../../../../assets/icons/allegro_icon.svg';

interface ActionAreaCardProps {
  title: string;
  imageUrl: string | undefined;
}

const ActionAreaCard: React.FC<ActionAreaCardProps> = ({ title, imageUrl }) => {
  const image = imageUrl ? imageUrl : AllegroIcon;

  return (
    // <div className='card'>
    //     <div className='cardActionArea'>
    //         {imageUrl && (
    //             <div className='cardMedia'>
    //                 <img src={imageUrl} alt="allegro product img" className='productImage' />
    //             </div>
    //         )}
    //         <div className="cardContent">
    //             <div className='title'>
    //                 {title}
    //             </div>
    //         </div>
    //     </div>
    // </div>
    <Card sx={{ boxShadow: '0 2px 4px rgba(0, 0, 0, 0.2)' }}>
      <CardActionArea sx={{ display: 'flex', justifyContent: 'space-between' }}>
        <CardMedia
          component="img"
          height="310"
          image={image}
          alt="allegro product img"
          sx={{ height: '80px', width: 'auto', padding: '10px', maxWidth: '30%' }}
        />
        <CardContent className="card-content">
          <Typography gutterBottom variant="h5" component="div">
            {title}
          </Typography>
        </CardContent>
      </CardActionArea>
    </Card>
  );
};

export default ActionAreaCard;
