import { useEffect, useState } from "react";
import { ApiEndpoint } from "../config/enums/ApiEndpointEnum";
import useApi from "../hooks/useApi";
import { User } from "../models/response_models/User";
import { ProfilePhoto } from "../components/profile/ProfilePhoto";
import TabButton from "../components/profile/TabButton";
import { Outlet } from "react-router-dom";

export const ProfilePage = () => {
  const { data: info, get: getInfo } = useApi<User>(ApiEndpoint.AuthInfo);

  const [user, setUser] = useState<User>();

  useEffect(() => {
    getInfo({ id: undefined, queryParams: undefined });
  }, []);

  useEffect(() => {
    if (info != null && info != undefined && info.length > 0) setUser(info[0]);
  }, [info]);

  const reloadInfoComponent = () => {
    getInfo({ id: undefined, queryParams: undefined });
  };

  return info[0] ? (
    <div className="flex px-14 w-full">
      <div className="flex flex-row justify-center items-start gap-8 py-16 w-full">
        <div className="flex flex-col justify-center items-center gap-4 min-w-[210px]">
          <ProfilePhoto />
          <div className="flex flex-col justify-center items-center gap-4">
            <TabButton width={200} text="General info" path="/profile" />
            <TabButton width={200} text="Additional info" path="/profile/info" />
            <TabButton width={200} text="My rentals" path="/profile/rentals" />
          </div>
        </div>
        <div className="flex flex-col items-start justify-start rounded-lg bg-white shadow-xl p-3 w-full min-h-[360px]">
          <Outlet context={{ user: info[0], reloadAdditonalInfoComponent: reloadInfoComponent }} />
        </div>
      </div>
    </div>
  ) : (
    ""
  );
};
