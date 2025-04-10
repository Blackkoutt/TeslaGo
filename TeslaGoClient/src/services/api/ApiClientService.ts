import { baseUrl } from "../../config/environment/Environment.ts";
import axios, { AxiosInstance } from "axios";
import { ApiUrlConfig } from "../../config/ApiUrlConfig.ts";
import { ApiEndpoint } from "../../config/enums/ApiEndpointEnum.ts";

export const api: AxiosInstance = axios.create({
  baseURL: baseUrl,
  withCredentials: true,
});

async function Get<TEntity>(endpoint: ApiEndpoint, queryParams?: Record<string, any>, id?: number | string) {
  try {
    console.log("id", id);
    const url = ApiUrlConfig[endpoint].url(id);
    console.log(url);

    const cleanQueryParams = queryParams
      ? Object.fromEntries(Object.entries(queryParams).filter(([_, value]) => value !== undefined))
      : null;

    console.log(cleanQueryParams);

    const queryString = cleanQueryParams ? `?${new URLSearchParams(cleanQueryParams).toString()}` : "";

    let response;
    response = await api.get<TEntity>(url + queryString, {
      withCredentials: true,
    });

    const code = response.status;
    const data = response.data;
    return [data, code];
  } catch (error) {
    throw error;
  }
}

async function Post<TEntity, TPostEntity>(endpoint: ApiEndpoint, body: TPostEntity, id?: number | string) {
  try {
    const url = ApiUrlConfig[endpoint].url(id);

    let response = await api.post<TEntity>(url, body);
    console.log(body);

    const code = response.status;
    const data = response.data;
    return [data, code];
  } catch (error) {
    throw error;
  }
}

async function Put<TEntity, TPutEntity>(endpoint: ApiEndpoint, body: TPutEntity, id?: number | string) {
  try {
    console.log("hello");
    const url = ApiUrlConfig[endpoint].url(id);
    console.log(url);
    let response = await api.put<TEntity>(url, body);

    const code = response.status;
    return code;
  } catch (error) {
    throw error;
  }
}

async function Delete<TEntity>(endpoint: ApiEndpoint, id: number | string) {
  try {
    const url = ApiUrlConfig[endpoint].url(id);

    const response = await api.delete<TEntity>(url);
    const code = response.status;
    return code;
  } catch (error) {
    throw error;
  }
}

const GetPhotoEndpoint = (photoEndpoint?: string): string => {
  return photoEndpoint ? `${baseUrl}${photoEndpoint}` : "";
};

const ApiMethod = {
  Get,
  Post,
  Put,
  Delete,
  GetPhotoEndpoint,
};

export default ApiMethod;
