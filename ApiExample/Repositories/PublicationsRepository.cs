﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiExample.DbContexts;
using ApiExample.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExample.Repositories
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

        public async Task<long> DownvoteAsync(Publication model)
        {
            var updated = --db.Publications.Update(model).Entity.Rating;
            await db.SaveChangesAsync();
            return updated;
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await db.Publications.AnyAsync(m => m.ID == id);
        }

        public async Task<Publication> GetAsync(string id)
        {
            return await db.Publications.FindAsync(id);
        }

        public async Task<List<Publication>> GetFromPublicationDateAsync(DateTime startFrom, int skip, int take)
        {
            return await db.Publications.Where(c => c.PublicationTime > startFrom).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<byte[]> GetImageAsync(string id)
        {
            return (await db.Publications.Include(m => m.Image).Where(m => m.ID == id).FirstOrDefaultAsync())?.Image;
        }

        public async Task<long> UpvoteAsync(Publication model)
        {
            var updated = ++db.Publications.Update(model).Entity.Rating;
            await db.SaveChangesAsync();
            return updated;
        }

        #endregion Public Methods
    }
}