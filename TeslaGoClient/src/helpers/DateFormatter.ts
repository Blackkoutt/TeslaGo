import { DateFormat } from "./enums/DateFormatEnum";

const ParseDate = (input: string): Date | null => {
  console.log(input);
  const [datePart, timePart] = input.split(" ");
  const [day, month, year] = datePart.split(".").map(Number);

  if (!day || !month || !year) return null;

  let hours = 0;
  let minutes = 0;

  if (timePart) {
    const [h, m] = timePart.split(":").map(Number);
    hours = h || 0;
    minutes = m || 0;
  }

  const parsedDate = new Date(year, month - 1, day, hours, minutes);
  return isNaN(parsedDate.getTime()) ? null : parsedDate;
};

const FormatDate = (
  date: string | number | undefined | null,
  dateFormat: DateFormat
): string => {
  if (date == undefined || date == null) return "";
  const dateObj = new Date(date);
  let formatter: Intl.DateTimeFormat;

  switch (dateFormat) {
    case DateFormat.Date: {
      formatter = new Intl.DateTimeFormat("pl-PL", {
        day: "2-digit",
        month: "2-digit",
        year: "numeric",
      });
      break;
    }

    case DateFormat.DateTime: {
      formatter = new Intl.DateTimeFormat("pl-PL", {
        day: "2-digit",
        month: "2-digit",
        year: "numeric",
        hour: "2-digit",
        minute: "2-digit",
        hour12: false,
      });
      break;
    }
    case DateFormat.DayDateTime: {
      const dayOfWeek = new Intl.DateTimeFormat("pl-PL", {
        weekday: "long",
      }).format(dateObj);

      const dateFormatted = new Intl.DateTimeFormat("pl-PL", {
        day: "2-digit",
        month: "2-digit",
        year: "numeric",
      }).format(dateObj);

      const timeFormatted = new Intl.DateTimeFormat("pl-PL", {
        hour: "2-digit",
        minute: "2-digit",
        hour12: false,
      }).format(dateObj);

      return `${dayOfWeek} ${dateFormatted} godz. ${timeFormatted}`;
    }
    default:
      throw new Error("Unsupported date format");
  }

  return formatter.format(dateObj);
};

function ToLocalISOString(date: Date) {
  const offsetMs = date.getTimezoneOffset() * 60000;
  const localTime = new Date(date.getTime() - offsetMs);
  return localTime.toISOString().slice(0, -1);
}

const FormatDateForCalendar = (date: Date | string) => {
  if (typeof date === "string") {
    date = new Date(date);
  }
  const year = date.getFullYear();
  const month = (date.getMonth() + 1).toString().padStart(2, "0");
  const day = date.getDate().toString().padStart(2, "0");
  const hours = date.getHours().toString().padStart(2, "0");
  const minutes = date.getMinutes().toString().padStart(2, "0");

  return `${year}-${month}-${day} ${hours}:${minutes}`;
};

const DateFormatter = {
  FormatDate,
  ParseDate,
  FormatDateForCalendar,
  ToLocalISOString,
};

export default DateFormatter;
