import hero from "../assets/hero.png";
import cybertruck from "../assets/tesla_cybertruck.png";
import goal from "../assets/goal.png";
import rent from "../assets/rent.png";
import { AboutItem } from "../components/aboutpage/AboutItem";

const AboutPage = () => {
  return (
    <div className="py-10 w-[80%]">
      <div className="flex flex-col gap-6 mt-6">
        <article className="w-full flex flex-col justify-center items-center">
          <h2 className="tracking-wide">
            <span className="text-[#2F2F2F] text-4xl font-semibold">Welcome to </span>
            <span className="text-primaryGreen font-extrabold text-5xl">TeslaGo!</span>
          </h2>
          <p className="max-w-[80%] text-center mt-2 text-textPrimary">
            Looking for a stylish and eco-friendly way to explore Mallorca? Welcome to TeslaGo! Whether you're
            here for business or leisure, our fleet of premium Tesla cars offers the ultimate driving
            experience. Rent your Tesla today and drive through the beautiful landscapes of Mallorca in
            comfort and style.
          </p>
        </article>
        <div className="flex flex-col justify-center items-center gap-6 mt-12">
          <AboutItem
            header="Our Story"
            content="TeslaGo was founded in 2025 to provide an unparalleled car rental experience in Mallorca. We
                believe in combining sustainability, luxury, and innovation to give you the best driving
                experience. Our fleet consists exclusively of the latest Tesla models, offering cutting-edge
                technology, electric efficiency, and exceptional comfort. With several convenient locations
                across the island, you can easily pick up and drop off your rental at Palma Airport, Palma
                City Center, Alcudia, or Manacor. Join us in embracing the future of mobility while enjoying
                the beautiful island of Mallorca."
            image={hero}
            imageAlt={"Hero image"}
          />
          <AboutItem
            header="Our Mission"
            content="At TeslaGo, our mission is to offer you the most convenient, luxurious, and eco-friendly car
                rental service on the Mallorca island. Whether you're driving around the city or exploring the
                scenic coastlines, our Teslas provide a smooth, quiet, and sustainable ride. Our goal is to
                make your visit to Mallorca even more special by giving you access to the most advanced
                electric vehicles on the market."
            image={goal}
            imageAlt={"Goal image"}
            imageLeft={true}
          />
          <AboutItem
            header="Our Fleet"
            content="Our fleet includes all available passenger Tesla models, from the compact and efficient Model
                3 to the spacious and luxurious Model X. All our vehicles are electric, ensuring a green and
                cost-effective driving experience. No matter what your needs are, we have the perfect Tesla
                for you. Rent a Model 3 for a sporty city drive, or a Model S for long road trips across the
                island. Experience the future of driving today with TeslaRent Mallorca!"
            image={cybertruck}
            imageAlt={"Cybertruck"}
          />

          <AboutItem
            header="How it Works"
            content="Renting a Tesla in TeslaGo is simple. Choose the location, select the model that suits you
                best, and specify your desired rental dates. We'll calculate the total cost of your
                reservation. You can pick up and drop off the vehicle at any of our convenient locations
                across the island. Plus, our prices are competitive, and we offer special deals for long-term
                rentals. Discover the ease of driving a Tesla – the future is here with TeslaGo!"
            image={rent}
            imageAlt={"Rent image"}
            imageLeft={true}
          />
        </div>
      </div>
    </div>
  );
};

export default AboutPage;
