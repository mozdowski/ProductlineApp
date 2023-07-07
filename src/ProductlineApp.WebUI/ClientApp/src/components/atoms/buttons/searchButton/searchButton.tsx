import SearchIcon from '../../../../assets/icons/search_icon.svg';
import './searchButton.css';

function SearchButton({ onClick }: { onClick: (event: React.FormEvent<HTMLFormElement>) => void }) {
  return (
    <div className="searchLink" id="link">
      <button type="submit" className="searchButton">
        <img id="image" src={SearchIcon} />
      </button>
    </div>
  );
}

export default SearchButton;
