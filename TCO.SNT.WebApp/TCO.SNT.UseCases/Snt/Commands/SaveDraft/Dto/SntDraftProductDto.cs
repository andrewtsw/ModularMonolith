using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Commands.SaveDraft
{
    public class SntDraftProductDto : SntProductDtoBase, IValidatableObject
    {
        /// <summary>
        /// Код товара (GTIN) (G1 16)
        /// </summary>
        public string GtinCode { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // BalanceId is specified for Inbound SNT. So GsvsId and MeasureUnitId must be null
            if (BalanceId != null)
            {
                if (GsvsId != null)
                    yield return new ValidationResult($"{nameof(GsvsId)} must be null when {nameof(BalanceId)} specified", new[] { nameof(GsvsId) });
                if (MeasureUnitId != null)
                    yield return new ValidationResult($"{nameof(MeasureUnitId)} must be null when {nameof(BalanceId)} specified", new[] { nameof(GsvsId) });
            }
            // BalanceId NOT specified for Inbound SNT. So GsvsId and MeasureUnitId must NOT be null
            else
            {
                if (GsvsId == null)
                    yield return new ValidationResult($"{nameof(GsvsId)} must be not null when {nameof(BalanceId)} not specified.", new[] { nameof(GsvsId) });
                if (MeasureUnitId == null)
                    yield return new ValidationResult($"{nameof(MeasureUnitId)} must be not null when {nameof(BalanceId)} not specified.", new[] { nameof(GsvsId) });
            }
        }
    }
}
