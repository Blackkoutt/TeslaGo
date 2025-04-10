import { Link } from "react-router-dom";
import not_found from "../assets/not_found.png";

export const NotFoundPage = () => {
  return (
    <div className="flex flex-col justify-center items-center pt-16 gap-8 ">
      <div className="flex flex-col justify-center items-center gap-4 w-full">
        <h1 className="text-[#2F2F2F] text-[36px] font-semibold">Error 404: Not found</h1>
        <Link to="/">
          <button
            className="bg-primaryGreen text-white rounded-xl py-4 px-5 font-normal"
            style={{ outline: "none" }}
          >
            Back to HomePage
          </button>
        </Link>
      </div>
      <img src={not_found} alt="Ilustracja błędu not found" className="object-contain w-[620px] h-[580px]" />
    </div>
  );
};
