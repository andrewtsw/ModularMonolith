namespace TCO.SNT.UseCases.Products.Queries.SearchProducts
{
    public class ProductFilter
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public bool? UseInVstore { get; set; }

        public bool? Unique { get; set; }

        public bool? Withdrawal { get; set; }

        public bool? TwofoldPurpose { get; set; }

        public bool? SociallySignificant { get; set; }

        public bool? Excisable { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(Code) &&
                   string.IsNullOrEmpty(Name) &&
                   !Excisable.HasValue &&
                   !UseInVstore.HasValue &&
                   !Unique.HasValue &&
                   !Withdrawal.HasValue &&
                   !TwofoldPurpose.HasValue &&
                   !SociallySignificant.HasValue &&
                   !Excisable.HasValue;
        }
    }
}
