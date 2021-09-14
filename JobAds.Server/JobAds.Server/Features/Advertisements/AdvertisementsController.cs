namespace JobAds.Server.Features.Advertisements
{
    using Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Infrastructure.Services;

    using static Infrastructure.WebConstants;

    [Authorize]
    public class AdvertisementsController : ApiController
    {
        private readonly IAdvertisementService advertisement;
        private readonly ICurrentUserService currentUser;

        public AdvertisementsController(
            IAdvertisementService advertisementService, 
            ICurrentUserService currentUser
            )
        {
            this.advertisement = advertisementService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<AdvertisementListingModel>> Get()
            => await this.advertisement.GetAll();

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<AdvertisementDetailsModel>> GetById(int id)
            => await this.advertisement.GetById(id);
        

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateAdRequestModel model)
        {
            var userId = this.currentUser.GetId();
            var userName = this.currentUser.GetUserName();

            var id = await this.advertisement.Create(
                model.Title,
                model.Description,
                model.Type,
                model.Category,
                model.WorkingModel,
                model.ImageUrl,
                userName,
                userId);

            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Update(int id, UpdateAdRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var updated = await this.advertisement.Update(
                id, 
                model.Title,
                model.Description, 
                model.Type,
                model.Category,
                model.WorkingModel,
                model.ImageUrl,
                userId);

            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.currentUser.GetId();

            var deleted = await this.advertisement.Delete(id, userId);

            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        } 
    }
}
