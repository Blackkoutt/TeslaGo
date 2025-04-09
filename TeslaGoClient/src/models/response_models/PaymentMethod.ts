import { IModel } from "../abstract/IModel";

export type PaymentMethod = IModel & {
  name: string;
};
