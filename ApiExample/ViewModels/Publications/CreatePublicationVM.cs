using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApiExample.Attributes;
using ApiExample.Models;

namespace ApiExample.ViewModels.Publications
{
    public class CreatePublicationVM
    {
        #region Public Properties

        [StringLength(300)]
        public string Content { get; set; }

        [ValidImage]
        [MaxLength(1 << 22, ErrorMessage = "~4 MB is the limit for image upload :(")]
        public byte[] Image { get; set; } = null;

        [Required]
        [StringLength(50)]
        public string Pseudonym { get; set; } = "Anon";

        #endregion Public Properties

        #region Public Methods

        public Publication ToModel()
        {
            return new Publication()
            {
                AuthorPseudonym = Pseudonym,
                Content = Content,
                Image = Image,
                Comments = new List<Comment>(),
                PublicationTime = DateTime.UtcNow,
                Rating = 0
            };
        }

        #endregion Public Methods
    }
}