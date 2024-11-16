namespace Olivier.Dto
{
    public class ApiResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object Data { get; set; }
    }
}
