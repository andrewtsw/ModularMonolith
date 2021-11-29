using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TCO.SNT.Common.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DateTimeKindAttribute : ValidationAttribute
    {
        private readonly DateTimeKind _kind;

        public DateTimeKindAttribute(DateTimeKind kind) 
            : base("The field {0} must be a DateTime type with a Kind = '{1}'.")
        {
            _kind = kind;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is DateTime dateTime)
            {
                return dateTime.Kind == _kind;
            }

            return false;            
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _kind);
        }
    }
}
