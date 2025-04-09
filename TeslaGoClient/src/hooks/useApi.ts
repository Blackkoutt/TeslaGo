import { useState, useCallback } from "react";
import ApiClient from "../services/api/ApiClientService";
import { ApiEndpoint } from "../config/enums/ApiEndpointEnum";
import { HTTPMethod } from "../helpers/enums/HTTPMethodEnum";
import { AxiosError } from "axios";
import { APIError } from "../models/error/APIError";
import { toast } from "react-toastify";

interface RequestParams<TPostEntity, TPutEntity> {
  httpMethod: HTTPMethod;
  id?: number | string;
  body?: TPostEntity | TPutEntity;
  queryParams?: Record<string, any>;
}

interface GETRequestParams {
  id?: number | string;
  queryParams?: Record<string, any>;
}
interface POSTRequestParams<TPostEntity> {
  body: TPostEntity;
  id?: number;
}
interface PUTRequestParams<TPutEntity> {
  body: TPutEntity;
  id?: number;
}
interface DELETERequestParams {
  id: number;
}

function useApi<TEntity, TPostEntity = undefined, TPutEntity = undefined>(endpoint: ApiEndpoint) {
  const [data, setData] = useState<TEntity[]>([]);
  const [statusCode, setStatusCode] = useState<number | null>(null);
  const [error, setError] = useState<APIError | null>(null);
  const [loading, setLoading] = useState(false);

  const request = useCallback(
    async ({ httpMethod, id, body, queryParams }: RequestParams<TPostEntity, TPutEntity>) => {
      setLoading(true);
      setError(null);
      try {
        switch (httpMethod) {
          case HTTPMethod.GET:
            const [getData, getCode] = await ApiClient.Get<TEntity[]>(endpoint, queryParams, id);
            let dataArray: TEntity[] = getData as TEntity[];
            if (!Array.isArray(dataArray)) dataArray = [getData as TEntity];
            setData(dataArray);
            setStatusCode(getCode as number);
            break;

          case HTTPMethod.POST:
            const [postData, postCode] = await ApiClient.Post<TEntity, TPostEntity>(
              endpoint,
              body as TPostEntity,
              id
            );

            console.log(postCode);

            setData((prev) => [...prev, postData as TEntity]);
            setStatusCode(postCode as number);
            break;

          case HTTPMethod.PUT:
            const putCode = await ApiClient.Put<TEntity, TPutEntity>(
              endpoint,
              body as TPutEntity,
              id
            );
            console.log("putcode", putCode);
            setStatusCode(putCode as number);
            break;

          case HTTPMethod.DELETE:
            if (id === undefined) throw Error("DELETE Error: id is undefined");
            const deleteCode = await ApiClient.Delete(endpoint, id);
            setStatusCode(deleteCode as number);
            break;
          default:
            throw new Error(`Unsupported HTTP method: ${httpMethod}`);
        }
      } catch (caughtError) {
        if (caughtError instanceof AxiosError) {
          const responseData = caughtError.response?.data || {};
          console.log(caughtError);
          const apiError: APIError = {
            code: responseData.Code || responseData.code,
            title: responseData.Title || responseData.title,
            type: responseData.Type || responseData.type,
            details: responseData.Details || responseData.details,
          };

          console.log("API Error: ", apiError);
          setError(apiError);
          setStatusCode(apiError.code);
          if (apiError.details.errors.length > 0) {
            apiError.details.errors.forEach((error) => {
              toast.error(error);
            });
          }
        }
      } finally {
        setLoading(false);
      }
    },
    [endpoint]
  );

  const get = useCallback(
    ({ id, queryParams }: GETRequestParams): Promise<void> =>
      request({ httpMethod: HTTPMethod.GET, id, queryParams }),
    [request]
  );

  const post = useCallback(
    ({ body, id }: POSTRequestParams<TPostEntity>): Promise<void> =>
      request({ httpMethod: HTTPMethod.POST, id, body }),
    [request]
  );

  const put = useCallback(
    ({ body, id }: PUTRequestParams<TPutEntity>): Promise<void> =>
      request({ httpMethod: HTTPMethod.PUT, id, body }),
    [request]
  );

  const del = useCallback(
    ({ id }: DELETERequestParams): Promise<void> => request({ httpMethod: HTTPMethod.DELETE, id }),
    [request]
  );

  return { data, error, statusCode, loading, get, post, put, del };
}

export default useApi;
