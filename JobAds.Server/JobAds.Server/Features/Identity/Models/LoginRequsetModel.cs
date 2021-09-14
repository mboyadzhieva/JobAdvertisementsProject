namespace JobAds.Server.Features.Identity.Models
{
    using System.ComponentModel.DataAnnotations;
    public class LoginRequsetModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
