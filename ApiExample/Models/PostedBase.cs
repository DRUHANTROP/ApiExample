using System;

namespace ApiExample.Models
{
    public class PostedBase
    {
        #region Public Properties

        public string AuthorPseudonym { get; set; }

        public DateTime PublicationTime { get; set; }

        public long Rating { get; set; }

        #endregion Public Properties
    }
}