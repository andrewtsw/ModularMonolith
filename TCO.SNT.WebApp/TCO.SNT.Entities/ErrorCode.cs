using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Код ошибки
    /// </summary>
    public class ErrorCode
    {
        [Required]
        [MaxLength(250)]
        public string Code { get; set; }

        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Check that string is a correct error code
        /// Correct code sample: TRANSIT_CONTAINS_TAXPAYER_BLOCKED_BY_REGISTRATION_HAS_INVALID_ADD_CODE_4
        /// </summary>
        public static bool IsErrorCode(string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            // split to groups
            var groups = str.Split("_", StringSplitOptions.RemoveEmptyEntries);
            
            // Each groups contains only uppercase letters and digits
            var regex = new Regex("^[A-Z0-9]+$");
            return groups.All(g => regex.IsMatch(g));
        }
    }
}