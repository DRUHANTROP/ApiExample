using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ApiExample.Interfaces;

namespace ApiExample.Models
{
    public class Publication : PostedBase, IHasTextContent
    {
        #region Public Properties

        [NotNull]
        public ICollection<Comment> Comments { get; set; }

        public string Content { get; set; }
        public byte[] Image { get; set; }

        #endregion Public Properties
    }
}