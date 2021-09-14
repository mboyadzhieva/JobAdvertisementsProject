namespace JobAds.Server.Features.Profiles
{
    using Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Infrastructure.Services;

    public class ProfileController : ApiController
    {
        private readonly IProfileService profiles;
        private readonly ICurrentUserService currentUser;

        public ProfileController(IProfileService profile, ICurrentUserService currentUser)
        {
            this.profiles = profile;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProfileResponseModel>> GetMyProfile()
        {
            var userId = currentUser.GetId();

            return await this.profiles.GetByUser(userId); ;
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(UpdateProfileRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var updated = await this.profiles.Update(
                userId,
                model.Email,
                model.UserName,
                model.FullName,
                model.AvatarUrl,
                model.Gender,
                model.About);

            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
