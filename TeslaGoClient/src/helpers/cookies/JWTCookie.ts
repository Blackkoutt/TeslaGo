import Cookies from "js-cookie";
import { User } from "../../models/response_models/User";
import { jwtDecode } from "jwt-decode";

const jwtTokenCookieName = "TeslaGoJWTCookie";

export const setJWTTokenCookie = (token: string, expirationDate?: Date): void => {
  const expires = expirationDate || new Date(new Date().getTime() + 7 * 24 * 60 * 60 * 1000);

  Cookies.set(jwtTokenCookieName, token, {
    expires: expires,
    secure: true,
    sameSite: "Strict",
  });
};

export const isJWTTokenCookieExist = () => {
  return Cookies.get(jwtTokenCookieName) !== undefined;
};

export const getUserFormCookie = () => {
  const token = Cookies.get(jwtTokenCookieName);
  if (token === undefined) return null;
  const decodedToken = jwtDecode(token) as User;
  const user: User = {
    id: decodedToken.id,
    name: decodedToken.name,
    surname: decodedToken.surname,
    emailAddress: decodedToken.emailAddress,
    userRoles: decodedToken.userRoles,
  };
  return user;
};

export const removeJWTTokenCookie = (): void => {
  Cookies.remove(jwtTokenCookieName);
};
