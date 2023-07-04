import SearchIcon from '../../../../assets/icons/search_icon.svg';
import './searchButton.css';

function SearchButton({ onClick }: { onClick: (event: React.FormEvent<HTMLFormElement>) => void }) {
  return (
    <div className="searchLink" id="link">
      <div className="searchButton">
        <img id="image" src={SearchIcon} onClick={() => onClick} />
      </div>
    </div>
  );
}

export default SearchButton;
