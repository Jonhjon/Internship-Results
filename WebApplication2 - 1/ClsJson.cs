namespace WebApplication2.Models
{
    public class ClsJson
    {
        public class ElectricPlasmaPot
        {
            public string? chDTM_C { get; set; }
            public string? chCycleNo { get; set; }
            public string? chBI_BatchNo { get; set; }
            public string? chCycleDTM_S { get; set; }
            public string? chDTM_Add { get; set; }
            public string? chDate { get; set; }
            public string? chResult_Content_1 { get; set; }
            public string? chResult_DTM_1 { get; set; }
            public string? chBatchNo { get; set; }
            public string? chResult_Content_2 { get; set; }
            public string? chCycleDTM_E { get; set; }
        }

        public class result
        {
            public bool IsSuccess { get; set; }
            public string? message { get; set; }
        }

    }
}
