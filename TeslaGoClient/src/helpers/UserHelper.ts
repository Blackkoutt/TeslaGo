import { User } from "../models/response_models/User";
import { Roles } from "./enums/UserRoleEnum";

export const isUserInRole = (user: User | null | undefined, role: Roles) => {
  if (user === null || user === undefined || user.userRoles === undefined) return false;
  if (!Array.isArray(user.userRoles)) return user.userRoles === role;
  return user.userRoles.includes(role);
};
