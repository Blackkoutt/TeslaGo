import { FaqList } from "../common/FaqList";
import SectionHeader from "../common/SectionHeader";

export const FaqSection = () => {
  return (
    <section
      id="faq"
      className="min-h-[100px] min-w-[125%] pb-12 overflow-auto bg-[#F4F6FA] flex flex-col justify-center items-center"
    >
      <div className="w-[80%]">
        <div className="flex flex-col justify-center items-center gap-7">
          <SectionHeader title="FAQ" subtitle="Get answers to your most common questions" />
          <FaqList displayCount={4} />
        </div>
      </div>
    </section>
  );
};
