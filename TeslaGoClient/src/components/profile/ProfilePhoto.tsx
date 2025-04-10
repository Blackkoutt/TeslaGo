import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faPenToSquare } from "@fortawesome/free-solid-svg-icons";
import { useState } from "react";
import userDefault from "../../assets/userDefault.jpg";

export const ProfilePhoto = () => {
  const [hover, setHover] = useState(false);

  return (
    <div
      className="relative bg-slate-400 shadow-xl rounded-full w-[190px] h-[190px] overflow-hidden hover:cursor-pointer hover:opacity-95"
      onMouseEnter={() => setHover(true)}
      onMouseLeave={() => setHover(false)}
    >
      <FontAwesomeIcon
        icon={faPenToSquare}
        className="absolute"
        style={{
          color: "white",
          top: "calc(50% - 20px)",
          left: "calc(50% - 20px)",
          width: "40px",
          height: "40px",
          display: `${hover ? "block" : "none"}`,
        }}
      />
      <img src={userDefault} alt={`User photo`} className="w-full h-full object-cover" />
    </div>
  );
};
