namespace WebApplication3.Models
{
    public class ClJson
    {
        public class Insert
        {
            public string? TurningDateTime { get; set; }
            public string? ChartNo { get; set; }
            public string? StaffNumber { get; set; }
            public List<Value>? Value { get; set; }
        }
        public class Value
        {
            public HR? HR { get; set; }
            public Resp? Resp { get; set; }
            public SpO2? SpO2 { get; set; }
            public SpO2_PR? SpO2_PR { get; set; }
            public Systolic? Systolic { get; set; }
            public Diastolic? Diastolic { get; set; }
            public Mean? Mean { get; set; }
            public NIBP_PR? NIBP_PR { get; set; }
            public Continuous_Temp? Continuous_Temp { get; set; }
            public Spot_Temp? Spot_Temp { get; set; }
            public BloodGlucose? BloodGlucose { get; set; }
            public EWS? EWS { get; set; }
            public ECG_Status? ECG_Status { get; set; }
            public SpO2_Status? SpO2_Status { get; set; }
            public NIBP_Status? NIBP_Status { get; set; }
            public wf_Lead_I? wf_Lead_I { get; set; }
            public wf_Lead_II? wf_Lead_II { get; set; }
            public wf_Lead_III? wf_Lead_III { get; set; }
            public wf_Lead_aVR? wf_Lead_aVR { get; set; }
            public wf_Lead_aVL? wf_Lead_aVL { get; set; }
            public wf_Lead_aVF? wf_Lead_aVF { get; set; }
            public wf_Lead_V1? wf_Lead_V1 { get; set; }
            public wf_Lead_V2? wf_Lead_V2 { get; set; }
            public wf_Lead_V3? wf_Lead_V3 { get; set; }
            public wf_Lead_V4? wf_Lead_V4 { get; set; }
            public wf_Lead_V5? wf_Lead_V5 { get; set; }
            public wf_Lead_V6? wf_Lead_V6 { get; set; }
            public wf_Resp? wf_Resp { get; set; }
            public wf_Pleth? wf_Pleth { get; set; }
            public PatientInfo? PatientInfo { get; set; }
            public NurseInfo? NurseInfo { get; set; }
            public FacilityInfo? FacilityInfo { get; set; }
            public DeviceInfo? DeviceInfo { get; set; }
            public GCS? GCS { get; set; }
            public Pain? Pain { get; set; }
            public Poop? Poop { get; set; }
            public Body? Body { get; set; }
            public Muscle? Muscle { get; set; }
            public Pupil_Sign? Pupil_Sign { get; set; }
            public ACVPU? ACVPU { get; set; }
            public Oxygen? Oxygen { get; set; }
            public Intake? Intake { get; set; }
            public Outtake? Outtake { get; set; }
        }

        public class HR
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
        public class Resp : HR { }
        public class SpO2 : HR { }
        public class SpO2_PR : HR { }
        public class Systolic : HR { }
        public class Diastolic : HR { }
        public class Mean : HR { }
        public class NIBP_PR : HR { }
        public class Continuous_Temp : HR { }
        public class Spot_Temp : HR { }
        public class BloodGlucose : HR { }

        public class EWS
        {
            public string? name { get; set; }
            public List<EWSValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class EWSValue
        {
            public string? Risk { get; set; }
            public string? ScoreSummary { get; set; }
            public string? RespScore { get; set; }
            public string? SpO2_1_Score { get; set; }
            public string? SpO2_2_Score { get; set; }
            public string? OxygenScore { get; set; }
            public string? TempScore { get; set; }
            public string? SystolicScore { get; set; }
            public string? HRScore { get; set; }
            public string? ConsciousScore { get; set; }
        }

        public class ECG_Status
        {
            public string? name { get; set; }
            public string? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class SpO2_Status : ECG_Status { }
        public class NIBP_Status : ECG_Status { }

        public class wf_Lead_I : ECG_Status
        {
            public string? length { get; set; }
            public string? sn { get; set; }
            public string? wf_type { get; set; }
        }
        public class wf_Lead_II : wf_Lead_I { }
        public class wf_Lead_III : wf_Lead_I { }
        public class wf_Lead_aVR : wf_Lead_I { }
        public class wf_Lead_aVL : wf_Lead_I { }
        public class wf_Lead_aVF : wf_Lead_I { }
        public class wf_Lead_V1 : wf_Lead_I { }
        public class wf_Lead_V2 : wf_Lead_I { }
        public class wf_Lead_V3 : wf_Lead_I { }
        public class wf_Lead_V4 : wf_Lead_I { }
        public class wf_Lead_V5 : wf_Lead_I { }
        public class wf_Lead_V6 : wf_Lead_I { }
        public class wf_Resp : wf_Lead_I { }
        public class wf_Pleth : wf_Lead_I { }

