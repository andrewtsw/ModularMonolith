using System;
using System.ComponentModel.DataAnnotations;
using TCO.SNT.Common;

namespace TCO.Finportal.Framework.UseCases
{
    [Serializable]
    public class PagingModel
    {
        public int TotalRecords { get; set; }

        public int CurrentPage { get; set; }

        [Range(1, GlobalConst.MaxItemsPerPage)]
        public int ItemsPerPage { get; set; }

        public int PageCount { get; set; }

        public PagingModel()
        {
            CurrentPage = 1;
            ItemsPerPage = GlobalConst.DefaultItemsPerPage;
        }

        public PagingModel(RequestPagingModel model)
        {
            CurrentPage = model.CurrentPage;
            ItemsPerPage = model.ItemsPerPage;
        }
    }
}
