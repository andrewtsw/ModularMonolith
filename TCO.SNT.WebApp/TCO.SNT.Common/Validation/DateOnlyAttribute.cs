using System;
using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.Common.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DateOnlyAttribute : ValidationAttribute
    {
        public DateOnlyAttribute() 
            : base("The field {0} must be a date only.")
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is DateTime dateTime)
            {
                // Check if date is without time
                return dateTime.Date == dateTime;
            }

            return false;            
        }
    }
}
