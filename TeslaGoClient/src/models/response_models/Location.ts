import { IModel } from "../abstract/IModel";
import { Address } from "./Address";

export type Location = IModel & {
  name: string;
  address?: Address;
};
