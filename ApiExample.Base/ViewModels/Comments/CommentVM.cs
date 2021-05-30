using System;
using ApiExample.Base.Models;

namespace ApiExample.ViewModels.Comments
{
    public class CommentVM
    {
        #region Public Properties

        public string Author { get; set; }
        public string Content { get; set; }
        public string Id { get; set; }
        public DateTime UploadedAt { get; set; }

        #endregion Public Properties

        #region Public Methods

        public CommentVM Assign(Comment model)
        {
            Id = model.CommentId;
            UploadedAt = model.PublicationTime;
            Author = model.AuthorPseudonym;
            Content = model.Content;

            return this;
        }

        #endregion Public Methods
    }
}