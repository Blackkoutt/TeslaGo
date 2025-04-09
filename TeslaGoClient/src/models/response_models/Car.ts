import { IModel } from "../abstract/IModel";
import { Car_Location } from "./Car_Location";
import { CarModel } from "./CarModel";
import { Paint } from "./Paint";

export type Car = IModel & {
  VIN: string;
  registrationNr: string;
  model?: CarModel;
  paint?: Paint;
  locations: Car_Location;
  actualLocation?: Location;
};
