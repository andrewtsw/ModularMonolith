using System;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Common;

namespace TCO.Finportal.Framework.UseCases
{
    public class RequestPagingModel
    {
        [Range(1, int.MaxValue)]
        public int CurrentPage { get; set; }

        [Range(1, GlobalConst.MaxItemsPerPage)]
        public int ItemsPerPage { get; set; }
    }
}
