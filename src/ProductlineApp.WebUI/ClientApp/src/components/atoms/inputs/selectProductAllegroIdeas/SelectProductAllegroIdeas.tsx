import './css/selectProductAllegroIdeas.css';

function SelectProductAllegroIdeas() {

  return (
    <div className="selectProductAllegroIdeasInputField">
      <label htmlFor="selectProductIdea" className="selectProductIdeaLabel">
        Produkty odpowiadajace twojemu
      </label>
      <div className='selectDiv'>
        <select className='selectProductIdeaInput'>
          <option key={1} value={"produkt1"}>
            <div className='productAllegroIdeaImage'></div>
            <label>Product</label>
          </option>
        </select>
      </div>
    </div>
  );
}

export default SelectProductAllegroIdeas;
