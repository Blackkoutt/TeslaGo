import { IModel } from "../abstract/IModel";
import { Car } from "./Car";
import { CarModel } from "./CarModel";
import { OptService } from "./OptService";
import { PaymentMethod } from "./PaymentMethod";
import { User } from "./User";

export type Reservation = IModel & {
  reservationDate: string;
  startDate: string;
  endDate: string;
  totalCost: number;
  user: User;
  carModel: CarModel;
  car?: Car;
  paymentMethod?: PaymentMethod;
  optServices: OptService[];
  pickupLocation: Location;
  returnLocation: Location;
  isActive: boolean;
  isExpired: boolean;
};
