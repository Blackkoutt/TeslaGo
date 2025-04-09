import { CarModel } from "../models/response_models/CarModel";
import { OptService } from "../models/response_models/OptService";

export const getSelectedDatesString = (startDate: string, endDate: string) => {
  if (startDate != "" && endDate != "") {
    const startDateAsDate = new Date(startDate);
    const endDateAsDate = new Date(endDate);
    if (startDateAsDate >= new Date() && endDateAsDate > startDateAsDate)
      return `${startDateAsDate.toLocaleString()} - ${endDateAsDate.toLocaleString()}`;
  }
  return "";
};

export const getSelectedOptServices = (optServices: OptService[], optServicesIds: number[]) => {
  return optServices.filter((x) => optServicesIds.includes(x.id));
};

export const calculateDiffrenceInDays = (startDate: Date, endDate: Date) => {
  const differenceInTime = endDate.getTime() - startDate.getTime();
  return Math.ceil(differenceInTime / (1000 * 3600 * 24));
};

export const calculateTotalPrice = (
  model: CarModel | undefined,
  startDate: string,
  endDate: string,
  optServicesIds: number[],
  optServices: OptService[]
) => {
  if (model != undefined && startDate != "" && endDate != "") {
    const startDateAsDate = new Date(startDate);
    const endDateAsDate = new Date(endDate);
    if (startDateAsDate >= new Date() && endDateAsDate > startDateAsDate) {
      const differenceInDays = calculateDiffrenceInDays(startDateAsDate, endDateAsDate);
      const services = getSelectedOptServices(optServices, optServicesIds);
      let totalCost = model.pricePerDay * differenceInDays;
      let servicesCost = 0;
      services.forEach((s) => {
        totalCost += s.price;
        servicesCost += s.price;
      });
      return { totalCost: totalCost, optServicesTotalPrice: servicesCost };
    }
  }
  return { totalCost: 0, optServicesTotalPrice: 0 };
};
