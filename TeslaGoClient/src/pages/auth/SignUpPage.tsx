import { zodResolver } from "@hookform/resolvers/zod";
import { FormProvider, SubmitHandler, useForm } from "react-hook-form";
import {
  UserRegisterRequest,
  userRegisterSchema,
} from "../../models/create_schemas/UserRegisterSchema";
import sign_up from "../../assets/sign_up.png";
import { useEffect } from "react";
import Input from "../../components/forms/Input";
import { faEnvelope, faKey, faUserCircle } from "@fortawesome/free-solid-svg-icons";
import Button, { ButtonStyle } from "../../components/common/Button";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import { DatePicker } from "../../components/forms/DatePicker";
import { toast } from "react-toastify";
import InputHelper from "../../helpers/InputHelpers";

export const SignUpPage = () => {
  const { currentUser, authenticated, handleRegister } = useAuth();

  const navigate = useNavigate();

  const methods = useForm<UserRegisterRequest>({
    resolver: zodResolver(userRegisterSchema),
  });
  const { handleSubmit, formState } = methods;
  const { errors, isSubmitting } = formState;

  const onSubmit: SubmitHandler<UserRegisterRequest> = async (data) => {
    await handleRegister(data);
  };

  useEffect(() => {
    if (authenticated) {
      console.log("currentUser", currentUser);
      navigate("/");
      toast.success("You have successfully registered!");
    }
  }, [authenticated]);

  return (
    <div className="flex flex-row justify-center items-start gap-20 py-16 w-full">
      <div className="flex flex-col justify-center items-start translate-y-[100px]">
        <h2 className="tracking-wide">
          <span className="text-[#2F2F2F] text-4xl font-semibold">Welcome in</span>
          <span className="text-primaryGreen font-extrabold text-5xl">TeslaGo!</span>
        </h2>
        <img src={sign_up} alt="Sign up image" className="object-contain w-[460px] h-[460px]" />
      </div>
      <div className="bg-white min-w-[580px] rounded-md drop-shadow-xl p-10 flex flex-col justify-center items-center gap-10">
        <h3 className="text-black font-bold text-4xl">Create and account</h3>
        <div className="flex flex-col justify-center items-center gap-6 w-full">
          <FormProvider {...methods}>
            <form
              className="flex flex-col justify-center items-center gap-[10px] w-full"
              onSubmit={handleSubmit(onSubmit)}
            >
              <Input
                icon={faUserCircle}
                label="Name"
                onInput={InputHelper.ValidateNameOrSurname}
                maxLength={40}
                type="text"
                name="name"
                error={errors.name}
                errorHeight={15}
              />
              <Input
                icon={faUserCircle}
                label="Surname"
                onInput={InputHelper.ValidateNameOrSurname}
                type="text"
                maxLength={40}
                name="surname"
                error={errors.surname}
                errorHeight={15}
              />

              <Input
                icon={faEnvelope}
                label="Email"
                type="email"
                maxLength={255}
                name="email"
                error={errors.email}
                errorHeight={15}
              />

              <DatePicker
                label="Birth date"
                name="dateOfBirth"
                error={errors.dateOfBirth}
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

              <Input
                icon={faKey}
                label="Confirm password"
                type="password"
                name="confirmPassword"
                error={errors.confirmPassword}
                errorHeight={15}
              />
              <Button
                style={ButtonStyle.Primary}
                isSubmitting={isSubmitting}
                type="submit"
                text="Sign up"
                isFullWidth={true}
              />
              <div className="flex flex-row justify-center items-center gap-1 pt-4">
                <p className="text-base text-[#2f2f2f]">Already have an account?</p>
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
