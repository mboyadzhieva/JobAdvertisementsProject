namespace JobAds.Server.Features.Advertisements
{
    using Models;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdvertisementService : IAdvertisementService
    {
        private readonly JobAdsDbContext dbContext;

        public AdvertisementService(JobAdsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Create(
            string title,
            string description,
            string type,
            string category,
            string workingModel,
            string imageUrl,
            string companyName,
            string userId)
        {
            var advertisement = new Advertisement
            {
                Title = title,
                Description = description,
                Type = type,
                Category = category,
                WorkingModel = workingModel,
                ImageUrl = imageUrl,
                AppliedUsers = new List<User>(),
                CompanyName = companyName,
                UserId = userId
            };

            this.dbContext.Add(advertisement);

            await this.dbContext.SaveChangesAsync();

            return advertisement.Id;
        }

        public async Task<AdvertisementDetailsModel> GetById(int id)
        {
            return await this.dbContext.Advertisements
                .Where(a => a.Id == id)
                .Select(a => new AdvertisementDetailsModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    ImageUrl = a.ImageUrl,
                    Type = a.Type,
                    Category = a.Category,
                    WorkingModel = a.WorkingModel,
                    CompanyName = a.User.UserName,
                    UserId = a.UserId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AdvertisementListingModel>> GetAll()
        {
            return await this.dbContext
                .Advertisements
                .OrderByDescending(a => a.CreatedOn)
                .Select(c => new AdvertisementListingModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<bool> Update(
            int id, 
            string title, 
            string description, 
            string type, 
            string category, 
            string workingModel, 
            string imageUrl, 
            string userId)
        {
            var advertisement = await this.GetByIdAndUserId(id, userId);

            if (advertisement != null)
            {
                advertisement.Title = title;
                advertisement.Description = description;
                advertisement.Type = type;
                advertisement.Category = category;
                advertisement.WorkingModel = workingModel;
                advertisement.ImageUrl = imageUrl;
                await this.dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id, string userId)
        {
            var advertisement = await this.GetByIdAndUserId(id, userId);

            if (advertisement != null)
            {
                this.dbContext.Advertisements.Remove(advertisement);
                await this.dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        private async Task<Advertisement> GetByIdAndUserId(int id, string userId)
        {
            var advertisement = await this.dbContext
                .Advertisements
                .Where(a => a.Id == id && a.UserId == userId)
                .FirstOrDefaultAsync();

            return advertisement;
        }
    }
}
