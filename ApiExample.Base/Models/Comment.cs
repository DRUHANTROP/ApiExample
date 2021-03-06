using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiExample.Base.Interfaces;

namespace ApiExample.Base.Models
{
    public class Comment : PostedBase, IHasTextContent
    {
        #region Public Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CommentId { get; set; }
        public string Content { get; set; }
        [ForeignKey(nameof(Publication))]
        public string PublicationId { get; set; }

        #endregion Public Properties
    }
}