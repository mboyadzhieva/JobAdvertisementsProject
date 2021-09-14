namespace JobAds.Server.Features.Profiles.Models
{
    using JobAds.Server.Data.Models;
    using System.ComponentModel.DataAnnotations;

    using static Data.Validation.User;

    public class UpdateProfileRequestModel
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        [MaxLength(MaxFullNameLength)]
        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public Gender Gender { get; set; }

        [MaxLength(MaxAboutLenght)]
        public string About { get; set; }
    }
}
