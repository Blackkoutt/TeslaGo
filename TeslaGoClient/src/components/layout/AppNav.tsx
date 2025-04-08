import { AppNavLink } from "./AppNavLink";

interface AppNavProps {
  fontSize?: number;
  isSemibold?: boolean;
  textColor?: string;
  gap?: number;
}

export const AppNav = ({
  fontSize = 24,
  isSemibold = true,
  textColor = "#000000",
  gap = 4,
}: AppNavProps) => {
  return (
    <nav className="flex flex-row justify-center items-center" style={{ gap: gap }}>
      <AppNavLink
        to="/"
        text="Home"
        fontSize={fontSize}
        isSemibold={isSemibold}
        textColor={textColor}
      />
      <AppNavLink
        to="/about"
        text="About us"
        fontSize={fontSize}
        isSemibold={isSemibold}
        textColor={textColor}
      />
      <AppNavLink
        to="/fleet"
        text="Our fleet"
        fontSize={fontSize}
        isSemibold={isSemibold}
        textColor={textColor}
      />
      <AppNavLink
        to="/faq"
        text="FAQ"
        fontSize={fontSize}
        isSemibold={isSemibold}
        textColor={textColor}
      />
    </nav>
  );
};
