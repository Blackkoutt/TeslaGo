import { createBrowserRouter } from "react-router-dom";
import { AppLayout } from "../layout/AppLayout";
import { NotFoundPage } from "../pages/NotFoundPage";
import { HomePage } from "../pages/HomePage";
import { FaqPage } from "../pages/FaqPage";
import { FleetPage } from "../pages/FleetPage";
import { SignInPage } from "../pages/auth/SignInPage";
import { SignUpPage } from "../pages/auth/SignUpPage";
import { AboutPage } from "../pages/About";
import { RodoPage } from "../pages/RodoPage";
import { PrivacyPolicyPage } from "../pages/PrivacyPolicyPage";
import { StatutePage } from "../pages/StatutePage";
import { ForgotPasswordPage } from "../pages/ForgotPasswordPage";
import { CarModelPage } from "../pages/CarModelPage";
import { ProfilePage } from "../pages/ProfilePage";

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
        path: "/profile",
        element: <ProfilePage />,
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
        path: "/fleet/:carModelId",
        element: <CarModelPage />,
      },
      {
        path: "/sign-in",
        element: <SignInPage />,
      },
      {
        path: "/sign-up",
        element: <SignUpPage />,
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
      {
        path: "/forgot-password",
        element: <ForgotPasswordPage />,
      },
    ],
  },
]);
