namespace JobAds.Server.Features.Profiles
{
    using JobAds.Server.Data.Models;
    using JobAds.Server.Features.Profiles.Models;
    using System.Threading.Tasks;

    public interface IProfileService
    {
        Task<ProfileResponseModel> GetByUser(string userId);

        Task<bool> Update(string userId, string email, string userName, string fullName, string avatarUrl, Gender gender, string about);
    }
}
