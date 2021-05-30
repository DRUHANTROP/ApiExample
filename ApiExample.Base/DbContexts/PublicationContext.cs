using ApiExample.Base.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExample.Base.DbContexts
{
    public class PublicationContext : DbContext
    {
        #region Public Constructors

        public PublicationContext(DbContextOptions options) : base(options)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Publication> Publications { get; set; }

        #endregion Public Properties
    }
}