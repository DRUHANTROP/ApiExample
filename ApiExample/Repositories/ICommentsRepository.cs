using System.Collections.Generic;
using System.Threading.Tasks;
using ApiExample.Models;

namespace ApiExample.Repositories
{
    public interface ICommentsRepository
    {
        #region Public Methods

        Task<Comment> CreateAsync(Comment model);

        Task<long> DownvoteAsync(Comment model);

        Task<Comment> GetAsync(string id);

        List<Comment> GetByPublication(string id);

        Task<long> UpvoteAsync(Comment model);

        #endregion Public Methods
    }
}