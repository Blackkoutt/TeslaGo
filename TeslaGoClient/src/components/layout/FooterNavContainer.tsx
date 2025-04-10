import { AppNav } from "./AppNav";
import { AppNavLink } from "./AppNavLink";

export const FooterNavContainer = () => {
  return (
    <div className="flex flex-col justify-start items-start gap-7">
      <section id="footer-nav" className="flex flex-col justify-start items-start gap-2">
        <h4 className="text-[17px] font-semibold text-black border-b-4 border-b-primaryGreen">MENU</h4>
        <AppNav fontSize={16} isSemibold={false} textColor="#000" gap={28} />
      </section>
      <div className="flex flex-row justify-between w-full items-end">
        <div className="flex flex-col justify-start items-start gap-2">
          <h4 className="text-[17px] font-semibold text-black border-b-4 border-b-primaryGreen">SEE ALSO</h4>
          <div className="flex flex-row justify-center items-center gap-7">
            <AppNavLink
              to="/privacy-policy"
              text="Privacy policy"
              fontSize={16}
              isSemibold={false}
              textColor="#000"
            />
            <AppNavLink to="/gdpr" text="GDPR" fontSize={16} isSemibold={false} textColor="#000" />
            <AppNavLink
              to="/terms"
              text="Terms and conditions"
              fontSize={16}
              isSemibold={false}
              textColor="#000"
            />
          </div>
        </div>
      </div>
    </div>
  );
};
