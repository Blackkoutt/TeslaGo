namespace TeslaGoAPI.DB.Entities.Abstract
{
    public interface ISoftDeleteable
    {
        bool IsDeleted { get; set; }
        DateTime? DeleteDate { get; set; }
    }
}
