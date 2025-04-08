export type User = {
  id: string;
  name: string;
  surname: string;
  emailAddress: string;
  drivingLicenseNumber?: string;
  dateOfBirth?: string;
  registeredDate?: string;
  userRoles: string[];
};
