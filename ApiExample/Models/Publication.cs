using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using ApiExample.Interfaces;

namespace ApiExample.Models
{
    public class Publication : PostedBase, IHasTextContent
    {
        #region Public Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PublicationId { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public string Content { get; set; }
        public byte[] Image { get; set; }

        #endregion Public Properties
    }
}