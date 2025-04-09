import { IModel } from "../abstract/IModel";
import { City } from "./City";

export type Address = IModel & {
  street: string;
  houseNr: string;
  flatNr?: number;
  zipCode: string;
  city: City;
};
