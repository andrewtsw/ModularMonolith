using System.Collections.ObjectModel;
using System.Globalization;

namespace TCO.SNT.Common
{
    public static class GlobalConst
    {
        public static readonly ReadOnlyCollection<CultureInfo> SupportedCultures = new ReadOnlyCollection<CultureInfo>
        (
            new[]{
                    new CultureInfo("en-Us"),
                    new CultureInfo("ru-Ru"),
                    new CultureInfo("kz-Kz")
            }
        );

        public const int DefaultItemsPerPage = 15;
        public const int MaxItemsPerPage = 1000;
        public const string CommonDateFormat = "dd.MM.yyyy";
    }
}

