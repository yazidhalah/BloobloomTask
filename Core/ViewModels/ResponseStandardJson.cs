namespace Core.ViewModels
{
    public class ResponseStandardJson<T>
    {

        public bool Success { get; set; }
        public int Code { get; set; }
        public object Message { get; set; }
        public T Result { get; set; }
    }

    public class ResponseLoginJson
    {

        public bool Success { get; set; }
        public int Code { get; set; }
        public object Message { get; set; }
        public string Token { get; set; }
    }

}
