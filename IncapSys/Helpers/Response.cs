namespace IncapSys.Helpers
{
    public class Response<T>
    {
        public required T Result { get; set; }
        public bool IsSucces {  get; set; }
        public required string Message { get; set; }
    }
}
