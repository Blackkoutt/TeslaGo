import DateFormatter from "./DateFormatter";
import { DateFormat } from "./enums/DateFormatEnum";

export const GetProductionYears = (
  startDate: string | undefined | null,
  endDate: string | undefined | null
) => {
  const formattedStartDate = startDate ? DateFormatter.FormatDate(startDate, DateFormat.Year) : "";
  const formattedEndDate = endDate ? DateFormatter.FormatDate(endDate, DateFormat.Year) : "now";

  if (!startDate && !endDate) return "No data";

  return `${formattedStartDate} - ${formattedEndDate}`;
};
