namespace TCO.SNT.Common.Extensions
{
    public static class DecimalExtensions 
    {
        /// <summary>
        /// Workaround to remove all trailind spaces from the decimal value.
        /// </summary>
        public static decimal RemoveTrailingZeros(this decimal value) 
        { 
            return value / 1.000000000000000000000000000000000m; 
        }
    }
}
