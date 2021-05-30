using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiExample.Base.Attributes;
using ApiExample.Base.Models;
using ApiExample.Base.Repositories;
using ApiExample.ViewModels.Comments;
using ApiExample.ViewModels.Publications;
using Microsoft.AspNetCore.Mvc;

namespace ApiExample.Chat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicationsController : Controller
    {
        #region Private Fields

        private readonly ICommentsRepository comments;
        private readonly IPublicationsRepository publications;

        #endregion Private Fields

        #region Public Constructors

        public PublicationsController(IPublicationsRepository publications, ICommentsRepository comments)
        {
            this.publications = publications;
            this.comments = comments;
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpPost("{id}/comment")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PublicationVM>> CommentAsync([FromRoute][GuidId] string id, CreateCommentVM createCommentVM)
        {
            var publication = await publications.GetAsync(id);
            if (publication == null) return NotFound();
            var created = await comments.CreateAsync(createCommentVM.ToModel(id));
            return Ok(new CommentVM().Assign(created));
        }

        [HttpPost("Post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PublicationVM>> CreatePublication([FromBody] CreatePublicationVM createVM)
        {
            if (string.IsNullOrWhiteSpace(createVM.Content) && (createVM.Image == null || createVM.Image == Array.Empty<byte>()))
            {
                return BadRequest();
            }
            var created = await publications.CreateAsync(createVM.ToModel());
            return Ok(new PublicationVM().Assign(created, 0));
        }

        [HttpGet("{id}/Image")]
        [ProducesResponseType(typeof(byte[]), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DownloadImageAsync([FromRoute][GuidId] string id)
        {
            var image = await publications.GetImageAsync(id);
            if (image == null) return NotFound();
            return new FileContentResult(image, "image/jpeg");
        }

        [HttpGet("FromDateTime")]
        public async Task<ActionResult<List<PublicationVM>>> GetFromAsync([FromQuery] DateTime? takeFrom = null, [ForbidNegative] int skip = 0, int take = 10)
        {
            List<PublicationVM> result = new();

            List<Publication> results = await publications.GetFromPublicationDateAsync(takeFrom ?? DateTime.UtcNow.AddDays(-1), skip, take);

            foreach (var model in results)
            {
                result.Add(new PublicationVM().Assign(model, comments.CountByPublication(model.PublicationId)));
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PublicationVM>> GetPublicationAsync([FromRoute][GuidId] string id)
        {
            var model = await publications.GetAsync(id);
            if (model == null) return NotFound();
            return Ok(new PublicationVM().Assign(model, comments.CountByPublication(model.PublicationId)));
        }

        #endregion Public Methods
    }
}