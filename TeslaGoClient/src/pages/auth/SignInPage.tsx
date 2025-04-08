import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import { FormProvider, SubmitHandler, useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  UserLoginRequest,
  userLoginSchema,
} from "../../models/create_schemas/UserLoginSchema";
import { useEffect } from "react";
import sign_in from "../../assets/sign_in.png";
import Input from "../../components/forms/Input";
import { faEnvelope, faKey } from "@fortawesome/free-solid-svg-icons";
import Checkbox from "../../components/forms/Checkbox";
import Button, { ButtonStyle } from "../../components/common/Button";

export const SignInPage = () => {
  const { currentUser, authenticated, handleLogin } = useAuth();

  const navigate = useNavigate();

  const methods = useForm<UserLoginRequest>({
    resolver: zodResolver(userLoginSchema),
  });
  const { handleSubmit, formState, watch } = methods;
  const { errors, isSubmitting } = formState;

  const onSubmit: SubmitHandler<UserLoginRequest> = async (data) => {
    await handleLogin(data);
  };

  useEffect(() => {
    if (authenticated) {
      console.log("currentUser", currentUser);
      navigate("/");
    }
  }, [authenticated]);

  return (
    <div className="flex flex-row justify-center items-center gap-30 py-16 w-full">
      <div className="flex flex-col justify-center items-start">
        <h2 className="tracking-wide">
          <span className="text-[#2F2F2F] text-4xl font-semibold">Welcome in</span>
          <span className="text-primaryGreen font-extrabold text-5xl">TeslaGo!</span>
        </h2>
        <img
          src={sign_in}
          alt="Sign in image"
          className="object-contain w-[460px] h-[460px]"
        />
      </div>
      <div className="bg-white min-w-[580px] rounded-md drop-shadow-xl p-10 flex flex-col justify-center items-center gap-10">
        <h3 className="text-black font-bold text-4xl">Sign in</h3>
        <div className="flex flex-col justify-center items-center gap-6 w-full">
          <FormProvider {...methods}>
            <form
              className="flex flex-col justify-center items-center gap-4 w-full"
              onSubmit={handleSubmit(onSubmit)}
            >
              <Input
                icon={faEnvelope}
                label="Email"
                type="email"
                maxLength={255}
                name="email"
                error={errors.email}
                errorHeight={15}
              />

              <Input
                icon={faKey}
                label="Password"
                type="password"
                name="password"
                error={errors.password}
                errorHeight={15}
              />

              <div className="flex flex-row justify-between items-center w-full pb-4">
                <Checkbox
                  color="#05df72"
                  name="remind"
                  textColor="#2F2F2F"
                  fontSize={16}
                  text="Remind me"
                />
                <Link to="/forgot-password" className="text-[#3fe090] text-base">
                  Forgot password?
                </Link>
              </div>
              <Button
                style={ButtonStyle.Primary}
                isSubmitting={isSubmitting}
                type="submit"
                text="Sign in"
                isFullWidth={true}
              />
              <div className="flex flex-row justify-center items-center gap-1 pt-4">
                <p className="text-base text-[#2f2f2f]">Don't have an account yet?</p>
                <Link to="/sign-up" className="text-[#3fe090] text-base">
                  Sign up
                </Link>
              </div>
            </form>
          </FormProvider>
        </div>
      </div>
    </div>
  );
};
