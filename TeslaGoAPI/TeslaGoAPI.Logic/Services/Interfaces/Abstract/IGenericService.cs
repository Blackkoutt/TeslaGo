using TeslaGoAPI.DB.Entities.Abstract;
using TeslaGoAPI.Logic.Dto.Abstract;
using TeslaGoAPI.Logic.Query.Abstract;
using TeslaGoAPI.Logic.Result;

namespace TeslaGoAPI.Logic.Services.Interfaces.Abstract
{
    public interface IGenericService<TEntity, TRequestDto, TUpdateRequestDto, TResponseDto, TQuery>
       where TEntity : class, IEntity
       where TRequestDto : class, IRequestDto
       where TUpdateRequestDto : class, IRequestDto
       where TResponseDto : class, IResponseDto
       where TQuery : QueryObject
    {
        Task<Result<object>> AddAsync(TRequestDto? requestDto);
        Task<Result<IEnumerable<TResponseDto>>> GetAllAsync(TQuery query);
        Task<Result<TResponseDto>> GetOneAsync(int id);
        Task<Result<object>> UpdateAsync(int id, TUpdateRequestDto? requestDto);
        Task<Result<object>> DeleteAsync(int id);
    }
}
