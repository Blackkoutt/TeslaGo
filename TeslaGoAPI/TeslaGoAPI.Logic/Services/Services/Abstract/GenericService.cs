using TeslaGoAPI.DB.Entities.Abstract;
using TeslaGoAPI.Logic.Dto.Abstract;
using TeslaGoAPI.Logic.Dto.ResponseDto;
using TeslaGoAPI.Logic.Errors;
using TeslaGoAPI.Logic.Extensions;
using TeslaGoAPI.Logic.Identity.Enums;
using TeslaGoAPI.Logic.Identity.Services.Interfaces;
using TeslaGoAPI.Logic.Mapper.Extensions;
using TeslaGoAPI.Logic.Query.Abstract;
using TeslaGoAPI.Logic.Repositories.Interfaces.Abstract;
using TeslaGoAPI.Logic.Result;
using TeslaGoAPI.Logic.Services.Interfaces.Abstract;
using TeslaGoAPI.Logic.UnitOfWork;

namespace TeslaGoAPI.Logic.Services.Services.Abstract
{
    public abstract class GenericService<TEntity, TRequestDto, TResponseDto, TQuery>
        (IUnitOfWork unitOfWork, IAuthService authService)
        : IGenericService<TEntity, TRequestDto, TResponseDto, TQuery>
        where TEntity : class, IEntity
        where TRequestDto : class, IRequestDto
        where TResponseDto : class, IResponseDto
        where TQuery : QueryObject
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork;
        protected readonly IAuthService _authService = authService;
        protected readonly IGenericRepository<TEntity> _repository = unitOfWork.GetRepository<TEntity>();

        /*public virtual async Task<Result<IEnumerable<TResponseDto>>> GetAllAsync(TQuery query)
        {
            /*var records = await _repository.GetAllAsync(q => q.SortBy(query.SortBy, query.SortDirection)
                                                              .GetPage(query.PageNumber, query.PageSize));
            var response = MapAsDto(records);
            return Result<IEnumerable<TResponseDto>>.Success(response);
        }*/

        public abstract Task<Result<IEnumerable<TResponseDto>>> GetAllAsync(TQuery query);

        public virtual async Task<Result<TResponseDto>> GetOneAsync(int id)
        {
            if (id < 0)
                return Result<TResponseDto>.Failure(Error.RouteParamOutOfRange);

            var record = await _repository.GetOneAsync(id);
            if (record == null)
                return Result<TResponseDto>.Failure(Error.NotFound);

            var response = MapAsDto(record);

            return Result<TResponseDto>.Success(response);
        }


        public virtual async Task<Result<TResponseDto>> AddAsync(TRequestDto? requestDto)
        {
            var error = await ValidateEntity(requestDto);
            if (error != Error.None)
                return Result<TResponseDto>.Failure(error);

            var entity = MapAsEntity(requestDto!);

            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            var response = MapAsDto(entity);

            return Result<TResponseDto>.Success(response);
        }


        public virtual async Task<Result<TResponseDto>> UpdateAsync(int id, TRequestDto? requestDto)
        {
            var error = await ValidateEntity(requestDto, id);
            if (error != Error.None)
                return Result<TResponseDto>.Failure(error);

            var oldEntity = await _repository.GetOneAsync(id);
            if (oldEntity == null)
                return Result<TResponseDto>.Failure(Error.NotFound);

            var newEntity = (TEntity)MapToEntity(requestDto!, oldEntity);

            _repository.Update(newEntity);

            await _unitOfWork.SaveChangesAsync();

            return Result<TResponseDto>.Success();
        }

        public virtual async Task<Result<object>> DeleteAsync(int id)
        {
            var validationResult = await ValidateBeforeDelete(id);
            if (!validationResult.IsSuccessful)
                return Result<object>.Failure(validationResult.Error);

            var entity = validationResult.Value.Entity;
            var user = validationResult.Value.User;

            _repository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        protected virtual async Task<Result<(TEntity Entity, UserResponseDto User)>> ValidateBeforeDelete(int id)
        {
            if (id < 0)
                return Result<(TEntity Entity, UserResponseDto User)>.Failure(Error.RouteParamOutOfRange);

            var entity = await _repository.GetOneAsync(id);

            if (entity == null)
                return Result<(TEntity Entity, UserResponseDto User)>.Failure(Error.NotFound);

            var userResult = await _authService.GetCurrentUser();
            if (!userResult.IsSuccessful)
                return Result<(TEntity Entity, UserResponseDto User)>.Failure(userResult.Error);

            var user = userResult.Value;
            int? entityUserId = null;
            if (entity is IAuthEntity authEntity)
                entityUserId = authEntity.UserId;

            var premissionError = CheckUserPremission(user);
            if (premissionError != Error.None)
                return Result<(TEntity Entity, UserResponseDto User)>.Failure(premissionError);

            return Result<(TEntity Entity, UserResponseDto User)>.Success((entity, user));
        }


        protected Error CheckUserPremission(UserResponseDto user, int? entityUserId = null)
        {
            if (user.IsInRole(Roles.Admin))
                return Error.None;
            else if (user.IsInRole(Roles.User))
            {
                if (entityUserId == user.Id)
                    return Error.None;
                else
                    return AuthError.UserDoesNotHavePremissionToResource;
            }
            else
                return AuthError.UserDoesNotHaveSpecificRole;
        }

        protected virtual IEnumerable<TResponseDto> MapAsDto(IEnumerable<TEntity> records) => records.Select(entity => entity.AsDto<TResponseDto>());
        protected virtual TResponseDto MapAsDto(TEntity entity) => entity.AsDto<TResponseDto>();
        protected virtual TEntity MapAsEntity(IRequestDto requestDto) => requestDto.AsEntity<TEntity>();
        protected virtual IEntity MapToEntity(TRequestDto requestDto, TEntity oldEntity) => requestDto.MapTo(oldEntity);
        protected async Task<bool> IsEntityExistInDB<TSomeEntity>(int id)
                    where TSomeEntity : class =>
                    await _unitOfWork.GetRepository<TSomeEntity>().GetOneAsync(id) != null;

        // car and car model override
        protected virtual async Task<bool> IsSameEntityExistInDatabase(TRequestDto requestDto, int? id = null)
        {
            var records = await _repository.GetAllAsync();

            var result = records.Where(entity =>
                            {
                                if (entity is BaseEntity baseEntity && entity is INameableEntity nameableEntity)
                                {
                                    var isNotSameId = baseEntity.Id != id; 
                                    var isSameNames = String.Compare(
                                                        nameableEntity.Name,
                                                        ((INameableRequestDto)requestDto).Name,
                                                        StringComparison.OrdinalIgnoreCase) == 0;

                                    return isNotSameId && isSameNames;
                                }
                                return false;
                            }).Any();
            return result;
        }
        protected abstract Task<Error> ValidateEntity(IRequestDto? requestDto, int? id = null);
    }
}
