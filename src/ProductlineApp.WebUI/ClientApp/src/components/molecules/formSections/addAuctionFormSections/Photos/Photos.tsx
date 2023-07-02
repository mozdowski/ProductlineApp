import './css/addAuction_Photos.css';

function Photos({
  photos,
}: {
  photos: string[];
}) {
  return (
    <>
      <div className="photosInfo">
        <div className="sectionLabel">
          <div className="sectionNumber">
            <h1>3</h1>
          </div>
          <p>Zdjęcia Produktu</p>
        </div>
        <div className="auctionProductImages">
          {(photos || []).map(function (img, i) {
            return (i < 6) ? <img src={img} key={i} className="auctionProductImage"></img> : ""
          })}
        </div>
      </div>
    </>
  );
}

export default Photos;
