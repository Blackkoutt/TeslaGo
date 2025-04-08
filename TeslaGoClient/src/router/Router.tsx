import { createBrowserRouter } from "react-router-dom";
import { AppLayout } from "../layout/AppLayout";
import { NotFoundPage } from "../pages/NotFoundPage";
import { HomePage } from "../pages/HomePage";
import { FaqPage } from "../pages/FaqPage";
import { FleetPage } from "../pages/FleetPage";
import { SignInPage } from "../pages/auth/SignInPage";
import { RegitserPage } from "../pages/auth/RegisterPage";
import { AboutPage } from "../pages/About";
import { RodoPage } from "../pages/RodoPage";
import { PrivacyPolicyPage } from "../pages/PrivacyPolicyPage";
import { StatutePage } from "../pages/StatutePage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <AppLayout />,
    errorElement: <NotFoundPage />,
    children: [
      {
        path: "/",
        element: <HomePage />,
      },
      {
        path: "/about",
        element: <AboutPage />,
      },
      {
        path: "/faq",
        element: <FaqPage />,
      },
      {
        path: "/fleet",
        element: <FleetPage />,
      },
      {
        path: "/sign-in",
        element: <SignInPage />,
      },
      {
        path: "/register",
        element: <RegitserPage />,
      },
      {
        path: "/rodo",
        element: <RodoPage />,
      },
      {
        path: "/privacy-policy",
        element: <PrivacyPolicyPage />,
      },
      {
        path: "/statute",
        element: <StatutePage />,
      },
    ],
  },
]);
