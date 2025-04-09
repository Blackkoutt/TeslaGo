import { IModel } from "../abstract/IModel";

export type DriveType = IModel & {
  name: string;
  description?: string;
};
