import { z } from "zod";

export const reservationSchema = z
  .object({
    startDate: z
      .string()
      .datetime({ local: true })
      .refine((val) => new Date(val) >= new Date(new Date().toDateString()), {
        message: "Start date cannot be in the past.",
      }),

    endDate: z.string().datetime({ local: true }),

    pickupLocationId: z.number().int().gt(0, { message: "Pickup location ID must be greater than 0." }),

    returnLocationId: z.number().int().gt(0, { message: "Return location ID must be greater than 0." }),

    carModelId: z.number().nullish(),

    paymentMethodId: z.number().int().gt(0, { message: "Payment type ID must be greater than 0." }),

    optServicesIds: z
      .array(z.number().int().gt(0, { message: "Optional service IDs must be greater than 0." }))
      .refine((ids) => new Set(ids).size === ids.length, {
        message: "Optional services cannot contain duplicates.",
      }),
  })
  .refine(
    (data) => {
      return new Date(data.endDate) > new Date(data.startDate);
    },
    {
      message: "End date must be after start date.",
    }
  );

export type ReservationRequest = z.infer<typeof reservationSchema>;
