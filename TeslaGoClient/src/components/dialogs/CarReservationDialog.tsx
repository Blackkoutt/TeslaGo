import { forwardRef, useEffect, useState } from "react";
import { toast } from "react-toastify";
import { FormProvider, SubmitHandler, useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { ApiEndpoint } from "../../config/enums/ApiEndpointEnum";
import useApi from "../../hooks/useApi";
import { SelectOption } from "../../helpers/SelectOption";
import { useAuth } from "../../context/AuthContext";
import Dialog from "../common/Dialog";
import { CarModel } from "../../models/response_models/CarModel";
import { useNavigate } from "react-router-dom";
import { PaymentMethod } from "../../models/response_models/PaymentMethod";
import { OptService } from "../../models/response_models/OptService";
import { setSelectOptions } from "../../helpers/SetSelectOptions";
import { Reservation } from "../../models/response_models/Reservtion";
import { ReservationRequest, reservationSchema } from "../../models/create_schemas/ReservtionSchema";
import { Location as CarLocation } from "../../models/response_models/Location";
import ApiClient from "../../services/api/ApiClientService";
import Select from "../forms/Select";
import { MultiSelect } from "../forms/MultiSelect";
import { DatePicker } from "../forms/DatePicker";
import { LabelText } from "../common/LabelText";
import Button, { ButtonStyle } from "../common/Button";
import {
  calculateDiffrenceInDays,
  calculateTotalPrice,
  getSelectedDatesString,
  getSelectedOptServices,
} from "../../helpers/ReservationHelper";

interface CarReservationDialogProps {
  model?: CarModel;
  onDialogConfirm: () => void;
  onDialogClose: () => void;
}

export const CarReservationDialog = forwardRef<HTMLDialogElement, CarReservationDialogProps>(
  ({ model, onDialogClose, onDialogConfirm }: CarReservationDialogProps, ref) => {
    const { authenticated } = useAuth();
    const { post: createReservation } = useApi<Reservation, ReservationRequest>(ApiEndpoint.Reservation);

    const { data: paymentMethods, get: getPaymentMethods } = useApi<PaymentMethod>(ApiEndpoint.PaymentMethod);
    const [paymentMethodsSelectOptions, setPaymentMethodsSelectOptions] = useState<SelectOption[]>([]);

    const { data: optServices, get: getOptServices } = useApi<OptService>(ApiEndpoint.OptService);
    const [optServicesSelectOptions, setOptServicesSelectOptions] = useState<SelectOption[]>([]);

    const { data: locations, get: getLocations } = useApi<CarLocation>(ApiEndpoint.Location);
    const [locationselectOptions, setLocationsSelectOptions] = useState<SelectOption[]>([]);

    const [totalPrice, setTotalPrice] = useState<number>(0);
    const [totalOptServicesPrice, setOptServicesTotalPrice] = useState<number>(0);
    const [selectedDates, setSelectedDates] = useState<string>("");
    const [selectedPickupLocation, setSelectedPickupLocation] = useState<CarLocation>();
    const [selectedReturnLocation, setSelectedReturnLocation] = useState<CarLocation>();
    const [selectedPaymentMethod, setSelectedPaymentMethod] = useState<PaymentMethod>();

    useEffect(() => {
      getLocations({ id: undefined, queryParams: undefined });
      getOptServices({ id: undefined, queryParams: undefined });
      getPaymentMethods({ id: undefined, queryParams: undefined });
    }, []);

    useEffect(() => {
      setSelectOptions(locations, setLocationsSelectOptions, "id", "name");
    }, [locations]);

    useEffect(() => {
      setSelectOptions(optServices, setOptServicesSelectOptions, "id", "name");
    }, [optServices]);

    useEffect(() => {
      setSelectOptions(paymentMethods, setPaymentMethodsSelectOptions, "id", "name");
    }, [paymentMethods]);

    const methods = useForm<ReservationRequest>({
      resolver: zodResolver(reservationSchema),
    });
    const { handleSubmit, formState, watch } = methods;
    const { errors, isSubmitting } = formState;

    console.log(errors);

    const startDate = watch().startDate;
    const endDate = watch().endDate;
    const optServicesIds = watch().optServicesIds;
    const pickupLocationId = watch().pickupLocationId;
    const returnLocationId = watch().returnLocationId;
    const paymentMethodId = watch().paymentMethodId;

    useEffect(() => {
      const pickupLocation = locations.find((x) => x.id == pickupLocationId);
      if (pickupLocation != undefined) setSelectedPickupLocation(pickupLocation);
    }, [pickupLocationId]);

    useEffect(() => {
      const returnLocation = locations.find((x) => x.id == returnLocationId);
      if (returnLocation != undefined) setSelectedReturnLocation(returnLocation);
    }, [returnLocationId]);

    useEffect(() => {
      const paymentMethod = paymentMethods.find((x) => x.id == paymentMethodId);
      if (paymentMethod != undefined) setSelectedPaymentMethod(paymentMethod);
    }, [paymentMethodId]);

    useEffect(() => {
      const { totalCost, optServicesTotalPrice } = calculateTotalPrice(
        model,
        startDate,
        endDate,
        optServicesIds,
        optServices
      );
      setTotalPrice(totalCost);
      setOptServicesTotalPrice(optServicesTotalPrice);
    }, [startDate, endDate, optServicesIds]);

    useEffect(() => {
      const dateString = getSelectedDatesString(startDate, endDate);
      setSelectedDates(dateString);
    }, [startDate, endDate]);

    const onSubmit: SubmitHandler<ReservationRequest> = async (data) => {
      if (model != null && model != undefined) {
        if (authenticated) {
          data.carModelId = model.id;
          await toast.promise(createReservation({ body: data }), {
            success: "Your reservation has been successfully created.",
            pending: "Processing your reservation...",
            error: "Something went wrong while creating your reservation.",
          });
          onDialogClose();
        } else {
          toast.error("Sign in to rent a car");
        }
      }
    };

    return (
      <div className="h-full">
        {model && (
          <Dialog ref={ref} minWidth={900}>
            <FormProvider {...methods}>
              <form onSubmit={handleSubmit(onSubmit)}>
                <div className="flex flex-col justify-center items-center gap-2 px-8">
                  <h2 className="my-3">Rent a car</h2>
                  <div className="flex flex-row justify-center items-center gap-10">
                    <div className="flex flex-col justify-center items-center">
                      <img
                        className="object-cover w-full max-h-[200px]"
                        src={ApiClient.GetPhotoEndpoint(model?.imageEndpoint)}
                      />
                      <div className="flex flex-col justify-center items-start w-full">
                        <p className="text-primary pt-1 text-[18px]">{model?.bodyType.name}</p>
                        <h4 className="text-[24px] font-semibold text-primaryGreen">{`${model?.brand.name} ${model?.name}`}</h4>
                        <p className="text-primary text-[18px]">{`${model?.modelVersion.name} ${model?.driveType.name}`}</p>
                      </div>
                    </div>
                    <div className="flex flex-col justify-center items-center w-[550px] max-w-[550px]">
                      <div className="grid grid-cols-2 justify-center items-start gap-5 py-3 w-full">
                        <div className="flex flex-col justify-center gap-[6px] items-center">
                          <DatePicker
                            label="Start date"
                            name="startDate"
                            isTime={true}
                            error={errors.startDate}
                          />
                          <DatePicker label="End date" name="endDate" isTime={true} error={errors.endDate} />
                          <Select
                            label="Pickup location"
                            name="pickupLocationId"
                            optionValues={locationselectOptions}
                          />
                        </div>
                        <div className="flex flex-col justify-center gap-[6px] items-center">
                          <Select
                            label="Return location"
                            name="returnLocationId"
                            optionValues={locationselectOptions}
                          />
                          <Select
                            label="Payment method"
                            name="paymentMethodId"
                            optionValues={paymentMethodsSelectOptions}
                          />
                          <MultiSelect
                            label="Opt Services"
                            maxSelectedItemsHeight={40}
                            name="optServicesIds"
                            optionValues={optServicesSelectOptions}
                            error={errors.optServicesIds}
                          />
                        </div>
                      </div>
                    </div>
                  </div>
                  <div className="border-t-[0.2px] pt-2 mt-2 border-[#2f2f2f] gap-3 w-full flex flex-col justify-center items-start">
                    <h3 className="text-primary font-semibold text-[24px]">Summary</h3>
                    <LabelText
                      textSize={18}
                      isLabelSemibold={true}
                      label="Renting car"
                      text={`${model.brand.name} ${model.name} ${model.modelVersion.name} ${model.driveType.name}`}
                    />
                    <LabelText
                      textSize={18}
                      label="Time period"
                      isLabelSemibold={true}
                      text={selectedDates}
                    />
                    <LabelText
                      textSize={18}
                      isLabelSemibold={true}
                      label="Pickup location"
                      text={selectedPickupLocation ? selectedPickupLocation.name : ""}
                    />
                    <LabelText
                      textSize={18}
                      isLabelSemibold={true}
                      label="Return location"
                      text={selectedReturnLocation ? selectedReturnLocation.name : ""}
                    />
                    <LabelText
                      textSize={18}
                      isLabelSemibold={true}
                      label="Payment method"
                      text={selectedPaymentMethod ? selectedPaymentMethod.name : ""}
                    />
                    <LabelText
                      textSize={18}
                      isLabelSemibold={true}
                      label="Total optional services price"
                      text={totalOptServicesPrice}
                      unit="$"
                    />
                    <LabelText
                      textSize={24}
                      isSemibold={true}
                      label="Total price"
                      text={totalPrice}
                      unit="$"
                    />
                  </div>
                </div>
                <div className="flex flex-row self-center justify-center items-center gap-5 pt-2">
                  <Button
                    text="Cancel"
                    width={140}
                    height={45}
                    rounded={999}
                    isShadow={true}
                    iconSize={18}
                    style={ButtonStyle.DefaultGray}
                    action={onDialogClose}
                  />
                  <Button
                    type="submit"
                    isSubmitting={isSubmitting}
                    text="Rent car"
                    width={140}
                    height={45}
                    isShadow={true}
                    rounded={999}
                    style={ButtonStyle.Primary}
                  />
                </div>
              </form>
            </FormProvider>
          </Dialog>
        )}
      </div>
    );
  }
);
