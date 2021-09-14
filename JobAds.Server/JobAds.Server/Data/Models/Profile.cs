namespace JobAds.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Validation.User;

    // Profile is owned by the user, the're saved in the same table
    public class Profile
    {
        [MaxLength(MaxFullNameLength)]
        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public Gender Gender { get; set; }

        [MaxLength(MaxAboutLenght)]
        public string About { get; set; }
    }
}