        public class PatientInfo
        {
            public string? name { get; set; }
            public List<PatientInfoValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class PatientInfoValue
        {
            public string? ID { get; set; }
            public string? ChartNo { get; set; }
            public string? Birth { get; set; }
            public string? Gender { get; set; }
            public string? Age { get; set; }
            public string? Name { get; set; }
        }
        public class NurseInfo
        {
            public string? name { get; set; }
            public List<NurseInfoValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class NurseInfoValue
        {
            public string? StaffNumber { get; set; }
        }
        public class FacilityInfo
        {
            public string? name { get; set; }
            public List<FacilityInfoValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class FacilityInfoValue
        {
            public string? Hospital { get; set; }
            public string? Branch { get; set; }
            public string? Department { get; set; }
            public string? Site { get; set; }
            public string? Room { get; set; }
            public string? Bed { get; set; }
        }
        public class DeviceInfo
        {
            public string? name { get; set; }
            public List<DeviceInfoValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class DeviceInfoValue
        {
            public string? ModelName { get; set; }
            public string? SoftwareVersion { get; set; }
            public string? PCode { get; set; }
            public string? EthMac { get; set; }
            public string? EthIP { get; set; }
            public string? WiFiMac { get; set; }
            public string? WiFiIP { get; set; }
            public string? PatientType { get; set; }
            public string? FilterMode { get; set; }
            public string? Battery { get; set; }
            public string? S1Version { get; set; }
            public string? C2Version { get; set; }
        }
        public class GCS
        {
            public string? name { get; set; }
            public List<GCSValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class GCSValue
        {
            public string? Summary { get; set; }
            public string? E { get; set; }
            public string? V { get; set; }
            public string? M { get; set; }
        }
        public class Pain
        {
            public string? name { get; set; }
            public string? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class Poop
        {
            public string? name { get; set; }
            public List<PoopValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class PoopValue
        {
            public string? YesterdayTimes { get; set; }
            public string? YesterdayType { get; set; }
            public string? TodayTimes { get; set; }
            public string? TodayType { get; set; }
        }
        public class Body
        {
            public string? name { get; set; }
            public List<BodyValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class BodyValue
        {
            public string? Height { get; set; }
            public string? Weight { get; set; }
            public string? AbdominalGirth { get; set; }
        }
        public class Muscle
        {
            public string? name { get; set; }
            public List<MuscleValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class MuscleValue
        {
            public string? LA { get; set; }
            public string? LL { get; set; }
            public string? RA { get; set; }
            public string? RL { get; set; }
        }
        public class Pupil_Sign
        {
            public string? name { get; set; }
            public List<Pupil_SignValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class Pupil_SignValue
        {
            public string? OSS { get; set; }
            public string? OS { get; set; }
            public string? OSSize { get; set; }
            public string? ODS { get; set; }
            public string? OD { get; set; }
            public string? ODSize { get; set; }
        }
        public class ACVPU
        {
            public string? name { get; set; }
            public string? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class Oxygen
        {
            public string? name { get; set; }
            public string? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class Intake
        {
            public string? name { get; set; }
            public List<IntakeValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class IntakeValue
        {
            public string? IVFluid { get; set; }
            public string? Ingest { get; set; }
        }
        public class Outtake
        {
            public string? name { get; set; }
            public List<OuttakeValue>? value { get; set; }
            public string? unit { get; set; }
            public string? update_time { get; set; }
            public string? bss_objid { get; set; }
        }
        public class OuttakeValue
        {
            public string? Urea { get; set; }
            public string? Drainage { get; set; }
        }

        public class result
        {
            public int? index { get; set; }
            public string? status { get; set; }
            public string? message { get; set; }
        }



        public class Rootobject
        {
            public string? TurningDateTime { get; set; }
            public string? ChartNo { get; set; }
            public string? StaffNumber { get; set; }
            public HR? Spo2 { get; set; }
        }




    }
}
