import SocialMediaIcon from "./SocialMediaIcon";
import { faXTwitter, faFacebookF, faInstagram } from "@fortawesome/free-brands-svg-icons";

export const SocialMediaIconsContainer = () => {
  return (
    <div className="flex flex-row items-center justify-start gap-11">
      <SocialMediaIcon
        icon={faFacebookF}
        linkTo="https://www.facebook.com/?locale=pl_PL"
        title="Fanpage TeslaGo on Facebook!"
        iconSize={45}
        center={false}
        width={60}
        height={60}
        hoverBgColor="#0866ff"
      />
      <SocialMediaIcon
        icon={faXTwitter}
        linkTo="https://x.com/"
        title="TeslaGo X Profile!"
        isBordered={true}
        iconSize={32}
        width={60}
        height={60}
        hoverBgColor="#fff"
        hoverTextColor="#000"
      />
      <SocialMediaIcon
        linkTo="https://www.instagram.com/"
        title="TeslaGo Instagram Profile!"
        icon={faInstagram}
        iconSize={37}
        width={60}
        height={60}
        hoverBgColor="linear-gradient(45deg, #F58529, #DD2A7B, #8134AF, #515BD4)"
      />
    </div>
  );
};
