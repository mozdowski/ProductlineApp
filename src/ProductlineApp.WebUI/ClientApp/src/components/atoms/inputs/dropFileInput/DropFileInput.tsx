import React, { useEffect, useRef, useState } from 'react';
import './css/dropFileInput.css';
import PropTypes from 'prop-types';
import fileDefaultIcon from '../../../../assets/icons/defaultFile_icon.png';
import filePdfIcon from '../../../../assets/icons/pdfFile_icon.png';
import fileImageIcon from '../../../../assets/icons/imageFile_icon.png';
import uploadIcon from '../../../../assets/icons/uplaodFiles_icon.svg';
import ConfirmUploadedFilesButton from '../../buttons/confirmUploadedFilesButton/ConfirmUploadedFilesButton';
import { OrderDocument } from '../../../../interfaces/orders/orderDocumentsResponse';
import CancelIcon from '@mui/icons-material/Cancel';
import BasicTooltip from '../../common/tooltip/basicTooltip';

interface DropFileInputProps {
  orderDocuments: OrderDocument[];
  onFilesSubmit: (serverFiles: string[], uploadedFileList: File[]) => void;
}

interface imageFilesTypes {
  [key: string]: string;
}

const ImageFiles: imageFilesTypes = {
  default: fileDefaultIcon,
  pdf: filePdfIcon,
  png: fileImageIcon,
};

const DropFileInput: React.FC<DropFileInputProps> = ({ orderDocuments, onFilesSubmit }) => {
  const wrapperRef = useRef<HTMLDivElement>(null);
  const [uploadedFileList, setUploadedFileList] = useState<File[]>([]);
  const [serverFileList, setServerFileList] = useState<OrderDocument[]>([]);

  useEffect(() => {
    if (orderDocuments) {
      setServerFileList(orderDocuments);
    }
  }, [orderDocuments]);

  const onDragEnter = () => wrapperRef.current?.classList.add('dragover');
  const onDragLeave = () => wrapperRef.current?.classList.remove('dragover');
  const onDrop = () => wrapperRef.current?.classList.remove('dragover');

  const onFileDrop = (e: React.ChangeEvent<HTMLInputElement>) => {
    const files = e.target.files;
    if (!files) return;

    const newFile = files[0];
    if (newFile) {
      const updatedList = [...uploadedFileList, newFile];
      setUploadedFileList(updatedList);
    }
  };

  const uploadedFileRemove = (file: File) => {
    const updatedList = [...uploadedFileList];
    updatedList.splice(uploadedFileList.indexOf(file), 1);
    setUploadedFileList(updatedList);
  };

  const serverFileRemove = (fileId: string) => {
    const updatedList = serverFileList.filter((order) => order.id !== fileId);
    setServerFileList(updatedList);
  };

  const handleConfirmClick = () => {
    onFilesSubmit(
      serverFileList.map((x) => x.id),
      uploadedFileList,
    );
  };

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

      {(uploadedFileList.length > 0 || serverFileList.length > 0) && (
        <div className="ordersFilesPreviev">
          {serverFileList.length > 0 &&
            serverFileList.map((item, index) => (
              <React.Fragment key={index}>
                <div className="orderFilePreviev">
                  <a href={item.url} className="fileDownloadAnchor" download>
                    <img
                      src={ImageFiles[item.name.split('.')[1]] || ImageFiles['default']}
                      alt=""
                    />
                    <div className="orderFilePrevievInfo">
                      <p>{item.name}</p>
                    </div>
                  </a>
                  <BasicTooltip title="Usuń">
                    <div
                      className="deleteOrderFileButton"
                      onClick={() => serverFileRemove(item.id)}
                    >
                      <CancelIcon
                        sx={{
                          color: '#aab1c6',
                          height: '22px',
                          width: '22px',
                          '&:hover': { color: '#FF4A4A' },
                        }}
                      />
                    </div>
                  </BasicTooltip>
                </div>
              </React.Fragment>
            ))}

          {uploadedFileList.length > 0 &&
            uploadedFileList.map((item, index) => (
              <React.Fragment key={index + serverFileList.length}>
                <div className="orderFilePreviev">
                  <a href={URL.createObjectURL(item)} className="fileDownloadAnchor" download>
                    <img
                      src={ImageFiles[item.type.split('/')[1]] || ImageFiles['default']}
                      alt=""
                    />
                    <div className="orderFilePrevievInfo">
                      <p>{item.name}</p>
                    </div>
                  </a>
                  <BasicTooltip title="Usuń">
                    <div className="deleteOrderFileButton" onClick={() => uploadedFileRemove(item)}>
                      <CancelIcon
                        sx={{
                          color: '#aab1c6',
                          height: '22px',
                          width: '22px',
                          '&:hover': { color: '#FF4A4A' },
                        }}
                      />
                    </div>
                  </BasicTooltip>
                </div>
              </React.Fragment>
            ))}

          <ConfirmUploadedFilesButton onClick={handleConfirmClick} />
        </div>
      )}
    </>
  );
};

DropFileInput.prototype = {
  onFileChange: PropTypes.func,
};

export default DropFileInput;
