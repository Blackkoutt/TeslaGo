import { faUser, faRightFromBracket } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useAuth } from "../../context/AuthContext";
import { useEffect, useState } from "react";
import { UserAccordionItem } from "./UserAccordionItem";

const UserAccordion = () => {
  const { currentUser, handleLogout } = useAuth();
  const [trigger, setTrigger] = useState(false);
  const [accordionClass, setAccordionClass] = useState("accordion-content-non-active");
  const [contentClass, setContentClass] = useState("hidden");

  useEffect(() => {
    const triggerAccordionClass = trigger
      ? "accordion-content-active"
      : "accordion-content-non-active";

    const triggerContentClass = trigger ? "flex" : "hidden";
    setAccordionClass(triggerAccordionClass);
    if (
      triggerContentClass == "hidden" &&
      triggerAccordionClass == "accordion-content-non-active"
    ) {
      setTimeout(() => setContentClass(triggerContentClass), 200);
    } else {
      setContentClass(triggerContentClass);
    }
  }, [trigger]);

  return (
    <button
      className="flex flex-row justify-center rounded-2xl items-center gap-4 px-6 py-4 relative bg-primaryGreen hover:bg-primaryHoverGreen text-white"
      onFocus={() => {
        setTrigger(true);
      }}
      style={{ outline: "none" }}
      onBlur={() => setTrigger(false)}
    >
      <p className="text-[17px] text-white">Hello, {currentUser?.name}!</p>
      <FontAwesomeIcon icon={faUser} fontSize={30} />
      <div
        tabIndex={1}
        onClick={(e) => {
          e.stopPropagation;
          setTrigger(false);
        }}
        className={`accordion-content absolute w-full top-[100%] left-0 mt-2 shadow-2xl flex flex-col bg-white px-1 rounded-lg ${accordionClass}`}
      >
        <div className={`${contentClass} flex-col px-2 z-[999] pb-3`}>
          <UserAccordionItem redirectTo="/profile" icon={faUser} text="Profile" />
          <UserAccordionItem
            redirectTo="/"
            onClick={handleLogout}
            icon={faRightFromBracket}
            text="Logout"
          />
        </div>
      </div>
    </button>
  );
};
export default UserAccordion;
