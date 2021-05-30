using System.Collections.Generic;
using System.Threading.Tasks;
using ApiExample.Base.Models;

namespace ApiExample.Base.Repositories
{
    public interface ICommentsRepository
    {
        #region Public Methods
        int CountByPublication(string pubId);

        Task<Comment> CreateAsync(Comment model);

        void DeleteComment(string id);

        Task<Comment> GetAsync(string id);

        List<Comment> GetByPublication(string id, int skip, int take);


        #endregion Public Methods
    }
}