using TeslaGoAPI.DB.Entities.Abstract;
using TeslaGoAPI.Logic.Dto.Abstract;
using TeslaGoAPI.Logic.Query.Abstract;
using TeslaGoAPI.Logic.Result;

namespace TeslaGoAPI.Logic.Services.Interfaces.Abstract
{
    public interface IGenericService<TEntity, TRequestDto, TResponseDto, TQuery>
       where TEntity : class, IEntity
       where TRequestDto : class, IRequestDto
       where TResponseDto : class, IResponseDto
       where TQuery : QueryObject
    {
        Task<Result<TResponseDto>> AddAsync(TRequestDto? requestDto);
        Task<Result<IEnumerable<TResponseDto>>> GetAllAsync(TQuery query);
        Task<Result<TResponseDto>> GetOneAsync(int id);
        Task<Result<TResponseDto>> UpdateAsync(int id, TRequestDto? requestDto);
        Task<Result<object>> DeleteAsync(int id);
    }
}
