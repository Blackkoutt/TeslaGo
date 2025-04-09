import { IModel } from "../abstract/IModel";

export type OptService = IModel & {
  name: string;
  price: number;
  description?: string;
};
