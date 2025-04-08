import { z } from "zod";

export const userLoginSchema = z.object({
  email: z
    .string()
    .email({ message: "Email adddress is not in valid format." })
    .nonempty({ message: "Email is required" }),

  password: z.string().nonempty({ message: "Password is required" }),
});

export type UserLoginRequest = z.infer<typeof userLoginSchema>;
