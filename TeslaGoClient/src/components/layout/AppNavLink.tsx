import { Link } from "react-router-dom";

interface AppNavLinkProps {
  to: string;
  text: string;
  fontSize?: number;
  isSemibold?: boolean;
  textColor?: string;
}

export const AppNavLink = ({
  to,
  text,
  fontSize = 24,
  isSemibold = true,
  textColor = "#000000",
}: AppNavLinkProps) => {
  return (
    <Link
      to={to}
      className={`hover:text-gray-700 text-[${textColor}] ${
        isSemibold ? "font-semibold" : "font-normal"
      }`}
      style={{ fontSize: fontSize }}
    >
      {text}
    </Link>
  );
};
