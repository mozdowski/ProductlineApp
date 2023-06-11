import ChangePersonalDataSection from "../../../molecules/settingsSections/changePersonalDataSection/ChangePersonalDataSection";
import ChangeProfilePhotoSection from "../../../molecules/settingsSections/changeProfilePhotoSection/ChangeProfilePhotoSection";
import "./css/profileDetails.css"

export const ProfileDetails = ({ image, showImage, UserImage }: { image: any, showImage: any, UserImage: any }) => {
    return (
        <div className="profileDetails">
            <h1>Szczegóły Profilu</h1>
            <ChangeProfilePhotoSection image={image} showImage={showImage} UserImage={UserImage} />
            <ChangePersonalDataSection />
        </div>
    );
}