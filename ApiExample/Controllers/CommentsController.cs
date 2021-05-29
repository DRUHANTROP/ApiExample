using System.Collections.Generic;
using System.Threading.Tasks;
using ApiExample.Attributes;
using ApiExample.Repositories;
using ApiExample.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc;

namespace ApiExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : Controller
    {
        #region Private Fields

        private readonly ICommentsRepository comments;
        private readonly IPublicationsRepository publications;

        #endregion Private Fields

        #region Public Constructors

        public CommentsController(IPublicationsRepository publications, ICommentsRepository comments)
        {
            this.publications = publications;
            this.comments = comments;
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CommentVM>> GetCommentAsync([FromRoute][GuidId] string id)
        {
            var comment = await comments.GetAsync(id);
            if (comment == null) return NotFound();
            return Ok(new CommentVM().Assign(comment));
        }

        [HttpGet("FromPublication/{publicationId}")]
        [ProducesResponseType(200)]
        public ActionResult<List<CommentVM>> GetComments([FromRoute][GuidId] string publicationId, int skip = 0, int take = 10)
        {
            var models = comments.GetByPublication(publicationId, skip, take);
            List<CommentVM> result = new();
            foreach (var comm in models)
            {
                result.Add(new CommentVM().Assign(comm));
            }
            return Ok(result);
        }

        #endregion Public Methods
    }
}