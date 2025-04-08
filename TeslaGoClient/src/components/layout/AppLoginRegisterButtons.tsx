import { Link } from "react-router-dom";
import Button, { ButtonStyle } from "../common/Button";

interface AppLoginRegisterButtonsProps {
  gap?: number;
  width?: number;
  height?: number;
  fontSize?: number;
}

export const AppLoginRegisterButtons = ({
  gap = 24,
  width = 170,
  height = 52,
  fontSize = 16,
}: AppLoginRegisterButtonsProps) => {
  return (
    <div className="flex flex-row justify-center items-center" style={{ gap: gap }}>
      <Link to="/sign-in">
        <Button
          text="Sign in"
          width={width}
          height={height}
          fontSize={fontSize}
          rounded={999}
          style={ButtonStyle.Primary}
          action={() => {}}
        />
      </Link>
      <Link to="/sign-up">
        <Button
          text="Sign up"
          width={width}
          height={height}
          fontSize={fontSize}
          rounded={999}
          style={ButtonStyle.Secondary}
          action={() => {}}
        />
      </Link>
    </div>
  );
};
