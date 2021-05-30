using System;
using System.Collections.Generic;
using ApiExample.Base.Models;

namespace ApiExample.ViewModels.Publications
{
    public class PublicationVM
    {
        #region Public Properties

        public string Id { get; set; }
        public string Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public bool ImageAttached { get; set; }
        public long Rating { get; set; }

        #endregion Public Properties

        #region Public Methods

        public PublicationVM Assign(Publication model)
        {
            Id = model.PublicationId;
            Author = model.AuthorPseudonym;
            Content = model.Content;
            Created = model.PublicationTime;
            Rating = model.Rating;
            ImageAttached = model.Image != null;
            Comments = model.Comments;

            return this;
        }

        #endregion Public Methods
    }
}