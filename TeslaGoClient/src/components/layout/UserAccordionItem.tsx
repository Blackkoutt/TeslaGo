import { IconDefinition } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom";

interface UserAccordionItemProps {
  redirectTo: string;
  icon: IconDefinition;
  text: string;
  iconSize?: number;
  iconColor?: string;
  onClick?: () => void;
}

export const UserAccordionItem = ({
  icon,
  redirectTo,
  text,
  iconSize = 22,
  iconColor = "#00a63e",
  onClick,
}: UserAccordionItemProps) => {
  return (
    <Link to={redirectTo}>
      <div
        onClick={() => onClick?.()}
        className="flex flex-row w-full justify-start items-center gap-4 pt-3 pl-2 pb-4 mt-2 cursor-pointer rounded-sm hover:bg-userMenuHover border-b-[1px] border-dashed border-primaryGreen"
      >
        <FontAwesomeIcon icon={icon} fontSize={iconSize} color={iconColor} />
        <p className="text-[17px] text-primary">{text}</p>
      </div>
    </Link>
  );
};
