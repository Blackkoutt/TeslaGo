import { FaqList } from "../components/common/FaqList";

export const FaqPage = () => {
  return (
    <div className="w-full py-10">
      <div className="flex flex-col gap-6">
        <h1>FAQ</h1>
        <FaqList />
      </div>
    </div>
  );
};
