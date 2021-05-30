using System;
using System.ComponentModel.DataAnnotations;
using ApiExample.Base.Models;

namespace ApiExample.ViewModels.Comments
{
    public class CreateCommentVM
    {
        #region Public Properties

        [Required]
        public string Content { get; set; }

        [Required]
        public string Pseudonym { get; set; } = "Anon";

        #endregion Public Properties

        #region Public Methods

        public Comment ToModel(string publicationId)
        {
            return new Comment()
            {
                AuthorPseudonym = Pseudonym,
                Content = Content,
                PublicationId = publicationId,
                PublicationTime = DateTime.UtcNow,
                Rating = 0
            };
        }

        #endregion Public Methods
    }
}