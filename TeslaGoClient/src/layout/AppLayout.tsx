import { AppLogo } from "../components/layout/AppLogo";
import { AppNav } from "../components/layout/AppNav";
import { AppLoginRegisterButtons } from "../components/layout/AppLoginRegisterButtons";
import { Outlet } from "react-router-dom";
import { SocialMediaIconsContainer } from "../components/layout/SocialMediaIconsContainer";
import { ContactContainer } from "../components/layout/ContactContainer";
import { FooterNavContainer } from "../components/layout/FooterNavContainer";

export const AppLayout = () => {
  return (
    <div className="">
      <header className="flex flex-row justify-between items-end border-b-3 border-black pt-1 pb-4">
        <AppLogo width={135} height={90} />
        <AppNav gap={36} fontSize={20} />
        <AppLoginRegisterButtons gap={16} width={145} height={50} />
      </header>
      <main className="flex flex-col justify-center items-center py-7">
        <Outlet />
      </main>
      <footer className="w-full border-t-3 border-black pt-3 flex flex-col pb-8 gap-8 items-start justify-start px-8">
        <div className="flex flex-row justify-between items-center w-full pb-1">
          <AppLogo width={135} height={90} />
          <SocialMediaIconsContainer />
        </div>
        <div className="w-full flex flex-row justify-start items-start gap-30">
          <ContactContainer />
          <FooterNavContainer />
        </div>
        <p className="text-black text-[15px] self-end -mt-6">2025 &copy; TeslaGo</p>
      </footer>
    </div>
  );
};
