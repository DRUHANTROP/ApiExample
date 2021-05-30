using System.Collections.Generic;
using System.Threading.Tasks;
using ApiExample.Base.Attributes;
using ApiExample.Base.Repositories;
using ApiExample.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc;

namespace ApiExample.Chat.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : Controller
    {
        #region Private Fields

        private readonly ICommentsRepository comments;

        #endregion Private Fields

        #region Public Constructors

        public CommentsController(ICommentsRepository comments)
        {
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
        public ActionResult<List<CommentVM>> GetComments([FromRoute][GuidId] string publicationId, [ForbidNegative] int skip = 0, int take = 10)
        {
            var models = comments.GetByPublication(publicationId, skip, take);
            List<CommentVM> result = new();
            foreach (var comm in models)
            {
                result.Add(new CommentVM().Assign(comm));
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteCommentAsync([FromRoute][GuidId] string id)
        {
            var model = await comments.GetAsync(id);
            if (model == null) return NotFound();
            comments.DeleteComment(id);
            return NoContent();
        }

        #endregion Public Methods
    }
}