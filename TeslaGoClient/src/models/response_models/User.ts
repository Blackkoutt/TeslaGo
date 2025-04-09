import { IModel } from "../abstract/IModel";

export type User = IModel & {
  name: string;
  surname: string;
  emailAddress: string;
  drivingLicenseNumber?: string;
  dateOfBirth?: string;
  registeredDate?: string;
  userRoles: string[];
};
