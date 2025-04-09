import { IModel } from "../abstract/IModel";

export type GearBox = IModel & {
  name: string;
  numberOfGears: number;
};
