using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using ApiExample.Base.Interfaces;

namespace ApiExample.Base.Models
{
    public class Publication : PostedBase, IHasTextContent
    {
        #region Public Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PublicationId { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public string Content { get; set; }
        public byte[] Image { get; set; }

        #endregion Public Properties
    }
}