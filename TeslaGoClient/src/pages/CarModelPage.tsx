import { useEffect, useRef, useState } from "react";
import { useParams } from "react-router-dom";
import useApi from "../hooks/useApi";
import { CarModel } from "../models/response_models/CarModel";
import { ApiEndpoint } from "../config/enums/ApiEndpointEnum";
import ApiClient from "../services/api/ApiClientService";
import { LabelText } from "../components/common/LabelText";
import { faCalendarDays, faGasPump, faRoute, faSuitcase, faUser } from "@fortawesome/free-solid-svg-icons";
import car_door from "../assets/car_door.png";
import engine from "../assets/engine.png";
import max_speed from "../assets/max_speed.png";
import acceleration from "../assets/acceleration.png";
import gearbox from "../assets/gearbox.png";
import Button, { ButtonStyle } from "../components/common/Button";
import { GetProductionYears } from "../helpers/GetProductionYears";
import { CarReservationDialog } from "../components/dialogs/CarReservationDialog";

export const CarModelPage = () => {
  const { data: carModels, get: getModels } = useApi<CarModel>(ApiEndpoint.CarModel);
  const [model, setModel] = useState<CarModel>();

  const { carModelId } = useParams();

  const reservationDialog = useRef<HTMLDialogElement>(null);

  useEffect(() => {
    console.log(carModelId);
    if (carModelId != undefined) getModels({ id: carModelId, queryParams: undefined });
  }, [carModelId]);

  useEffect(() => {
    if (carModels && carModels.length > 0) {
      setModel(carModels[0]);
    }
  }, [carModels]);

  console.log(model);

  return (
    <div className="shadow-xl flex flex-col justify-center py-4 px-6 items-center gap-4 w-[50%]">
      <CarReservationDialog
        ref={reservationDialog}
        model={model}
        onDialogClose={() => reservationDialog.current?.close()}
        onDialogConfirm={() => reservationDialog.current?.close()}
      />
      {model?.imageEndpoint && (
        <img
          className="object-cover w-full max-h-[400px]"
          src={ApiClient.GetPhotoEndpoint(model?.imageEndpoint)}
          alt={`${model?.brand.name} ${model?.name} ${model?.modelVersion.name} ${model?.driveType.name} image`}
        />
      )}
      <article className="flex flex-col justify-start items-start w-full">
        <div className="flex flex-row justify-between items-center w-full">
          <div className="flex flex-col justify-center items-start w-full">
            <p className="text-primary pt-1 text-[18px]">{model?.bodyType.name}</p>
            <h4 className="text-[24px] font-semibold text-primaryGreen">{`${model?.brand.name} ${model?.name}`}</h4>
            <p className="text-primary text-[18px]">{`${model?.modelVersion.name} ${model?.driveType.name}`}</p>
          </div>
          <div className="flex flex-row justify-end w-full gap-4 items-center mt-3">
            <LabelText label="Price" textSize={20} isSemibold={true} text={`${model?.pricePerDay}$ / day`} />
            <Button
              text={"Rent"}
              width={120}
              fontSize={19}
              isFontSemibold={true}
              height={50}
              rounded={999}
              style={ButtonStyle.Primary}
              action={() => reservationDialog.current?.showModal()}
            />
          </div>
        </div>
        <div className="w-full border-t-[0.2px] mt-3 py-5 border-[#2f2f2f]">
          <p className="text-primary">{model?.carModelDetails.description}</p>
        </div>
        <div className="px-17 flex flex-row w-full justify-between items-center border-y-[0.2px] py-3 border-[#2f2f2f]">
          <div className="flex flex-col gap-3">
            <LabelText
              textSize={18}
              iconSize={28}
              icon={faRoute}
              label="Range"
              text={model?.range}
              unit="km"
            />
            <LabelText textSize={18} iconSize={28} icon={faUser} label="Seats" text={model?.seatCount} />
            <LabelText textSize={18} iconSize={28} image={car_door} label="Doors" text={model?.doorCount} />
            <LabelText
              textSize={18}
              iconSize={28}
              icon={faCalendarDays}
              label="Prod. years"
              text={GetProductionYears(
                model?.carModelDetails.productionStartYear,
                model?.carModelDetails.productionEndYear
              )}
            />
            <LabelText
              textSize={18}
              iconSize={28}
              icon={faGasPump}
              label="Fuel"
              text={model?.fuelType?.name}
            />
          </div>
          <div className="flex flex-col gap-3">
            <LabelText
              textSize={18}
              iconSize={28}
              image={gearbox}
              label="Gearbox"
              text={model?.gearBox?.name}
            />
            <LabelText
              textSize={18}
              iconSize={28}
              image={engine}
              label="Power"
              text={model?.horsePower}
              unit="hp"
            />
            <LabelText
              textSize={18}
              iconSize={28}
              image={max_speed}
              label="Speed"
              text={model?.maxSpeedInKmPerHour}
              unit="km/h"
            />
            <LabelText
              textSize={18}
              iconSize={28}
              image={acceleration}
              label="0-100 km/h"
              text={model?.accelerationInSeconds}
              unit="s"
            />
            <LabelText
              textSize={18}
              iconSize={28}
              icon={faSuitcase}
              label="Trunk"
              text={model?.trunkCapacityLiters}
              unit="l"
            />
          </div>
        </div>
        <div className="mt-3 flex flex-col justify-start items-center w-full">
          <p className="text-primary font-semibold text-[18px]">Equipments: </p>
          <ul className="pl-1">
            {model?.equipments.map((eq) => (
              <li className="mt-3" key={eq.id}>
                <div className="flex flex-row justify-start items-center gap-2">
                  <div className="rounded-[999px] min-w-[10px] min-h-[10px] bg-primaryGreen"></div>
                  <p className="text-primary text-[18px]">{eq.name}</p>
                </div>
              </li>
            ))}
          </ul>
        </div>
      </article>
    </div>
  );
};
