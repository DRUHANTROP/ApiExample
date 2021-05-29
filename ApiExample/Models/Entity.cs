using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiExample.Models
{
    public class Entity
    {
        #region Public Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string ID { get; set; }

        #endregion Public Properties
    }
}