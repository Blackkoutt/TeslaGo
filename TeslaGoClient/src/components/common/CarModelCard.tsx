import { Link } from "react-router-dom";
import { CarModel } from "../../models/response_models/CarModel";
import ApiClient from "../../services/api/ApiClientService";
import { faRoute, faSuitcase, faUser } from "@fortawesome/free-solid-svg-icons";
import { LabelText } from "./LabelText";
import car_door from "../../assets/car_door.png";
import engine from "../../assets/engine.png";
import max_speed from "../../assets/max_speed.png";
import Button, { ButtonStyle } from "./Button";

interface CarModelCardProps {
  model: CarModel;
}

export const CarModelCard = ({ model }: CarModelCardProps) => {
  return (
    <Link
      to={`/fleet/${model.id}`}
      className="shadow-xl flex flex-col justify-center py-4 px-6 items-center gap-4 hover:bg-slate-50 hover:cursor-pointer"
    >
      <img
        className="object-cover w-full "
        src={ApiClient.GetPhotoEndpoint(model.imageEndpoint)}
        alt={`${model.brand.name} ${model.name} ${model.modelVersion.name} ${model.driveType.name} image`}
      />
      <article className="flex flex-col justify-start items-start w-full">
        <p className="text-primary pt-1">{model.bodyType.name}</p>
        <h4 className="text-[22px] font-semibold text-primaryGreen">{`${model.brand.name} ${model.name}`}</h4>
        <p className="text-primary"> {`${model.modelVersion.name} ${model.driveType.name}`}</p>
        <div className="px-2 flex flex-row w-full justify-between items-center border-y-[0.2px] mt-3 py-3 border-[#2f2f2f]">
          <div className="flex flex-col gap-2">
            <LabelText icon={faRoute} label="Range" text={`${model.range} km`} />
            <LabelText icon={faUser} label="Seats" text={model.seatCount} />
            <LabelText image={car_door} label="Doors" text={model.doorCount} />
          </div>
          <div className="flex flex-col gap-2">
            <LabelText image={engine} label="Power" text={`${model.horsePower} hp`} />
            <LabelText image={max_speed} label="Speed" text={`${model.maxSpeedInKmPerHour} km/h`} />
            <LabelText icon={faSuitcase} label="Trunk" text={`${model.trunkCapacityLiters} l`} />
          </div>
        </div>
        <div className="flex flex-row justify-between w-full items-center mt-3">
          <LabelText
            label="Price"
            textSize={20}
            isSemibold={true}
            text={`${model.pricePerDay}$ / day`}
          />
          <Button text={"Rent"} width={120} height={40} rounded={999} style={ButtonStyle.Primary} />
        </div>
      </article>
    </Link>
  );
};
