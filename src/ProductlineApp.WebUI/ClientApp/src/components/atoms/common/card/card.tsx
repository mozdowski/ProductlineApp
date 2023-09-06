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
        boxShadow: 'rgba(0, 0, 0, 0.1) 0px 4px 12px;',
        border: 'solid',
        borderWidth: '1px',
        borderColor: isSelected ? '#5f47f1' : 'transparent',
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
          sx={{ padding: '10px 0px 10px 20px', maxWidth: '25%' }}
        />
        <CardContent className="card-content">
          <Typography
            gutterBottom
            variant="h5"
            component="div"
            sx={{ fontFamily: 'Poppins, sans-serif', fontSize: '20px', fontWeight: '500' }}
          >
            {title}
          </Typography>
          <Typography variant="body2" color="#757575" component="div" sx={{ fontFamily: 'Poppins, sans-serif', fontSize: '12px', marginLeft: '-25px', fontWeight: '400' }}>
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
