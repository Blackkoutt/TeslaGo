import { IconDefinition } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useState } from "react";

interface SocialMediaIconProps {
  icon: IconDefinition;
  iconSize: number;
  linkTo: string;
  title: string;
  hoverBgColor: string;
  hoverTextColor?: string;
  center?: boolean;
  width?: number;
  height?: number;
  isBordered?: boolean;
}
const SocialMediaIcon = ({
  icon,
  iconSize,
  linkTo,
  title,
  hoverBgColor,
  hoverTextColor = "#fff",
  center = true,
  width = 55,
  height = 55,
  isBordered = false,
}: SocialMediaIconProps) => {
  const [isHovering, setIsHovering] = useState(false);

  return (
    <a
      href={linkTo}
      target="_blank"
      title={title}
      className={`flex ${
        center ? "items-center" : "items-end"
      } justify-center rounded-full bg-black ${
        isBordered ? "border-3 border-black" : ""
      }`}
      style={{
        width: width,
        height: height,
        transition: "color 0.3s ease",
      }}
      onMouseEnter={(e) => {
        e.currentTarget.style.background = hoverBgColor;
        e.currentTarget.style.cursor = "pointer";
        setIsHovering(true);
      }}
      onMouseLeave={(e) => {
        e.currentTarget.style.background = "#000000";
        setIsHovering(false);
      }}
    >
      <FontAwesomeIcon
        icon={icon}
        color={isHovering ? hoverTextColor : "white"}
        fontSize={iconSize}
      />
    </a>
  );
};
export default SocialMediaIcon;
