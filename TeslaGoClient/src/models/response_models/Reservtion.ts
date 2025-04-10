import { IModel } from "../abstract/IModel";
import { Car } from "./Car";
import { CarModel } from "./CarModel";
import { OptService } from "./OptService";
import { PaymentMethod } from "./PaymentMethod";
import { User } from "./User";
import { Location as CarLocation } from "../response_models/Location";

export type Reservation = IModel & {
  reservationDate: string;
  startDate: string;
  endDate: string;
  totalCost: number;
  user: User;
  carModel: CarModel;
  reservationStatus: string;
  car?: Car;
  paymentMethod?: PaymentMethod;
  optServices: OptService[];
  pickupLocation: CarLocation;
  returnLocation: CarLocation;
  isActive: boolean;
  isExpired: boolean;
};
