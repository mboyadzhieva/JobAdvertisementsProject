namespace JobAds.Server.Features.Advertisements.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Validation.Advertisement;
    public class CreateAdRequestModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string WorkingModel { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
