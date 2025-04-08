using TeslaGoAPI.DB.Entities;
using TeslaGoAPI.DB.Entities.Abstract;
using TeslaGoAPI.Logic.Dto.Abstract;
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
    public abstract class GenericService<TEntity, TRequestDto, TUpdateRequestDto, TResponseDto, TQuery>
        (IUnitOfWork unitOfWork, IAuthService authService)
        : IGenericService<TEntity, TRequestDto, TUpdateRequestDto, TResponseDto, TQuery>
        where TEntity : class, IEntity
        where TRequestDto : class, IRequestDto
        where TUpdateRequestDto : class, IRequestDto
        where TResponseDto : class, IResponseDto
        where TQuery : QueryObject
    {
        protected readonly IUnitOfWork _unitOfWork = unitOfWork;
        protected readonly IAuthService _authService = authService;
        protected readonly IGenericRepository<TEntity> _repository = unitOfWork.GetRepository<TEntity>();

        public virtual async Task<Result<IEnumerable<TResponseDto>>> GetAllAsync(TQuery query)
        {
            var records = await _repository.GetAllAsync(q =>
            {
                IQueryable<TEntity> queryable = q;
                if (q is IQueryable<INameableEntity> queryableNameable && query is INameableQuery nameableQuery)
                {
                    queryable = q.ByName(nameableQuery);
                }
                return queryable
                    .Where(x => !(x is ISoftDeleteable) || !((ISoftDeleteable)x).IsDeleted)
                    .SortBy(query.SortBy, query.SortDirection)
                    .GetPage(query.PageNumber, query.PageSize);

            });
            var response = MapAsDto(records);
            return Result<IEnumerable<TResponseDto>>.Success(response);
        }

        public virtual async Task<Result<TResponseDto>> GetOneAsync(int id)
        {
            if (id < 0)
                return Result<TResponseDto>.Failure(Error.RouteParamOutOfRange);

            var entity = await _repository.GetOneAsync(id);
            if (entity == null)
                return Result<TResponseDto>.Failure(Error.NotFound);

            if(entity is ISoftDeleteable softDeleteable && softDeleteable.IsDeleted)
                return Result<TResponseDto>.Failure(Error.NotFound);

            var response = MapAsDto(entity);

            return Result<TResponseDto>.Success(response);
        }


        public virtual async Task<Result<object>> AddAsync(TRequestDto? requestDto)
        {
            var result = await ValidateEntity(requestDto);
            if (!result.IsSuccessful)
                return Result<object>.Failure(result.Error);

            var entity = MapAsEntity(requestDto!);

            await _repository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        public virtual async Task<Result<object>> UpdateAsync(int id, TUpdateRequestDto? requestDto)
        {
            var result = await ValidateEntity(requestDto, id);
            if (!result.IsSuccessful)
                return Result<object>.Failure(result.Error);

            var oldEntity = await _repository.GetOneAsync(id);
            if (oldEntity == null)
                return Result<object>.Failure(Error.NotFound);

            var newEntity = (TEntity)MapToEntity(requestDto!, oldEntity);

            if (newEntity is IUpdateableEntity updateableEntity)
            {
                updateableEntity.UpdateDate = DateTime.Now;
                updateableEntity.IsUpdated = true;
            }

            _repository.Update(newEntity);

            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        public virtual async Task<Result<object>> DeleteAsync(int id)
        {
            var validationResult = await ValidateBeforeDelete(id);
            if (!validationResult.IsSuccessful)
                return Result<object>.Failure(validationResult.Error);

            var entity = validationResult.Value;

            if(entity is ISoftDeleteable softDeleteableEntity)
            {
                softDeleteableEntity.DeleteDate = DateTime.Now;
                softDeleteableEntity.IsDeleted = true;
                _repository.Update(entity);
            }
            else
            {
                _repository.Delete(entity);
            }

            await _unitOfWork.SaveChangesAsync();

            return Result<object>.Success();
        }

        protected virtual async Task<Result<TEntity>> ValidateBeforeDelete(int id)
        {
            if (id < 0)
                return Result<TEntity>.Failure(Error.RouteParamOutOfRange);

            var entity = await _repository.GetOneAsync(id);

            if (entity == null)
                return Result<TEntity>.Failure(Error.NotFound);

            int? entityUserId = null;
            if (entity is IAuthEntity authEntity)
                entityUserId = authEntity.UserId;

            if (entity is ISoftDeleteable softDeleteableEntity && softDeleteableEntity.IsDeleted)
                return Result<TEntity>.Failure(Error.NotFound);

            var premissionResult = await CheckUserPremission(entityUserId);
            if(!premissionResult.IsSuccessful)
                return Result<TEntity>.Failure(premissionResult.Error);

            return Result<TEntity>.Success(entity);
        }


        protected async Task<Result<object>> CheckUserPremission(int? entityUserId = null)
        {
            var userResult = await _authService.GetCurrentUser();
            if (!userResult.IsSuccessful)
                return Result<object>.Failure(userResult.Error);

            var user = userResult.Value;    

            if (user.IsInRole(Roles.Admin))
                return Result<object>.Success();

            else if (user.IsInRole(Roles.User))
            {
                if (entityUserId == user.Id)
                    return Result<object>.Success();
                else
                    return Result<object>.Failure(AuthError.UserDoesNotHavePremissionToResource);
            }
            else
                return Result<object>.Failure(AuthError.UserDoesNotHaveSpecificRole);
        }

        protected virtual IEnumerable<TResponseDto> MapAsDto(IEnumerable<TEntity> records) => records.Select(entity => entity.AsDto<TResponseDto>());
        protected virtual TResponseDto MapAsDto(TEntity entity) => entity.AsDto<TResponseDto>();
        protected virtual TEntity MapAsEntity(IRequestDto requestDto) => requestDto.AsEntity<TEntity>();
        protected virtual IEntity MapToEntity(TUpdateRequestDto requestDto, TEntity oldEntity) => requestDto.MapTo(oldEntity);
        
        protected async Task<bool> NotExistInDB<TSomeEntity>(int id) where TSomeEntity : BaseEntity
        {
            var entity = await _unitOfWork.GetRepository<TSomeEntity>().GetOneAsync(id);
            return entity == null || (entity is ISoftDeleteable sd && sd.IsDeleted);
        }
        protected async Task<bool> NotExistInDB<TSomeEntity>(List<int> ids) where TSomeEntity : BaseEntity
        {
            var entities = await _unitOfWork.GetRepository<TSomeEntity>()
                .GetAllAsync(q => q.Where(x => ids.Contains(x.Id)));

            return ids.Count != entities.Select(x => !(x is ISoftDeleteable sd) || !sd.IsDeleted).Count();
        }

        // car and car model override
        protected virtual async Task<Result<bool>> IsSameEntityExistInDatabase(IRequestDto requestDto, int? id = null)
        {
            var records = await _repository.GetAllAsync();

            var result = records.Where(entity =>
            {
                if (entity is BaseEntity baseEntity && entity is INameableEntity nameableEntity && requestDto is INameableRequestDto)
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
            return Result<bool>.Success(result);
        }
        protected virtual async Task<Result<TEntity?>> ValidateEntity(IRequestDto? requestDto, int? id = null)
        {
            if (id != null && id < 0)
                return Result<TEntity?>.Failure(Error.RouteParamOutOfRange);

            if (requestDto == null)
                return Result<TEntity?>.Failure(Error.NullParameter);

            var isExistResult = await IsSameEntityExistInDatabase(requestDto, id);
            if (!isExistResult.IsSuccessful)
                return Result<TEntity?>.Failure(isExistResult.Error);

            if(isExistResult.Value)
                return Result<TEntity?>.Failure(Error.SuchEntityExistInDb);

            TEntity? entity = null;
            int? entityUserId = null;
            if (id != null)
            {
                entity = await _repository.GetOneAsync((int)id);
                if (entity == null)
                    return Result<TEntity?>.Failure(Error.NotFound);

                if (entity is IAuthEntity authEntity)
                    entityUserId = authEntity.UserId;

                if(entity is ISoftDeleteable softDeleteableEntity && softDeleteableEntity.IsDeleted)
                    return Result<TEntity?>.Failure(Error.NotFound);
            }
                
            var premissionResult = await CheckUserPremission(entityUserId);
            if(!premissionResult.IsSuccessful)
                return Result<TEntity?>.Failure(premissionResult.Error);

            return Result<TEntity?>.Success();
        }

        protected void DeleteCarsAndReservations(IGenericRepository<Car> carsRepository, IEnumerable<Car> carsToDelete)
        {
            foreach (var car in carsToDelete)
            {
                car.IsDeleted = true;
                car.DeleteDate = DateTime.Now;

                car.Model.IsDeleted = true;
                car.Model.DeleteDate = DateTime.Now;

                foreach (var res in car.Reservations)
                {
                    res.IsDeleted = true;
                    res.DeleteDate = DateTime.Now;
                }

                carsRepository.Update(car);
            }
        }
    }
}
