export const padZero = (num: number): string => {
  return (num < 10 ? '0' : '') + num;
}
