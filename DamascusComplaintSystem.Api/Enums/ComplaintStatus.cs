using System.ComponentModel;

namespace DamascusComplaintSystem.Api.Enums
{
    public enum ComplaintStatus
    {
        [Description("تم الاستلام")]
        Received = 1,

        [Description("قيد المعالجة")]
        UnderProcessing = 2,

        [Description("تم الحل")]
        Resolved = 3,

        [Description("مرفوضة")]
        Rejected = 4
    }
}
