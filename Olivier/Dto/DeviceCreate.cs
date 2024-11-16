namespace Olivier.Dto
{
    public class DeviceCreate
    {
        
        public string BrandName { get; set; }
        public string colour { get; set; }
        public bool IsNew { get; set; }
    } 
    public class DeviceResponse 
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string colour { get; set; }
        public bool IsNew { get; set; }
    }
    public class DeviceUpdate
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string colour { get; set; }
        public bool IsNew { get; set; }
    }
    public class DeviceDelete
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string colour { get; set; }
        public bool IsNew { get; set; }
    }
}
