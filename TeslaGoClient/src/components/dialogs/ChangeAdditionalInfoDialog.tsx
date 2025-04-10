import { FormEvent, forwardRef, useEffect, useState } from "react";
import Dialog from "../common/Dialog";
import { FormProvider, SubmitHandler, useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import useApi from "../../hooks/useApi";
import {
  faAddressCard,
  faCity,
  faDoorClosed,
  faEnvelope,
  faHouse,
  faPhone,
  faSignsPost,
} from "@fortawesome/free-solid-svg-icons";
import { UserDataRequest, userDataRequestSchema } from "../../models/create_schemas/UserDataSchema";
import { User } from "../../models/response_models/User";
import { ApiEndpoint } from "../../config/enums/ApiEndpointEnum";
import { HTTPStatusCode } from "../../helpers/enums/HttpStatusCodeEnum";
import Input from "../forms/Input";
import { validateCityName, validateStreetName } from "../../helpers/InputHelpers";
import Button, { ButtonStyle } from "../common/Button";

interface ChangeAdditionalInfoDialogProps {
  user: User;
  reloadComponent: () => void;
}

export const ChangeAdditionalInfoDialog = forwardRef<HTMLDialogElement, ChangeAdditionalInfoDialogProps>(
  ({ user, reloadComponent }: ChangeAdditionalInfoDialogProps, ref) => {
    const { statusCode: statusCode, put: putInfo } = useApi<User, undefined, UserDataRequest>(
      ApiEndpoint.UserInfo
    );
    const [actionPerformed, setActionPerformed] = useState(false);

    const methods = useForm<UserDataRequest>({
      resolver: zodResolver(userDataRequestSchema),
      defaultValues: {
        drivingLicenseNumber: user.drivingLicenseNumber ?? null,
        street: user.address?.street ?? null,
        houseNumber: user.address?.houseNr ?? null,
        flatNumber: user.address?.flatNr ?? null,
        city: user.address?.city?.name ?? null,
        countryId: user.address?.city?.country?.id ?? null,
        zipCode: user.address?.zipCode ?? null,
      },
    });
    const { handleSubmit, formState, watch, setValue } = methods;
    const { errors, isSubmitting } = formState;

    const onSubmit: SubmitHandler<UserDataRequest> = async (data) => {
      console.log(data);
      await putInfo({ id: undefined, body: data });
      setActionPerformed(true);
    };

    useEffect(() => {
      if (actionPerformed) {
        if (statusCode == HTTPStatusCode.NoContent) {
          reloadComponent();
        }
        setActionPerformed(false);
      }
    }, [actionPerformed]);

    return (
      <Dialog ref={ref}>
        <h3 className="text-center font-semibold text-[24px] py-2">Change your informations</h3>
        <FormProvider {...methods}>
          <form
            className="flex flex-col justify-center items-center gap-3 w-full mt-4 px-8"
            onSubmit={handleSubmit(onSubmit)}
          >
            <div className="grid grid-cols-2 gap-6">
              <div className="flex flex-col justify-center items-center gap-3">
                <Input
                  label="Driving license number"
                  icon={faAddressCard}
                  maxLength={30}
                  name="drivingLicenseNumber"
                  error={errors.drivingLicenseNumber}
                  errorHeight={20}
                />
                <Input
                  icon={faSignsPost}
                  label="Street"
                  type="text"
                  name="street"
                  maxLength={150}
                  onInput={validateStreetName}
                  error={errors.street}
                  errorHeight={20}
                />
                <Input
                  icon={faCity}
                  label="City"
                  maxLength={80}
                  type="text"
                  name="city"
                  onInput={validateCityName}
                  error={errors.city}
                  errorHeight={20}
                />
              </div>
              <div className="flex flex-col justify-center items-center gap-3">
                <Input
                  icon={faHouse}
                  label="House nr"
                  maxLength={25}
                  name="houseNumber"
                  error={errors.houseNumber}
                  errorHeight={20}
                />
                <Input
                  icon={faDoorClosed}
                  label="Flat nr"
                  type="number"
                  onlyInt={true}
                  min={1}
                  max={10000}
                  name="flatNumber"
                  error={errors.flatNumber}
                  errorHeight={20}
                />
                <Input
                  icon={faEnvelope}
                  label="Zipcode"
                  type="zipCode"
                  name="zipCode"
                  error={errors.zipCode}
                  errorHeight={20}
                />
              </div>
            </div>

            <div className="mt-1">
              <Button
                type="submit"
                width={120}
                height={50}
                rounded={999}
                isShadow={true}
                isSubmitting={isSubmitting}
                text="Apply"
                style={ButtonStyle.Primary}
              />
            </div>
          </form>
        </FormProvider>
      </Dialog>
    );
  }
);
