import { ApiEndpoint } from "./enums/ApiEndpointEnum";

export const ApiUrlConfig = {
  [ApiEndpoint.AuthRegister]: {
    url: (id?: number | string) => `/auth/register`,
  },
  [ApiEndpoint.AuthLogin]: {
    url: (id?: number | string) => `/auth/login`,
  },
  [ApiEndpoint.AuthValidate]: {
    url: (id?: number | string) => `/auth/validate`,
  },
  [ApiEndpoint.AuthInfo]: {
    url: (id?: number | string) => `/auth/info`,
  },
  [ApiEndpoint.CarModel]: {
    url: (id?: number | string) => `/carmodels${id ? `/${id}` : ""}`,
  },
  [ApiEndpoint.Reservation]: {
    url: (id?: number | string) => `/reservations${id ? `/${id}` : ""}`,
  },
  [ApiEndpoint.PaymentMethod]: {
    url: (id?: number | string) => `/paymentmethods${id ? `/${id}` : ""}`,
  },
  [ApiEndpoint.OptService]: {
    url: (id?: number | string) => `/optservices${id ? `/${id}` : ""}`,
  },
  [ApiEndpoint.Location]: {
    url: (id?: number | string) => `/locations${id ? `/${id}` : ""}`,
  },
  [ApiEndpoint.ModelVersion]: {
    url: (id?: number | string) => `/modelversions${id ? `/${id}` : ""}`,
  },
  [ApiEndpoint.BodyType]: {
    url: (id?: number | string) => `/bodytypes${id ? `/${id}` : ""}`,
  },
  [ApiEndpoint.DriveType]: {
    url: (id?: number | string) => `/drivetypes${id ? `/${id}` : ""}`,
  },
  [ApiEndpoint.UserInfo]: {
    url: (id?: number | string) => `/users/info`,
  },
};
