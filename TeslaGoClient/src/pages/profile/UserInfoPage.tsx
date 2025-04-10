import { useOutletContext } from "react-router-dom";
import { User } from "../../models/response_models/User";
import { LabelText } from "../../components/common/LabelText";
import DateFormatter from "../../helpers/DateFormatter";
import { DateFormat } from "../../helpers/enums/DateFormatEnum";

interface OutletContextProps {
  user: User;
  reloadAdditonalInfoComponent: () => void;
}

export const UserInfoPage = () => {
  const { user } = useOutletContext<OutletContextProps>();

  return user ? (
    <article className="flex flex-col justify-start items-start p-4">
      <h3 className="font-bold text-[27px] pb-4">General user info</h3>
      <div className="flex flex-col justify-start items-start gap-4">
        <LabelText label="Name" text={user.name} textSize={18} isLabelSemibold={true} />
        <LabelText label="Surname" text={user.surname} textSize={18} isLabelSemibold={true} />
        <LabelText label="E-mail" text={user.emailAddress} textSize={18} isLabelSemibold={true} />
        <LabelText
          label="Birth date"
          text={DateFormatter.FormatDate(user.dateOfBirth, DateFormat.Date)}
          textSize={18}
          isLabelSemibold={true}
        />
        <LabelText label="Roles" text={user.userRoles.join(", ")} textSize={18} isLabelSemibold={true} />
      </div>
    </article>
  ) : (
    ""
  );
};
