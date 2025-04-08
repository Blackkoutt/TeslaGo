import { createContext, PropsWithChildren, useContext, useEffect, useState } from "react";
import { User } from "../models/response_models/User";
import { UserLogin } from "../models/response_models/UserLogin";
import { ApiEndpoint } from "../config/enums/ApiEndpointEnum";
import useApi from "../hooks/useApi";
import { UserLoginRequest } from "../models/create_schemas/UserLoginSchema";
import { jwtDecode } from "jwt-decode";
import {
  getUserFormCookie,
  isJWTTokenCookieExist,
  removeJWTTokenCookie,
  setJWTTokenCookie,
} from "../helpers/cookies/JWTCookie";
import { APIError } from "../models/error/APIError";
import { UserRegisterRequest } from "../models/create_schemas/UserRegisterSchema";
import { UserRegister } from "../models/response_models/UserRegister";

type AuthContextType = {
  authenticated?: boolean | null;
  currentUser?: User | null;
  handleLogin: (loginRequest: UserLoginRequest) => Promise<void>;
  handleRegister: (registerRequest: UserRegisterRequest) => Promise<void>;
  performAuthentication: (token?: string, errorMessages?: APIError[]) => void;
  handleLogout: () => void;
};

const AuthContext = createContext<AuthContextType | undefined>(undefined);

type AuthProviderProps = PropsWithChildren;

export const AuthProvider = ({ children }: AuthProviderProps) => {
  const [authenticated, setAuthenticated] = useState<boolean | null>(
    isJWTTokenCookieExist()
  );
  const [currentUser, setCurrentUser] = useState<User | null>(getUserFormCookie());

  // Login in application
  const { data: loginResponse, post: loginUser } = useApi<UserLogin, UserLoginRequest>(
    ApiEndpoint.AuthLogin
  );

  // Register in application
  const { data: registerResponse, post: registerUser } = useApi<
    UserRegister,
    UserRegisterRequest
  >(ApiEndpoint.AuthRegister);

  // Auth Validation
  const {
    data: validatedUser,
    get: validateUser,
    error: validateUserError,
  } = useApi<User>(ApiEndpoint.AuthValidate);

  // Auth Validation
  useEffect(() => {
    if (isJWTTokenCookieExist()) {
      validateUser({ id: undefined, queryParams: undefined });
    } else {
      setAuthenticated(false);
      setCurrentUser(null);
    }
  }, []);

  useEffect(() => {
    console.log(validatedUser[0]);
    if (validateUserError !== null) {
      setAuthenticated(false);
      setCurrentUser(null);
    } else if (validateUser.length !== 0 && validatedUser[0] !== undefined) {
      setAuthenticated(true);
      const user = validatedUser[0];
      setCurrentUser({
        id: user.id,
        name: user.name,
        surname: user.surname,
        emailAddress: user.emailAddress,
        userRoles: user.userRoles,
      });
    }
  }, [validatedUser, validateUserError]);

  // Set Cookie with JWT token if user is Authenticated
  useEffect(() => {
    let token: string | undefined = undefined;
    if (loginResponse.length > 0) {
      token = loginResponse[0].token;
    }
    console.log("token", token);

    performAuthentication(token);
  }, [loginResponse]);

  useEffect(() => {
    let token: string | undefined = undefined;
    if (registerResponse.length > 0) {
      token = registerResponse[0].token;
    }
    console.log("token", token);

    performAuthentication(token);
  }, [registerResponse]);

  const performAuthentication = (token?: string) => {
    if (token !== undefined) {
      const decodedToken = jwtDecode(token);
      console.log(decodedToken);
      const userDecodedToken = decodedToken as User;
      let tokenExpirationDate: Date | undefined = undefined;
      if (decodedToken.exp !== undefined) {
        tokenExpirationDate = new Date(decodedToken.exp * 1000);
      }
      setJWTTokenCookie(token, tokenExpirationDate);
      setAuthenticated(true);
      setCurrentUser({
        id: userDecodedToken.id,
        name: userDecodedToken.name,
        surname: userDecodedToken.surname,
        emailAddress: userDecodedToken.emailAddress,
        userRoles: userDecodedToken.userRoles,
      });
    }
  };

  const handleLogin = async (loginRequest: UserLoginRequest) => {
    await loginUser({ body: loginRequest });
  };

  const handleRegister = async (registerRequest: UserRegisterRequest) => {
    await registerUser({ body: registerRequest });
  };

  const handleLogout = () => {
    setAuthenticated(false);
    setCurrentUser(null);
    removeJWTTokenCookie();
  };

  return (
    <AuthContext.Provider
      value={{
        authenticated,
        currentUser,
        handleLogin,
        handleRegister,
        performAuthentication,
        handleLogout,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);

  if (context === undefined) {
    throw Error("Use auth must be used in AuthProvider");
  }

  return context;
};
