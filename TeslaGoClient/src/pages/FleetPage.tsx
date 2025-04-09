import { useEffect, useMemo, useState } from "react";
import { CarModelList } from "../components/common/CarModelList";
import { ApiEndpoint } from "../config/enums/ApiEndpointEnum";
import useApi from "../hooks/useApi";
import Select from "../components/forms/Select";
import { SelectOption } from "../helpers/SelectOption";
import { FormProvider, useForm } from "react-hook-form";
import { CarModelFilters } from "../helpers/CarModelFilters";
import { setSelectOptions } from "../helpers/SetSelectOptions";
import { CarModel } from "../models/response_models/CarModel";
import { getUniqueBy } from "../helpers/GetUniqueBy";

export const FleetPage = () => {
  const { data: carModels, get: getCarModels } = useApi<CarModel>(ApiEndpoint.CarModel);
  const [modelSelectOptions, setModelSelectOptions] = useState<SelectOption[]>([]);
  const [versionsSelectOptions, setVersionsSelectOptions] = useState<SelectOption[]>([]);
  const [bodyTypesSelectOptions, setBodyTypesSelectOptions] = useState<SelectOption[]>([]);
  const [driveTypesSelectOptions, setDriveTypesSelectOptions] = useState<SelectOption[]>([]);

  const methods = useForm<CarModelFilters>();
  const { watch } = methods;

  const filters = watch();
  console.log(filters);

  const memoFilters = useMemo(() => filters, [filters]);

  useEffect(() => {
    getCarModels({ id: undefined, queryParams: undefined });
  }, []);

  useEffect(() => {
    const uniqueCarModels = getUniqueBy(carModels, (x) => x.name);
    setSelectOptions(uniqueCarModels, setModelSelectOptions, "name", "name", true);

    const bodyTypes = carModels.map((model) => model.bodyType);
    const uniqueBodyTypes = getUniqueBy(bodyTypes, (x) => x.name);
    setSelectOptions(uniqueBodyTypes, setBodyTypesSelectOptions, "id", "name", true);

    const versions = carModels.map((model) => model.modelVersion);
    const uniqueVersions = getUniqueBy(versions, (x) => x.name);
    setSelectOptions(uniqueVersions, setVersionsSelectOptions, "id", "name", true);

    const driveTypes = carModels.map((model) => model.driveType);
    const uniqueDriveTypes = getUniqueBy(driveTypes, (x) => x.name);
    setSelectOptions(uniqueDriveTypes, setDriveTypesSelectOptions, "id", "name", true);
  }, [carModels]);

  return (
    <div className="w-full py-10">
      <div className="flex flex-col gap-6">
        <h1>Our Fleet</h1>
        <FormProvider {...methods}>
          <form className="flex flex-row justify-center items-center gap-3 w-full mt-4">
            {/* <Select label="Models" name="modelName" optionValues={} /> */}
            <Select label="Models" name="modelName" optionValues={modelSelectOptions} />
            <Select label="Versions" name="versionId" optionValues={versionsSelectOptions} />
            <Select label="Body types" name="bodyTypeId" optionValues={bodyTypesSelectOptions} />
            <Select label="Drive types" name="driveTypeId" optionValues={driveTypesSelectOptions} />
          </form>
        </FormProvider>
      </div>
      <div className="py-6">
        <CarModelList
          modelVersionId={memoFilters.versionId}
          bodyTypeId={filters.bodyTypeId}
          driveTypeId={filters.driveTypeId}
          name={filters.modelName}
        />
      </div>
    </div>
  );
};
