import { IconDefinition } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export enum ButtonStyle {
  Primary,
  Secondary,
  Default,
  DefaultGray,
  CTA,
  Download,
}

interface ButtonProps {
  text: string;
  width?: number;
  height: number;
  type?: "button" | "submit" | "reset";
  style: ButtonStyle;
  rounded?: string;
  fontSize?: number;
  isFullWidth?: boolean;
  isFontSemibold?: boolean;
  icon?: IconDefinition;
  iconSize?: number;
  action: (event: React.MouseEvent<HTMLButtonElement>) => void;
}

const Button = (props: ButtonProps) => {
  const {
    text,
    width,
    type = "button",
    rounded = "rounded-full",
    height,
    fontSize = 16,
    isFontSemibold = false,
    style,
    action,
    iconSize,
    isFullWidth = false,
    icon,
  } = props;

  let buttonClass = "";
  switch (style) {
    case ButtonStyle.Primary:
      buttonClass = "bg-green-400 text-white text-base hover:bg-green-500";
      break;
    case ButtonStyle.Secondary:
      buttonClass =
        "bg-transparent hover:text-gray-800 text-black text-base border-solid border-green-400 border-2 hover:border-green-500";
      break;
    default:
      buttonClass = "bg-black text-white text-base";
      break;
  }

  const fontWeightClass = isFontSemibold ? "font-semibold" : "font-normal";
  const fullWidth = isFullWidth ? "w-full" : "";

  return (
    <>
      <button
        onClick={action}
        type={type}
        className={`${rounded} ${fullWidth} flex flex-row hover:cursor-pointer justify-center items-center gap-3 ${buttonClass} ${fontWeightClass} text-center py-0`}
        style={{ width: width, height: height, fontSize: fontSize }}
      >
        {icon && <FontAwesomeIcon icon={icon} style={{ fontSize: iconSize }} />}
        <div>{text}</div>
      </button>
    </>
  );
};
export default Button;
