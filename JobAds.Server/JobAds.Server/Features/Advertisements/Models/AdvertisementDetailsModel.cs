namespace JobAds.Server.Features.Advertisements.Models
{
    public class AdvertisementDetailsModel : AdvertisementListingModel
    {
        public string Type { get; set; }

        public string Category { get; set; }

        public string WorkingModel { get; set; }

        public string CompanyName { get; set; }

        public string UserId { get; set; }
    }
}