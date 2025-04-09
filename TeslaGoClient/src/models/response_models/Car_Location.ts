import { IModel } from "../abstract/IModel";

export type Car_Location = IModel & {
  fromDate: string;
  location?: Location;
};
