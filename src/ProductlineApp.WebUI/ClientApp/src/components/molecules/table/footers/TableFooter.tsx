import { FormSelect } from '../../../atoms/common/formSelect/formSelect';
import './css/TableFooter.css';

export const TableFooter = ({
  totalPages,
  currentPage,
  currentRowsCount,
  onPageChange,
  onRowsPerPageChange,
}: {
  totalPages: number;
  currentPage: number;
  currentRowsCount: number;
  onPageChange: (pageNumber: number) => void;
  onRowsPerPageChange: (rowsCount: number) => void;
}) => {
  const pages = [];

  for (let i = 1; i <= totalPages; i++) {
    pages.push(
      <li key={i}>
        <div
          className={`paginationNextButton ${currentPage === i ? 'activePage' : ''}`}
          onClick={() => onPageChange(i)}
        >
          <p>{i}</p>
        </div>
      </li>,
    );
  }

  return (
    <div className="paginationTable">
      <div></div>
      <div className="paginationButtons">
        <ul className="pagination">{pages}</ul>
      </div>
      <div className="rowsPerPage">
        <FormSelect
          value={currentRowsCount}
          onChange={(name: string, value: string) => onRowsPerPageChange(parseInt(value))}
          options={[5, 10, 15].map((x) => ({ value: x, label: x.toString() }))}
          name={'rowsPerPage'}
          error={undefined}
          inputHeight={31}
          inputWidth={60}
        />
      </div>
    </div>
  );
};
