import { z } from "zod";

export const userRegisterSchema = z
  .object({
    name: z
      .string()
      .min(2, { message: "Name must contain 2–60 chars." })
      .max(60, { message: "Name must contain 2–60 chars." })
      .regex(/^[A-ZÀ-Ź][a-zà-ÿąćęłńóśźż]*([ '-][A-ZÀ-Ź]?[a-zà-ÿąćęłńóśźż]*)*$/, {
        message: "Name must contain only letters.",
      }),

    surname: z
      .string()
      .min(2, { message: "Surname must contain 2–80 chars." })
      .max(80, { message: "Surname must contain 2–80 chars." })
      .regex(/^[A-ZÀ-Ź][a-zà-ÿąćęłńóśźż]*([ '-][A-ZÀ-Źa-zà-ÿąćęłńóśźż]*)*$/, {
        message: "Surname must contain only letters.",
      }),

    email: z.string().email({ message: "Invalid email." }),

    dateOfBirth: z
      .string()
      .datetime({ local: true })
      .refine(
        (value) => {
          const birthDate = new Date(value);
          const today = new Date();

          const age = today.getFullYear() - birthDate.getFullYear();
          const monthDiff = today.getMonth() - birthDate.getMonth();
          const dayDiff = today.getDate() - birthDate.getDate();

          return age > 18 || (age === 18 && (monthDiff > 0 || (monthDiff === 0 && dayDiff >= 0)));
        },
        {
          message: "You must be over 18 years old.",
        }
      ),

    password: z
      .string()
      .min(8, { message: "Min. 8 characters." })
      .regex(/[A-Z]/, { message: "At least one uppercase letter." })
      .regex(/[a-z]/, { message: "At least one lowercase letter." })
      .regex(/[0-9]/, { message: "At least one number." }),

    confirmPassword: z.string().min(1, { message: "Repeat password." }),
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: "Passwords don’t match.",
  });

export type UserRegisterRequest = z.infer<typeof userRegisterSchema>;
