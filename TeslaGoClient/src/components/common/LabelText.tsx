import { IconDefinition } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

interface LabelTextProps {
  icon?: IconDefinition;
  image?: string;
  label: string;
  text: string | number | undefined | null;
  iconSize?: number;
  color?: string;
  textColor?: string;
  textSize?: number;
  isSemibold?: boolean;
}

export const LabelText = ({
  icon,
  label,
  text,
  iconSize = 18,
  textColor,
  image,
  isSemibold = false,
  textSize = 16,
  color = "#00a63e",
}: LabelTextProps) => {
  return (
    <div className="flex flex-row justify-start items-center gap-2">
      {icon && <FontAwesomeIcon icon={icon} color={color} fontSize={iconSize} />}
      {image && <img src={image} width={iconSize} />}
      <p
        style={{
          color: textColor ? textColor : "#2f2f2f",
          fontSize: textSize,
          fontWeight: isSemibold ? 600 : 400,
        }}
      >{`${label}: ${text != undefined && text != null ? text : "No data"}`}</p>
    </div>
  );
};
