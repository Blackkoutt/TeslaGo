import { IModel } from "../abstract/IModel";
import { Country } from "./Contry";

export type City = IModel & {
  name: string;
  country: Country;
};
