import { forwardRef } from "react";
import { Reservation } from "../../models/response_models/Reservtion";
import Dialog from "../common/Dialog";
import { LabelText } from "../common/LabelText";
import DateFormatter from "../../helpers/DateFormatter";
import { DateFormat } from "../../helpers/enums/DateFormatEnum";

interface DetailsReservationDialogProps {
  reservation?: Reservation;
}

const DetailsReservationDialog = forwardRef<HTMLDialogElement, DetailsReservationDialogProps>(
  ({ reservation }: DetailsReservationDialogProps, ref) => {
    console.log(reservation?.car);
    return (
      <div>
        {reservation && (
          <Dialog ref={ref}>
            <article className="flex flex-col justify-center items-center pb-2 gap-5 px-12">
              <div className="flex flex-col justify-center items-center gap-2">
                <h2>Rental details</h2>
                <p className="text-textPrimary text-base text-center">
                  Below are the details of the selected rental
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
            </article>
          </Dialog>
        )}
      </div>
    );
  }
);
export default DetailsReservationDialog;
