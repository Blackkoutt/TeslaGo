import { createBrowserRouter } from "react-router-dom";
import { AppLayout } from "../layout/AppLayout";
import { NotFoundPage } from "../pages/NotFoundPage";
import { HomePage } from "../pages/HomePage";
import { FaqPage } from "../pages/FaqPage";
import { FleetPage } from "../pages/FleetPage";
import { SignInPage } from "../pages/auth/SignInPage";
import { SignUpPage } from "../pages/auth/SignUpPage";
import { PrivacyPolicyPage } from "../pages/PrivacyPolicyPage";
import { TermsPage } from "../pages/TermsPage";
import { ForgotPasswordPage } from "../pages/ForgotPasswordPage";
import { CarModelPage } from "../pages/CarModelPage";
import { ProfilePage } from "../pages/ProfilePage";
import { UserInfoPage } from "../pages/profile/UserInfoPage";
import ProtectedRoute from "../wrappers/ProtectedRoute";
import UserAdditionalInfoPage from "../pages/profile/UserAdditionalInfoPage";
import UserRentalsPage from "../pages/profile/UserRentalsPage";
import AboutPage from "../pages/AboutPage";
import { GDPRPage } from "../pages/GDPRPage";

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
        element: (
          <ProtectedRoute>
            <ProfilePage />
          </ProtectedRoute>
        ),
        children: [
          {
            path: "/profile",
            element: (
              <ProtectedRoute>
                <UserInfoPage />
              </ProtectedRoute>
            ),
          },
          {
            path: "/profile/info",
            element: (
              <ProtectedRoute>
                <UserAdditionalInfoPage />
              </ProtectedRoute>
            ),
          },
          {
            path: "/profile/rentals",
            element: (
              <ProtectedRoute>
                <UserRentalsPage />
              </ProtectedRoute>
            ),
          },
        ],
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
        path: "/gdpr",
        element: <GDPRPage />,
      },
      {
        path: "/privacy-policy",
        element: <PrivacyPolicyPage />,
      },
      {
        path: "/terms",
        element: <TermsPage />,
      },
      {
        path: "/forgot-password",
        element: <ForgotPasswordPage />,
      },
    ],
  },
]);
