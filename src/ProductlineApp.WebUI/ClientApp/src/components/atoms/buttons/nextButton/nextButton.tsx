import './nextButton.css';

function NextButton({ onClick }: { onClick: any }) {
  return (
    <a className="nextButton" onClick={onClick}>
      Dalej
    </a>
  );
}

export default NextButton;
