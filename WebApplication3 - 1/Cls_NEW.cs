using static WebApplication3.Models.ClJson;

namespace WebApplication3.Models
{
    public class Cls_NEW
    {

        public class Rootobject
        {
            public Class1[]? Property1 { get; set; }
        }

        public class Class1
        {
            public string? TurningDateTime { get; set; }
            public string? ChartNo { get; set; }
            public string? StaffNumber { get; set; }
            public Value[]? Value { get; set; }

        }

        public class Value
        {       
            public HR? HR { get; set; }
            public Resp? Resp { get; set; }
            public SpO2? SpO2 { get; set; }
            public Systolic? Systolic { get; set; }
            public Diastolic? Diastolic { get; set; }
            public Mean? Mean { get; set; }
            public Spot_Temp? Spot_Temp { get; set; }
            public Pain? Pain { get; set; }
        }


        public class SpO2 : Basic_Value { }
        public class Systolic : Basic_Value { }
        public class Mean : Basic_Value { }
        public class HR : Basic_Value { }
        public class Spot_Temp : Basic_Value { }
        public class Resp : Basic_Value { }
        public class Diastolic : Basic_Value { }

        public class Basic_Value
        {
            public string? name { get; set; }
            public string? value { get; set; }
            public string? unit { get; set; }
            public string? up_bound { get; set; }
            public string? low_bound { get; set; }
            public string? alarm { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class Pain
        {
            public string? name { get; set; }
            public string? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
    }
}
