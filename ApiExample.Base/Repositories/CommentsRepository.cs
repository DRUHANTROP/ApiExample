using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiExample.Base.DbContexts;
using ApiExample.Base.Models;

namespace ApiExample.Base.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        #region Private Fields

        private readonly PublicationContext db;

        #endregion Private Fields

        #region Public Constructors

        public CommentsRepository(PublicationContext context)
        {
            db = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<Comment> CreateAsync(Comment model)
        {
            db.Add(model);
            var publication = await db.Publications.FindAsync(model.PublicationId);
            publication.Comments.Add(model);
            await db.SaveChangesAsync();
            return model;
        }

        public async Task<long> DownvoteAsync(Comment model)
        {
            var updated = --db.Comments.Update(model).Entity.Rating;
            await db.SaveChangesAsync();
            return updated;
        }

        public async Task<Comment> GetAsync(string id)
        {
            return await db.Comments.FindAsync(id);
        }

        public List<Comment> GetByPublication(string id, int skip, int take)
        {
            return db.Comments.Where(m => m.PublicationId == id).Skip(skip).Take(take).ToList();
        }

        public int CountByPublication(string pubId)
        {
            return db.Comments.Count(m => m.PublicationId == pubId);
        }

        public void DeleteComment(string id)
        {
            db.Comments.Remove(db.Comments.Find(id));
            db.SaveChanges();
        }

        public async Task<long> UpvoteAsync(Comment model)
        {
            var updated = ++db.Comments.Update(model).Entity.Rating;
            await db.SaveChangesAsync();
            return updated;
        }

        #endregion Public Methods
    }
}