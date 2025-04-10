import { useOutletContext } from "react-router-dom";
import { User } from "../../models/response_models/User";
import Button, { ButtonStyle } from "../../components/common/Button";
import { faPenToSquare } from "@fortawesome/free-solid-svg-icons";
import { useRef } from "react";
import { LabelText } from "../../components/common/LabelText";
import { DateFormat } from "../../helpers/enums/DateFormatEnum";
import DateFormatter from "../../helpers/DateFormatter";
import { ChangeAdditionalInfoDialog } from "../../components/dialogs/ChangeAdditionalInfoDialog";

interface OutletContextProps {
  user: User;
  reloadAdditonalInfoComponent: () => void;
}

const UserAdditionalInfoPage = () => {
  const { user, reloadAdditonalInfoComponent } = useOutletContext<OutletContextProps>();
  const dialogRef = useRef<HTMLDialogElement | null>(null);

  const reloadComponent = () => {
    dialogRef.current?.close();
    reloadAdditonalInfoComponent();
  };

  console.log(user);

  return user ? (
    <article className="flex flex-col justify-start items-start p-4">
      <h3 className="font-bold text-[27px] pb-4">Additional info</h3>
      <div className="flex flex-col justify-start items-start gap-4">
        <LabelText
          label="Driving license nr"
          text={user.drivingLicenseNumber}
          textSize={18}
          isLabelSemibold={true}
        />
        <LabelText
          label="Register date"
          text={DateFormatter.FormatDate(user.registeredDate, DateFormat.Date)}
          textSize={18}
          isLabelSemibold={true}
        />
        <LabelText label="Street" text={user.address?.street} textSize={18} isLabelSemibold={true} />
        <LabelText label="House nr" text={user.address?.houseNr} textSize={18} isLabelSemibold={true} />
        <LabelText label="Flat nr" text={user.address?.flatNr} textSize={18} isLabelSemibold={true} />
        <LabelText label="City" text={user.address?.city?.name} textSize={18} isLabelSemibold={true} />
        <LabelText label="Zipcode" text={user.address?.zipCode} textSize={18} isLabelSemibold={true} />
        <LabelText
          label="Country"
          text={user.address?.city?.country?.name}
          textSize={18}
          isLabelSemibold={true}
        />
      </div>
      <ChangeAdditionalInfoDialog ref={dialogRef} user={user} reloadComponent={reloadComponent} />
      <div className="mt-5">
        <Button
          text="Edit"
          width={130}
          height={50}
          rounded={999}
          iconSize={20}
          fontSize={16}
          isFontSemibold={true}
          style={ButtonStyle.Primary}
          icon={faPenToSquare}
          action={() => dialogRef.current?.showModal()}
        />
      </div>
    </article>
  ) : (
    ""
  );
};
export default UserAdditionalInfoPage;
