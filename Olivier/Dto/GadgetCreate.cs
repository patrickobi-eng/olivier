namespace Olivier.Dto
{
        public class GadgetCreate
        {

            public string BrandName { get; set; }
            public string colour { get; set; }
            public bool IsNew { get; set; }
        }
        public class GadgetResponse
        {
            public int Id { get; set; }
            public string BrandName { get; set; }
            public string colour { get; set; }
            public bool IsNew { get; set; }
        }
        public class GadgetUpdate
        {
            public int Id { get; set; }
            public string BrandName { get; set; }
            public string colour { get; set; }
            public bool IsNew { get; set; }
        }
        public class GadgetDelete
        {
            public int Id { get; set; }
            public string BrandName { get; set; }
            public string colour { get; set; }
            public bool IsNew { get; set; }
        }
    
}

