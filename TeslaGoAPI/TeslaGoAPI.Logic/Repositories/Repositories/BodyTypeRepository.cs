﻿using TeslaGoAPI.DB.Context;
using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.Logic.Repositories.Repositories.Abstract;

namespace TeslaGoAPI.Logic.Repositories.Repositories
{
    public sealed class BodyTypeRepository(APIContext context) : GenericRepository<BodyType>(context)
    {
    }
}
