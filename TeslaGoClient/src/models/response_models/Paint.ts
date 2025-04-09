import { IModel } from "../abstract/IModel";

export type Paint = IModel & {
  name: string;
  colorHex: string;
};
