namespace JobAds.Server.Features.Advertisements
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdvertisementService
    {
        Task<int> Create(string title, string description, string type, string category, string workingModel, string imageUrl, string companyName, string userId);

        // Task<IEnumerable<AdvertisementListingModel>> GetMine(string userId);

        Task<IEnumerable<AdvertisementListingModel>> GetAll();

        Task<AdvertisementDetailsModel> GetById(int id);

        Task<bool> Update(int id, string title, string description, string type, string categoty, string workingModel, string imageUrl, string userId);

        Task<bool> Delete(int id, string userId);
    }
}
