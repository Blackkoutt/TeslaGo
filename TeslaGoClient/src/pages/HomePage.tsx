import { FaqList } from "../components/common/FaqList";
import SectionHeader from "../components/common/SectionHeader";
import { CarsSection } from "../components/homepage/CarsSection";
import { FaqSection } from "../components/homepage/FaqSection";
import { HeroSection } from "../components/homepage/HeroSection";

export const HomePage = () => {
  return (
    <>
      <HeroSection />
      <CarsSection />
      <FaqSection />
    </>
  );
};
