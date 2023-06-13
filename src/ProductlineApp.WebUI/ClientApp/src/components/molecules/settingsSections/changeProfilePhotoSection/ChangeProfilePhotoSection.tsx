import ChangeProfilePhotoButton from "../../../atoms/buttons/changeProfilePhotoButton/ChangeProfilePhotoButton";
import "./css/changeProfilePhotoSection.css"


function ChangeProfilePhotoSection({ image, showImage, UserImage }: { image: any, showImage: any, UserImage: any }) {
    return (
        <>
            <div className="changeProfilePhotoSection">
                <img className="uploadedImage" src={image === null ? UserImage : URL.createObjectURL(image)}></img >
                <ChangeProfilePhotoButton showImage={showImage} />
            </div>
        </>

    );
}

export default ChangeProfilePhotoSection

