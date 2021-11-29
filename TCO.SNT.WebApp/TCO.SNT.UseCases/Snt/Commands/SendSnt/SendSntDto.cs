using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.UseCases.Snt.Commands.SendSnt
{
    public class SendSntDto
    {
        /// <summary>
        /// Snt.Id
        /// </summary>
        public int SntId { get; set; }

        /// <summary>
        /// Timezone offset from the client in minutes
        /// </summary>
        [Range(-14*60, 14*60)]
        public int LocalTimezoneOffsetMinutes { get; set; }
    }
}
