﻿using AutoMapper;
using TeslaGoAPI.DB.Entities.Abstract;
using TeslaGoAPI.Logic.Dto.Abstract;

namespace TeslaGoAPI.Logic.Mapper.Extensions
{
    public static class MappingExtensions
    {
        private static IMapper? _mapper;

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static T AsDto<T>(this IEntity entity)
        {
            T result;
            try
            {
                result = _mapper!.Map<T>(entity);
            }
            catch (AutoMapperMappingException)
            {
                throw;
            }
            return result;
        }
        public static T AsEntity<T>(this IRequestDto dto)
        {
            T result;
            try
            {
                result = _mapper!.Map<T>(dto);
            }
            catch (AutoMapperMappingException)
            {
                throw;
            }
            return result;
        }

        public static IEntity MapTo(this IRequestDto dto, IEntity entity)
        {
            try
            {
                return _mapper!.Map(dto, entity);
            }
            catch (AutoMapperMappingException)
            {
                throw;
            }
        }

        public static IRequestDto MapTo(this IEntity entity, IRequestDto dto)
        {
            try
            {
                return _mapper!.Map(entity, dto);
            }
            catch (AutoMapperMappingException)
            {
                throw;
            }
        }
    }
}
