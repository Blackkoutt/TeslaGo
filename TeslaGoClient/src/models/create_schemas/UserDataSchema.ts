import { z } from "zod";

export const userDataRequestSchema = z.object({
  street: z.string().max(150, { message: "Street cannot exceed 150 characters." }).optional().nullable(),

  houseNumber: z
    .string()
    .max(25, { message: "House number cannot exceed 25 characters." })
    .optional()
    .nullable(),

  flatNumber: z
    .number()
    .int()
    .min(1, { message: "Flat no: 1–999." })
    .max(10000, { message: "Flat no: 1–999." })
    .optional()
    .nullable(),

  zipCode: z
    .string()
    .regex(/^[A-Za-z0-9\s\-]{3,25}$/, { message: "Invalid zip code format." })
    .optional()
    .nullable(),

  city: z.string().max(80, { message: "Name cannot exceed 80 characters." }).optional().nullable(),

  countryId: z.number().int().gt(0, { message: "Country ID must be greater than 0." }).optional().nullable(),

  drivingLicenseNumber: z
    .string()
    .max(30, { message: "DrivingLicenseNumber: max 30 chars." })
    .optional()
    .nullable(),
});
export type UserDataRequest = z.infer<typeof userDataRequestSchema>;
