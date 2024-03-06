namespace AkarSoft.Core.Utilities.Pager.ComplexTypes
{
    public class PagerResultViewModel<T>
    {
        public MetaData MetaData { get; }
        public T Data { get; }
        public PagerResultViewModel(MetaData metaData, T data)
        {
            MetaData = metaData;
            Data = data;
        }


    }
}
