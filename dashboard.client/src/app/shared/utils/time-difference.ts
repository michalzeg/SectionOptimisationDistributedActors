import { padZero } from "./pad-zero";

export const calculateTimeDifference = (startDate: Date, endDate: Date = new Date()): string => {
  const timeDifference = endDate.getTime() - startDate.getTime();

  // Convert time difference to hours, minutes, and seconds
  const hours = Math.floor(timeDifference / (1000 * 60 * 60));
  const minutes = Math.floor((timeDifference % (1000 * 60 * 60)) / (1000 * 60));
  const seconds = Math.floor((timeDifference % (1000 * 60)) / 1000);

  if (Number.isNaN(hours) || Number.isNaN(minutes) || Number.isNaN(seconds)) {
    return '';
  }

  // Format the time difference
  const formattedTimeDifference = `${padZero(hours)}:${padZero(minutes)}:${padZero(seconds)}`;
  return formattedTimeDifference;
}
