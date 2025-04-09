import { IModel } from "../abstract/IModel";

export type ModelVersion = IModel & {
  name: string;
};
