import ChangeProfilePhotoButton from "../../../atoms/buttons/changeProfilePhotoButton/ChangeProfilePhotoButton";
import "./css/changeProfilePhotoSection.css"


function ChangeProfilePhotoSection({ image, showImage, UserImage }: { image: any, showImage: any, UserImage: any }) {
    return (
        <>
            <div className="changeProfilePhotoSection">
                <div className="profileImage">
                    <img className="uploadedImage" src={image === null ? UserImage : URL.createObjectURL(image)}></img >
                </div>
                <ChangeProfilePhotoButton showImage={showImage} />
            </div>
        </>

    );
}

export default ChangeProfilePhotoSection

