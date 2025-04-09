import { CarModel } from "../../models/response_models/CarModel";
import ApiClient from "../../services/api/ApiClientService";

interface CarModelCardProps {
  model: CarModel;
}

export const CarModelCard = ({ model }: CarModelCardProps) => {
  return (
    <div className="flex flex-col">
      <img
        className="object-cover w-full max-h-[189px]"
        src={ApiClient.GetPhotoEndpoint(model.imageEndpoint)}
        alt={`${model.brand.name} ${model.name} ${model.modelVersion.name} ${model.driveType.name} image`}
      />
      <p>
        {`${model.brand.name} ${model.name} ${model.modelVersion.name} ${model.driveType.name}`}
      </p>
    </div>
  );
};
