import { FaqList } from "../components/common/FaqList";
import SectionHeader from "../components/common/SectionHeader";
import { CarsSection } from "../components/homepage/CarsSection";
import { HeroSection } from "../components/homepage/HeroSection";

export const HomePage = () => {
  return (
    <>
      <HeroSection />
      <CarsSection />
      <section
        id="faq"
        className="min-h-[100px] min-w-[125%] overflow-auto bg-[#F4F6FA] flex flex-col justify-center items-center"
      >
        <div className="w-[80%]">
          <div className="flex flex-col justify-center items-center gap-7">
            <SectionHeader title="FAQ" subtitle="Get answers to your most common questions" />
            <FaqList displayCount={4} />
          </div>
        </div>
      </section>
    </>
  );
};
