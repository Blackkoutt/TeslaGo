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
  isLabelSemibold?: boolean;
  unit?: string;
}

export const LabelText = ({
  icon,
  label,
  text,
  iconSize = 18,
  textColor,
  image,
  isSemibold = false,
  isLabelSemibold = false,
  textSize = 16,
  color = "#00a63e",
  unit,
}: LabelTextProps) => {
  return (
    <div className="flex flex-row justify-start items-center gap-2">
      {icon && <FontAwesomeIcon icon={icon} color={color} fontSize={iconSize} />}
      {image && <img src={image} width={iconSize} />}
      <div
        className="flex flex-row justify-start items-center gap-1"
        style={{
          color: textColor ? textColor : "#2f2f2f",
          fontSize: textSize,
          fontWeight: isSemibold ? 600 : 400,
        }}
      >
        <p style={{ fontWeight: isLabelSemibold || isSemibold ? 600 : 400 }}>{label}:</p>
        <p>{text != undefined && text != null ? `${text} ${unit ? unit : ""}` : "No data"}</p>
      </div>
    </div>
  );
};
