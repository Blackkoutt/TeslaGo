﻿using TeslaGoAPI.Logic.Query.Abstract;

namespace TeslaGoAPI.Logic.Query
{
    public class BodyTypeQuery : QueryObject, INameableQuery
    {
        public string? Name { get; set; }
    }
}
