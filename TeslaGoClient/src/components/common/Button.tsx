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
  height?: number;
  type?: "button" | "submit" | "reset";
  style: ButtonStyle;
  rounded?: number;
  fontSize?: number;
  isFullWidth?: boolean;
  isFontSemibold?: boolean;
  icon?: IconDefinition;
  iconSize?: number;
  action?: () => void;
  isSubmitting?: boolean;
  py?: number;
}

const Button = (props: ButtonProps) => {
  const {
    text,
    width,
    type = "button",
    rounded = 6,
    height,
    fontSize = 16,
    isFontSemibold = false,
    style,
    action,
    iconSize,
    isFullWidth = false,
    icon,
    isSubmitting = false,
    py = 40,
  } = props;

  let buttonClass = "";
  switch (style) {
    case ButtonStyle.Primary:
      buttonClass = "bg-primaryGreen text-white text-base hover:bg-primaryHoverGreen";
      break;
    case ButtonStyle.Secondary:
      buttonClass =
        "bg-transparent hover:text-gray-800 text-black text-base border-solid border-primaryGreen border-2 hover:border-primaryHoverGreen";
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
        onClick={() => action?.()}
        type={type}
        disabled={isSubmitting}
        className={`${fullWidth} flex flex-row hover:cursor-pointer justify-center items-center gap-3 ${buttonClass} ${fontWeightClass} text-center py-0`}
        style={{
          width: width,
          height: height,
          fontSize: fontSize,
          borderRadius: rounded,
          paddingTop: height == undefined ? py / 2 : undefined,
          paddingBottom: height == undefined ? py / 2 : undefined,
        }}
      >
        {icon && <FontAwesomeIcon icon={icon} style={{ fontSize: iconSize }} />}
        <div> {isSubmitting ? "Ładowanie..." : text}</div>
      </button>
    </>
  );
};
export default Button;
