using ApiExample.Interfaces;

namespace ApiExample.Models
{
    public class Comment : PostedBase, IHasTextContent
    {
        #region Public Properties

        public string Content { get; set; }
        public Publication Publication { get; set; }

        #endregion Public Properties
    }
}