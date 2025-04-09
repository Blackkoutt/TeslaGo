import { SelectOption } from "./SelectOption";

export const setSelectOptions = <T>(
  data: T[],
  setState: (options: SelectOption[]) => void,
  valueKey: keyof T,
  labelKey: keyof T,
  addAllParameter: boolean = false
) => {
  const selectOptions = data.map((item) => ({
    value: item[valueKey] as string | number,
    option: item[labelKey] as string,
  })) as SelectOption[];

  if (addAllParameter) {
    selectOptions.unshift({ value: undefined, option: "All" });
  }

  setState(selectOptions);
};
