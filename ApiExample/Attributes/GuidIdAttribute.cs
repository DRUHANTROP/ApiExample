using System.ComponentModel.DataAnnotations;

namespace ApiExample.Attributes
{
    public class GuidIdAttribute : RegularExpressionAttribute
    {
        #region Public Constructors

        public GuidIdAttribute() : base("^([0-9A-Fa-f]{8}([-][0-9A-Fa-f]{4}){3}[-][0-9A-Fa-f]{12})$") // this regex is for GUIDs
        {
        }

        #endregion Public Constructors
    }
}