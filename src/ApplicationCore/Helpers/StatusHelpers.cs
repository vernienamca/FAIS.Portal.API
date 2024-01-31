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
        /// <param name="statusCode">The status code.</param>
        /// </summary>
        public static string GetUserStatus(int statusCode)
        {
            if (statusCode == 1)
                return UserStatusEnum.Active.ToString();
            else if (statusCode == 2)
                return UserStatusEnum.Inactive.ToString();
            else
                return UserStatusEnum.Locked.ToString();
        }
    }
}
