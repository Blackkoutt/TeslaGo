import { useEffect, useMemo } from "react";
import { ApiEndpoint } from "../../config/enums/ApiEndpointEnum";
import useApi from "../../hooks/useApi";
import { CarModel } from "../../models/response_models/CarModel";
import { SortDirection } from "../../helpers/enums/SortDirectionEnum";
import { CarModelCard } from "./CarModelCard";

interface CarModelListProps {
  name?: string;
  minPrice?: number;
  maxPrice?: number;
  minRange?: number;
  maxRange?: number;
  brandId?: number;
  gearBoxId?: number;
  fuelTypeId?: number;
  bodyTypeId?: number;
  modelVersionId?: number;
  driveTypeId?: number;
  minHorsePower?: number;
  maxHorsePower?: number;
  minTrunkCapacityLiters?: number;
  maxTrunkCapacityLiters?: number;
  sortBy?: string;
  sortDirection?: SortDirection;
  pageNumber?: number;
  pageSize?: number;
}

export const CarModelList = ({
  name,
  minPrice,
  maxPrice,
  minRange,
  maxRange,
  brandId,
  gearBoxId,
  fuelTypeId,
  bodyTypeId,
  modelVersionId,
  driveTypeId,
  minHorsePower,
  maxHorsePower,
  minTrunkCapacityLiters,
  maxTrunkCapacityLiters,
  sortBy,
  sortDirection = SortDirection.ASC,
  pageNumber,
  pageSize,
}: CarModelListProps) => {
  const { data: carModels, get: getModels } = useApi<CarModel>(ApiEndpoint.CarModel);

  const queryParams = useMemo(
    () => ({
      name,
      minPrice,
      maxPrice,
      minRange,
      maxRange,
      brandId,
      gearBoxId,
      fuelTypeId,
      bodyTypeId,
      modelVersionId,
      driveTypeId,
      minHorsePower,
      maxHorsePower,
      minTrunkCapacityLiters,
      maxTrunkCapacityLiters,
      sortBy,
      sortDirection,
      pageNumber,
      pageSize,
    }),
    [
      name,
      minPrice,
      maxPrice,
      minRange,
      maxRange,
      brandId,
      gearBoxId,
      fuelTypeId,
      bodyTypeId,
      modelVersionId,
      driveTypeId,
      minHorsePower,
      maxHorsePower,
      minTrunkCapacityLiters,
      maxTrunkCapacityLiters,
      sortBy,
      sortDirection,
      pageNumber,
      pageSize,
    ]
  );

  useEffect(() => {
    getModels({ id: undefined, queryParams: queryParams });
  }, [queryParams]);

  return (
    <>
      <div className="grid grid-cols-2 3xl:grid-cols-3 gap-6">
        {carModels.map((model) => (model ? <CarModelCard key={model.id} model={model} /> : null))}
      </div>
    </>
  );
};
