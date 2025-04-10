import { forwardRef, useEffect, useState } from "react";
import { faCheck, faXmark } from "@fortawesome/free-solid-svg-icons";
import { toast } from "react-toastify";
import { Reservation } from "../../models/response_models/Reservtion";
import useApi from "../../hooks/useApi";
import { ApiEndpoint } from "../../config/enums/ApiEndpointEnum";
import { HTTPStatusCode } from "../../helpers/enums/HttpStatusCodeEnum";
import Dialog from "../common/Dialog";
import { LabelText } from "../common/LabelText";
import { DateFormat } from "../../helpers/enums/DateFormatEnum";
import DateFormatter from "../../helpers/DateFormatter";
import Button, { ButtonStyle } from "../common/Button";

interface CancelReservationDialogProps {
  reservation?: Reservation;
  onDialogConfirm: () => void;
  onDialogClose: () => void;
}

const CancelReservationDialog = forwardRef<HTMLDialogElement, CancelReservationDialogProps>(
  ({ reservation, onDialogClose, onDialogConfirm }: CancelReservationDialogProps, ref) => {
    const { del: cancelReservation, statusCode: statusCode } = useApi<Reservation>(ApiEndpoint.Reservation);
    const [actionPerformed, setActionPerformed] = useState(false);
    const [promisePending, setPromisePending] = useState(false);

    const onCancelReservation = async () => {
      if (reservation !== undefined) {
        setPromisePending(true);
        await toast.promise(cancelReservation({ id: reservation.id }), {
          pending: "Processing request",
          success: "Rent has been successfully canceled",
          error: "An error occurred while canceling the rent",
        });
        setPromisePending(false);
        setActionPerformed(true);
      }
    };

    useEffect(() => {
      if (actionPerformed) {
        if (statusCode == HTTPStatusCode.NoContent) {
          onDialogConfirm();
        }
        setActionPerformed(false);
      }
    }, [actionPerformed]);

    return (
      <div>
        {reservation && (
          <Dialog ref={ref}>
            <article className="flex flex-col justify-center items-center gap-5 px-12">
              <div className="flex flex-col justify-center items-center gap-2">
                <h2>Rent cancel</h2>{" "}
                <p className="text-textPrimary text-base text-center text-[17px]">
                  Are you sure you want to cancel this rent ?
                </p>
              </div>
              <div className="grid grid-cols-2 justify-center items-center gap-12">
                <div className="flex flex-col justify-start items-start gap-5">
                  <LabelText isLabelSemibold={true} textSize={18} label="ID" text={reservation.id} />
                  <LabelText
                    isLabelSemibold={true}
                    textSize={18}
                    label="Start date"
                    text={DateFormatter.FormatDate(reservation.startDate, DateFormat.DateTime)}
                  />
                  <LabelText
                    isLabelSemibold={true}
                    textSize={18}
                    label="End date"
                    text={DateFormatter.FormatDate(reservation.endDate, DateFormat.DateTime)}
                  />
                  <LabelText
                    isLabelSemibold={true}
                    textSize={18}
                    label="Model"
                    text={`${reservation.carModel.brand.name} ${reservation.carModel.name} ${reservation.carModel.modelVersion.name} ${reservation.carModel.driveType.name}`}
                  />
                  <LabelText
                    isLabelSemibold={true}
                    textSize={18}
                    label="Registration nr"
                    text={reservation.car?.registrationNr}
                  />
                  <LabelText isLabelSemibold={true} textSize={18} label="VIN" text={reservation.car?.vin} />
                </div>
                <div className="flex flex-col justify-start items-start gap-5">
                  <LabelText
                    isLabelSemibold={true}
                    textSize={18}
                    label="Reservation date"
                    text={DateFormatter.FormatDate(reservation.reservationDate, DateFormat.DateTime)}
                  />
                  <LabelText
                    isLabelSemibold={true}
                    textSize={18}
                    label="Payment method"
                    text={reservation.paymentMethod?.name}
                  />
                  <LabelText
                    isLabelSemibold={true}
                    textSize={18}
                    label="Pickup location"
                    text={reservation.pickupLocation.name}
                  />
                  <LabelText
                    isLabelSemibold={true}
                    textSize={18}
                    label="Return location"
                    text={reservation.returnLocation.name}
                  />
                  <LabelText
                    isLabelSemibold={true}
                    textSize={18}
                    label="Opt services"
                    text={reservation.optServices.map((x) => x.name).join(", ")}
                  />
                  <LabelText
                    isLabelSemibold={true}
                    textSize={18}
                    label="Total cost"
                    text={reservation.totalCost}
                    unit="$"
                  />
                </div>
              </div>
              <div className="flex flex-row justify-center items-center gap-5">
                <Button
                  text="Cancel"
                  width={145}
                  height={45}
                  icon={faXmark}
                  rounded={999}
                  isShadow={true}
                  iconSize={18}
                  style={ButtonStyle.DefaultGray}
                  action={onDialogClose}
                ></Button>
                <Button
                  text={promisePending ? "Loading..." : "Confirm"}
                  rounded={999}
                  width={145}
                  isShadow={true}
                  height={45}
                  icon={faCheck}
                  iconSize={18}
                  style={ButtonStyle.Primary}
                  action={onCancelReservation}
                />
              </div>
            </article>
          </Dialog>
        )}
      </div>
    );
  }
);
export default CancelReservationDialog;
