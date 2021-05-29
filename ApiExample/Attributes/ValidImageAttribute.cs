using System;
using System.ComponentModel.DataAnnotations;

namespace ApiExample.Attributes
{
    public class ValidImageAttribute : ValidationAttribute
    {
        #region Private Fields

        // this will help me identify jpeg image
        private static readonly byte[] jpeg = new byte[] { 255, 216, 255, 224 };

        #endregion Private Fields

        #region Public Constructors

        public ValidImageAttribute() : base("image must be in .jpeg or .png format")
        {
        }

        #endregion Public Constructors

        #region Public Methods

        // this will check if byte[] starts with same bytes as allowed image formats
        public override bool IsValid(object value)
        {
            return value == null || value == Array.Empty<byte>()
            || (value is byte[] bytes && bytes.Length >= 4
            && (jpeg[0] == bytes[0] && jpeg[1] == bytes[1] && jpeg[2] == bytes[2] && jpeg[3] == bytes[3]));
        }

        #endregion Public Methods
    }
}