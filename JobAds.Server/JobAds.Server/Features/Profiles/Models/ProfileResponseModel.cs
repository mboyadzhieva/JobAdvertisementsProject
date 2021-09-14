namespace JobAds.Server.Features.Profiles.Models
{
    using Data.Models;

    public class ProfileResponseModel
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Gender { get; set; }

        public string About { get; set; }
    }
}
