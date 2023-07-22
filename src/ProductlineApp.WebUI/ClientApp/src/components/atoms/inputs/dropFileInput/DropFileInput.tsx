import React, { useEffect, useRef, useState } from "react";
import "./css/dropFileInput.css";
import PropTypes from 'prop-types';
import { Props } from "react-apexcharts";
import fileDefaultIcon from '../../../../assets/icons/defaultFile_icon.png';
import filePdfIcon from '../../../../assets/icons/pdfFile_icon.png';
import fileImageIcon from '../../../../assets/icons/imageFile_icon.png';
import uploadIcon from '../../../../assets/icons/uplaodFiles_icon.svg';
import ConfirmUploadedFilesButton from "../../buttons/confirmUploadedFilesButton/ConfirmUploadedFilesButton";
import CancelButton from "../../buttons/cancelButton/CancelButton";

const DropFileInput = (props: Props) => {

    interface imageFilesTypes {
        [key: string]: string;
    }

    const ImageFiles: imageFilesTypes = {
        default: fileDefaultIcon,
        pdf: filePdfIcon,
        png: fileImageIcon,
    }

    const wrapperRef = useRef<HTMLDivElement>(null);

    const [fileList, setFileList] = useState<any[]>([]);

    const onDragEnter = () => wrapperRef.current?.classList.add('dragover');

    const onDragLeave = () => wrapperRef.current?.classList.remove('dragover');

    const onDrop = () => wrapperRef.current?.classList.remove('dragover');

    const onFileDrop = (e: any) => {
        const newFile = e.target.files[0];
        if (newFile) {
            const updatedList = [...fileList, newFile];
            setFileList(updatedList);
            props.onFileChange(updatedList);
        }
    }

    const fileRemove = (file: any) => {
        const updatedList = [...fileList];
        updatedList.splice(fileList.indexOf(file), 1);
        setFileList(updatedList);
        props.onFileChange(updatedList);
    }

    return (
        <>
            <div
                ref={wrapperRef}
                className="dropFileInput"
                onDragEnter={onDragEnter}
                onDragLeave={onDragLeave}
                onDrop={onDrop}
            >
                <div className="dropFileInputLabel">
                    <img src={uploadIcon} alt="" />
                    <p>Przeciągnij i upuść pliki</p>
                </div>
                <input type="file" value="" onChange={onFileDrop} />
            </div>
            {
                fileList.length > 0 ? (
                    <div className="ordersFilesPreviev">
                        {
                            fileList.map((item, index) => (
                                <>
                                    <div key={index} className="orderFilePreviev">
                                        <img src={ImageFiles[item.type.split('/')[1]] || ImageFiles['default']} alt="" />
                                        <div className="orderFilePrevievInfo">
                                            <p>{item.name}</p>
                                        </div>
                                        <div className="deleteOrderFileButton" onClick={() => fileRemove(item)}>
                                            <span className="deleteOrderFileIcon deleteFileOrderIcon" />
                                        </div>
                                    </div>
                                    <ConfirmUploadedFilesButton />
                                </>
                            ))
                        }
                    </div>
                ) : null
            }
        </>
    );
}

DropFileInput.prototype = {
    onFileChange: PropTypes.func
}

export default DropFileInput