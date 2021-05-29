using System.ComponentModel.DataAnnotations;

namespace ApiExample.Attributes
{
    public class ForbidNegativeAttribute : RangeAttribute
    {
        #region Public Constructors

        public ForbidNegativeAttribute() : base(0, int.MaxValue)
        {
        }

        #endregion Public Constructors
    }
}