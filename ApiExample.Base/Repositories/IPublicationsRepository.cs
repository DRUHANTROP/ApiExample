using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiExample.Base.Models;

namespace ApiExample.Base.Repositories
{
    public interface IPublicationsRepository
    {
        #region Public Methods

        Task<Publication> CreateAsync(Publication model);
        void DeletePublication(string id);

        Task<Publication> GetAsync(string id);

        Task<List<Publication>> GetFromPublicationDateAsync(DateTime startFrom, int skip, int take);

        Task<byte[]> GetImageAsync(string id);

        #endregion Public Methods
    }
}