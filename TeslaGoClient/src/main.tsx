import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import { RouterProvider } from "react-router-dom";
import { router } from "./router/Router.tsx";
import { AuthProvider } from "./context/AuthContext.tsx";
import { Slide, ToastContainer } from "react-toastify";

const originalWarn = console.warn;
console.warn = (...args) => {
  if (args[0].includes("React Router Future Flag Warning")) {
    return;
  }
  originalWarn(...args);
};

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <AuthProvider>
      <RouterProvider router={router} />
      <ToastContainer
        position="bottom-right"
        autoClose={3000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="colored"
        transition={Slide}
        limit={5}
        style={{ zIndex: "9999 !important" }}
      />
    </AuthProvider>
  </StrictMode>
);
