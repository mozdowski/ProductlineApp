import * as React from 'react';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import Typography from '@mui/material/Typography';
import { CardActionArea } from '@mui/material';
import './card.css';
import AllegroIcon from '../../../../assets/icons/allegro_icon.svg';
import { Parameter } from '../../../../interfaces/platforms/getAllegroCatalogueResponse';

interface ActionAreaCardProps {
  id: string;
  title: string;
  imageUrl: string | undefined;
  onCardClick: (id: string) => void;
  parameters: Parameter[];
  selectedId: string;
}

const ActionAreaCard: React.FC<ActionAreaCardProps> = ({
  id,
  title,
  imageUrl,
  onCardClick,
  parameters,
  selectedId,
}) => {
  const image = imageUrl ? imageUrl : AllegroIcon;

  const isSelected = selectedId === id;

  const handleCardClick = () => {
    onCardClick(id);
  };

  return (
    <Card
      sx={{
        boxShadow: '0 2px 4px rgba(0, 0, 0, 0.2)',
        border: 'solid',
        borderWidth: '2px',
        borderColor: isSelected ? '#12121236' : 'transparent',
        transition: 'border-color 0.3s ease-in-out',
      }}
      id={id}
      onClick={handleCardClick}
    >
      <CardActionArea
        sx={{
          display: 'flex',
          justifyContent: 'flex-start',
          height: '220px',
          width: '100%',
          gap: '30px',
        }}
      >
        <CardMedia
          component="img"
          height="auto"
          width="100%"
          image={image}
          alt="allegro product img"
          sx={{ padding: '10px', maxWidth: '25%' }}
        />
        <CardContent className="card-content">
          <Typography
            gutterBottom
            variant="h5"
            component="div"
            sx={{ fontFamily: 'Poppins, sans-serif' }}
          >
            {title}
          </Typography>
          <Typography variant="body2" color="text.secondary" component="div">
            <ul>
              {parameters.slice(0, 4).map((param, index) => (
                <li key={index}>
                  {param.name}: {param.valuesLabels[0]}
                </li>
              ))}
            </ul>
          </Typography>
        </CardContent>
      </CardActionArea>
    </Card>
  );
};

export default ActionAreaCard;
