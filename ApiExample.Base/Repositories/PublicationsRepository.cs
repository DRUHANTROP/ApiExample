using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiExample.Base.DbContexts;
using ApiExample.Base.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExample.Base.Repositories
{
    public class PublicationsRepository : IPublicationsRepository
    {
        #region Private Fields

        private readonly PublicationContext db;

        #endregion Private Fields

        #region Public Constructors

        public PublicationsRepository(PublicationContext context)
        {
            db = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<Publication> CreateAsync(Publication model)
        {
            var created = await db.Publications.AddAsync(model);
            await db.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<Publication> GetAsync(string id)
        {
            return await db.Publications.FindAsync(id);
        }

        public async Task<List<Publication>> GetFromPublicationDateAsync(DateTime startFrom, int skip, int take)
        {
            return await db.Publications.Where(c => c.PublicationTime > startFrom).Skip(skip).Take(take).ToListAsync();
        }

        public void DeletePublication(string id)
        {
            db.Publications.Remove(db.Publications.Find(id));
            db.Comments.RemoveRange(db.Comments.Where(c => c.PublicationId == id));
            db.SaveChanges();
        }

        public async Task<byte[]> GetImageAsync(string id)
        {
            return (await db.Publications.Include(m => m.Image).Where(m => m.PublicationId == id).FirstOrDefaultAsync())?.Image;
        }

        #endregion Public Methods
    }
}