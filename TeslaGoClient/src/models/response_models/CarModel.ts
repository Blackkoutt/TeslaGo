import { IModel } from "../abstract/IModel";
import { BodyType } from "./BodyType";
import { Brand } from "./Brand";
import { CarModelDetails } from "./CarModelDetails";
import { DriveType } from "./DriveType";
import { Equipment } from "./Equipment";
import { FuelType } from "./FuelType";
import { GearBox } from "./GearBox";
import { ModelVersion } from "./ModelVersion";

export type CarModel = IModel & {
  name: string;
  seatCount: number;
  pricePerDay: number;
  range: number;
  allCarsCount: number;
  imageEndpoint: string;
  brand: Brand;
  gearBox?: GearBox;
  fuelType?: FuelType;
  bodyType: BodyType;
  modelVersion: ModelVersion;
  driveType: DriveType;
  carModelDetails: CarModelDetails;
  equipments: Equipment[];
};
