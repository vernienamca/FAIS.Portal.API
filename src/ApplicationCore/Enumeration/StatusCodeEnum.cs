using System.ComponentModel;

namespace FAIS.ApplicationCore.Enumeration
{
    public enum StatusCodeEnum
    {
        [Description("Open")]
        Open = 2,
        [Description("For Review")]
        ForReview = 3,
        [Description("Reviewed")]
        Reviewed = 4,
        [Description("For Endorsement")]
        ForEndorsement = 5,
        [Description("Endorsed")]
        Endorsed = 6
    }
}
