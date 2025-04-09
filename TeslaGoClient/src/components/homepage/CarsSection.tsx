import { Link } from "react-router-dom";
import { CarModelList } from "../common/CarModelList";
import SectionHeader from "../common/SectionHeader";
import Button, { ButtonStyle } from "../common/Button";

export const CarsSection = () => {
  return (
    <section
      id="cars"
      className="min-h-[100px] min-w-[125%] overflow-auto bg-[#F4F6FA] flex flex-col justify-center items-center"
    >
      <div className="w-[80%] flex flex-col justify-center items-center py-16 gap-12">
        <SectionHeader
          title="Rent one of our cars"
          subtitle="Choose your Tesla, select dates, and hit the road in style – it’s that simple."
        />
        <div className="flex flex-col justify-center items-center gap-12">
          <CarModelList modelVersionId={1} />
          <Link to="/fleet">
            <Button
              text="Find more cars"
              width={170}
              height={53}
              fontSize={16}
              rounded={999}
              style={ButtonStyle.Primary}
            />
          </Link>
        </div>
      </div>
    </section>
  );
};
