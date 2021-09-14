namespace JobAds.Server.Features.Profiles
{
    using Data;
    using JobAds.Server.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProfileService : IProfileService
    {
        private readonly JobAdsDbContext dbContext;

        public ProfileService(JobAdsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProfileResponseModel> GetByUser(string userId)
        {
            var userProfile = await this.dbContext
                .Users
                .Where(u => u.Id == userId)
                .Select(u => new ProfileResponseModel
                {
                    UserName = u.UserName,
                    FullName = u.Profile.FullName,
                    AvatarUrl = u.Profile.AvatarUrl,
                    Gender = u.Profile.Gender.ToString(),
                    About = u.Profile.About
                })
                .FirstOrDefaultAsync();

            return userProfile;
        }

        public async Task<bool> Update(
            string userId, 
            string email, 
            string userName, 
            string fullName, 
            string avatarUrl, 
            Gender gender, 
            string about)
        {
            var profile = await this.dbContext
                .Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();


        }
    }
}
