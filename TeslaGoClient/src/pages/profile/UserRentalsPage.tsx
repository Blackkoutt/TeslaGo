import { useEffect, useRef, useState } from "react";
import useApi from "../../hooks/useApi";
import { DataTable } from "primereact/datatable";
import { Column, ColumnBodyOptions } from "primereact/column";
import DateFormatter from "../../helpers/DateFormatter";
import { DateFormat } from "../../helpers/enums/DateFormatEnum";
import { faInfoCircle, faTrash } from "@fortawesome/free-solid-svg-icons";
import { Reservation } from "../../models/response_models/Reservtion";
import { ApiEndpoint } from "../../config/enums/ApiEndpointEnum";
import TableActionButton from "../../components/table/TableActionButton";
import { Status } from "../../helpers/enums/Status";
import StatusBody from "../../components/table/StatusBody";
import CancelReservationDialog from "../../components/dialogs/CancelReservationDialog";
import DetailsReservationDialog from "../../components/dialogs/DetailsReservationDialog";

const UserRentalsPage = () => {
  const { data: reservations, get: getReservations } = useApi<Reservation>(ApiEndpoint.Reservation);
  const cancelReservationDialog = useRef<HTMLDialogElement>(null);
  const detailsReservationDialog = useRef<HTMLDialogElement>(null);

  const [reservationToCancel, setReservationToCancel] = useState<Reservation | undefined>(undefined);
  const [reservationToDetails, setReservationToDetails] = useState<Reservation | undefined>(undefined);

  useEffect(() => {
    getReservations({ id: undefined, queryParams: undefined });
  }, []);

  useEffect(() => {
    if (reservationToCancel != undefined) {
      cancelReservationDialog.current?.showModal();
    }
  }, [reservationToCancel]);

  useEffect(() => {
    if (reservationToDetails != undefined) {
      detailsReservationDialog.current?.showModal();
    }
  }, [reservationToDetails]);

  const reloadReservationsAfterSuccessDialog = () => {
    cancelReservationDialog.current?.close();
    setReservationToCancel(undefined);
    getReservations({ id: undefined, queryParams: undefined });
  };

  const actionsTemplate = (rowData: Reservation, options: ColumnBodyOptions) => {
    return (
      <div className="flex flex-row justify-start items-start gap-3">
        <TableActionButton
          icon={faInfoCircle}
          buttonColor="#f97316"
          text="Details"
          onClick={() => {
            setReservationToDetails(rowData);
            detailsReservationDialog.current?.showModal();
          }}
        />
        {rowData.reservationStatus === Status.Active && (
          <TableActionButton
            icon={faTrash}
            buttonColor="#ef4444"
            text="Cancel"
            onClick={() => {
              setReservationToCancel(rowData);
              cancelReservationDialog.current?.showModal();
            }}
          />
        )}
      </div>
    );
  };

  return (
    <div className="w-full px-5 self-center">
      <CancelReservationDialog
        ref={cancelReservationDialog}
        reservation={reservationToCancel}
        onDialogClose={() => cancelReservationDialog.current?.close()}
        onDialogConfirm={reloadReservationsAfterSuccessDialog}
      />
      <DetailsReservationDialog ref={detailsReservationDialog} reservation={reservationToDetails} />
      <DataTable
        value={reservations}
        paginator
        removableSort
        rows={5}
        rowsPerPageOptions={[5, 10, 25, 50]}
        stripedRows
        showGridlines
      >
        <Column field="id" sortable header="ID"></Column>
        <Column
          field="reservationDate"
          sortable
          header="Reservation date"
          body={(rowData) => DateFormatter.FormatDate(rowData.reservationDate, DateFormat.DateTime)}
        />
        <Column
          field="startDate"
          sortable
          header="Start date"
          body={(rowData) => DateFormatter.FormatDate(rowData.startDate, DateFormat.DateTime)}
        />
        <Column
          field="endDate"
          sortable
          header="End date"
          body={(rowData) => DateFormatter.FormatDate(rowData.endDate, DateFormat.DateTime)}
        />
        <Column field="totalCost" sortable header="Total cost ($)" />
        <Column
          field="carModel.Name"
          body={(rowData) =>
            `${rowData.carModel.brand.name} ${rowData.carModel.name} ${rowData.carModel.modelVersion.name} ${rowData.carModel.driveType.name}`
          }
          header="Model name"
        />
        <Column
          header="Status"
          body={(rowData) => (
            <StatusBody
              status={rowData.reservationStatus}
              activeStatusText="Active rent"
              expiredStatusText="Ended rent"
              deletedStatusText="Canceled rent"
              unknownStatusText="Unknown status"
            />
          )}
        ></Column>
        <Column header="Action" body={actionsTemplate}></Column>
      </DataTable>
    </div>
  );
};
export default UserRentalsPage;
