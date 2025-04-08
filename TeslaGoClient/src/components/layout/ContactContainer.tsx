import { faEnvelope, faLocationDot } from "@fortawesome/free-solid-svg-icons";
import { ContactItem } from "./ContactItem";

export const ContactContainer = () => {
  return (
    <div className="flex flex-col justify-start items-center gap-11">
      <ContactItem
        icon={faLocationDot}
        header="TeslaGo"
        text="Plaça d'Espanya 1<br />
             07002 Palma, Mallorca"
      />
      <ContactItem
        icon={faEnvelope}
        header="Contact"
        text="phone: 123 456 789<br />
                    e-mail: teslago@gmail.com"
      />
    </div>
  );
};
