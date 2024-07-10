using System.ComponentModel;

namespace FAIS.ApplicationCore.Enumeration
{
    public enum StatusCodeEnum
    {
        [Description("New Asset")]
        NewAsset = 1,
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