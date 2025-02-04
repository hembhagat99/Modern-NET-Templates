namespace ProjectName.Api.DTOs.Abstract
{
    public abstract class BaseResponseDto<TKey>
    {
        public TKey Id { get; set; }
    }
}
