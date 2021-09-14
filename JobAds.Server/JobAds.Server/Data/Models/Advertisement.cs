namespace JobAds.Server.Data.Models
{
    using Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Validation.Advertisement;

    public class Advertisement : DeletableEntity
    {
        public int Id { get; set; }

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

        public IEnumerable<User> AppliedUsers { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
