import hero from "../../assets/hero.png";

export const HeroSection = () => {
  return (
    <section
      id="hero"
      className="py-17 hero_section flex flex-row items-center justify-center gap-6 px-4"
    >
      <div className="flex flex-col justify-center items-start gap-7 max-w-lg lg:max-w-none">
        <article className="flex flex-col justify-start items-start gap-5 max-w-[1200px]">
          <h1>Welcome in TeslaGo!</h1>
          <p className="text-[16px] font-normal text-textPrimary max-w-[700px]">
            Discover the beauty of Mallorca behind the wheel of a Tesla with TeslaGo! Whether you're
            exploring the island’s scenic coastlines or navigating city streets, our all-electric
            fleet offers a smooth, sustainable, and stylish way to travel. With fast and easy
            booking, flexible pickup and return options, and top-tier Tesla models at your service,
            TeslaGo makes car rental effortless and enjoyable. Embrace the freedom of the road and
            make your Mallorca experience truly unforgettable.
          </p>
        </article>
      </div>
      <img src={hero} alt="Hero image" className="w-full max-w-[600px] max-h-[460px]" />
    </section>
  );
};
