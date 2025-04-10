import { IModel } from "../abstract/IModel";
import { Address } from "./Address";

export type User = IModel & {
  name: string;
  surname: string;
  emailAddress: string;
  drivingLicenseNumber?: string;
  dateOfBirth?: string;
  registeredDate?: string;
  address?: Address;
  userRoles: string[];
};
