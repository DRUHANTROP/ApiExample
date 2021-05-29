using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiExample.Models;

namespace ApiExample.Repositories
{
    public interface IPublicationsRepository
    {
        #region Public Methods

        Task<Publication> CreateAsync(Publication model);

        Task<long> DownvoteAsync(Publication model);

        Task<Publication> GetAsync(string id);

        Task<List<Publication>> GetFromPublicationDateAsync(DateTime startFrom, int skip, int take);

        Task<byte[]> GetImageAsync(string id);

        Task<long> UpvoteAsync(Publication model);

        #endregion Public Methods
    }
}