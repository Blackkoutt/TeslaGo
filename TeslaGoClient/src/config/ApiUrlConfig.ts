import { ApiEndpoint } from "./enums/ApiEndpointEnum";

export const ApiUrlConfig = {
  [ApiEndpoint.AuthRegister]: {
    url: (id?: number | string) => "/auth/register",
  },
  [ApiEndpoint.AuthLogin]: {
    url: (id?: number | string) => "/auth/login",
  },
  [ApiEndpoint.AuthValidate]: {
    url: (id?: number | string) => "/auth/validate",
  },
  [ApiEndpoint.CarModel]: {
    url: (id?: number | string) => "/carmodels",
  },
  [ApiEndpoint.Reservation]: {
    url: (id?: number | string) => "/reservations",
  },
  [ApiEndpoint.PaymentMethod]: {
    url: (id?: number | string) => "/paymentmethods",
  },
  [ApiEndpoint.OptService]: {
    url: (id?: number | string) => "/optservices",
  },
  [ApiEndpoint.Location]: {
    url: (id?: number | string) => "/locations",
  },
};
