using System.Text.RegularExpressions;

namespace InimcoBackend.Entities.Enums
{
    /// <summary>
    /// List of supported social media accounts in the app
    /// </summary>
    public enum SocialNetworkEnum
    {
        Linkedin = 0,
        Facebook,
        Twitter,
        Medium
    }

    public static class SocialNetworkEnumExtensions
    {
        public static string GetName(this SocialNetworkEnum network)
        {
            switch (network)
            {
                case SocialNetworkEnum.Linkedin:
                    return "Linkedin";
                case SocialNetworkEnum.Facebook:
                    return "Facebook";
                case SocialNetworkEnum.Twitter:
                    return "Twitter";
                case SocialNetworkEnum.Medium:
                    return "Medium";
            }

            return string.Empty;
        }
    }
}
