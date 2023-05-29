namespace MauiAppExample.Model
{
    public class ApiData<T>
    {
        public int Id { get; set; }
        public T Attributes { get; set; }
    }
}