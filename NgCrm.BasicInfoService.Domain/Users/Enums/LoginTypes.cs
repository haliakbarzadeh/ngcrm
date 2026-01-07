using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Users.Enums
{
    public enum LoginTypes
    {
        [Description("ActiveDirectory")]
        ActiveDirectory = 1,

        [Description("OTP")]
        Otp = 2,

    }
}
