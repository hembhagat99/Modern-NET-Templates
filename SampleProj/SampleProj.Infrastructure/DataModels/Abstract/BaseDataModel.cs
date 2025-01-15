namespace SampleProj.Infrastructure.DataModels.Abstract
{
    internal abstract class BaseDataModel<TKey>
    {
        public TKey Id { get; set; }
    }
}
