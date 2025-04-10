import { useLocation, useNavigate } from "react-router-dom";

interface TabButtonProps {
  path: string;
  text: string;
  width?: number;
}

const TabButton = ({ path, text, width }: TabButtonProps) => {
  const navigate = useNavigate();
  const location = useLocation();

  const isActive = (path: string) => location.pathname === path;

  return (
    <button
      className={`w-full rounded-lg shadow-lg hover:cursor-pointer text-base px-4 py-3 ${
        isActive(path) ? "bg-primaryGreen text-white" : "bg-[#F9F9F9]"
      }`}
      style={{ width: width }}
      onClick={() => navigate(path)}
    >
      {text}
    </button>
  );
};
export default TabButton;
