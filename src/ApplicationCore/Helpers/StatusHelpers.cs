using FAIS.ApplicationCore.Enumeration;

namespace FAIS.ApplicationCore.Helpers
{
    /// <summary>
    /// The helper class for user status.
    /// </summary>
    public static class StatusHelpers
    {
        /// <summary>
        /// Gets user status description.
        /// </summary>
        public static string GetUserStatus(int userStatus)
        {
            if (userStatus == 1)
                return UserStatusEnum.Active.ToString();
            else if (userStatus == 2)
                return UserStatusEnum.Inactive.ToString();
            else
                return UserStatusEnum.Locked.ToString();
        }
    }
}
