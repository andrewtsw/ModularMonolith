using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Entities;
using TCO.SNT.UseCases.UForms.Commands.Dto;

namespace TCO.SNT.UseCases.UForms.Commands.SaveWriteOffUForm
{
    public class WriteOffUFormDto : UFormDtoBase
    {
        [MaxLength(255)]
        public string Comment { get; set; }

        public UFormWriteOffType WriteOffReason { get; set; }

        /// <summary>
        /// Товары
        /// </summary>
        [Required]
        [MinLength(1)]
        public WriteOffUFormProductDto[] Products { get; set; }

        public override UFormType GetUFormType() => UFormType.WRITE_OFF;

        public override IEnumerable<UFormProductDtoBase> GetProducts() => Products;

        public override void FillForm(UForm form)
        {
            base.FillForm(form);
            form.Comment = Comment;
            form.WriteOffReason = WriteOffReason;
        }
    }
}
