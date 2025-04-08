import { Link } from "react-router-dom";
import appLogo from "../../assets/logo_tesla.png";

interface AppLogoProps {
  width?: number;
  height?: number;
}

export const AppLogo = ({ width = 300, height = 300 }: AppLogoProps) => {
  return (
    <Link to="/">
      <div style={{ width: width, height: height }}>
        <img src={appLogo} alt="TeslaGoLogo" className="object-contain w-full h-full" />
      </div>
    </Link>
  );
};
