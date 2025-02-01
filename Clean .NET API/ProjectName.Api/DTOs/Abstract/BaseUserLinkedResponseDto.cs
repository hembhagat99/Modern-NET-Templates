namespace ProjectName.Api.DTOs.Abstract
{
    public abstract class BaseUserLinkedResponseDto<TKey> :  BaseResponseDto<TKey>
    {
        public string UserId { get; set; }
    }
}
