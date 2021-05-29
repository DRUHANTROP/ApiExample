﻿using System;
using System.Collections.Generic;
using ApiExample.Models;

namespace ApiExample.ViewModels.Publications
{
    public class PublicationVM
    {
        #region Public Properties

        public ICollection<Comment> CommentsIds { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string Id { get; set; }
        public bool ImageAttached { get; set; }
        public long Rating { get; set; }

        #endregion Public Properties

        #region Public Methods

        public PublicationVM Assign(Publication model)
        {
            Id = model.ID;
            Content = model.Content;
            Created = model.PublicationTime;
            Rating = model.Rating;
            ImageAttached = model.Image == null;
            CommentsIds = model.Comments;

            return this;
        }

        #endregion Public Methods
    }
}