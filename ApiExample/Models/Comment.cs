using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiExample.Interfaces;

namespace ApiExample.Models
{
    public class Comment : PostedBase, IHasTextContent
    {
        #region Public Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CommentId { get; set; }
        public string Content { get; set; }
        string PublicationId { get; set; }
        public Publication Publication { get; set; }

        #endregion Public Properties
    }
}