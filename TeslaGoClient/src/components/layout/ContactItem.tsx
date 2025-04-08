import { IconDefinition } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

interface ContactItemProps {
  icon: IconDefinition;
  header: string;
  text: string;
  iconSize?: number;
}
export const ContactItem = ({ icon, header, text, iconSize = 28 }: ContactItemProps) => {
  return (
    <div className="flex flex-row items-start justify-start gap-4 w-full">
      <div className="min-w-[36px] text-center">
        <FontAwesomeIcon icon={icon} fontSize={iconSize} color="#00a63e" />
      </div>
      <div className="flex flex-col justify-start items-start gap-1">
        <p className="font-semibold text-black text-[17px]">{header}</p>
        <p
          className="text-[15px] text-textPrimary"
          dangerouslySetInnerHTML={{ __html: text }}
        ></p>
      </div>
    </div>
  );
};
