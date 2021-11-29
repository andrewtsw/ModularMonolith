using EsfApiSdk.Snt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Common.Errors;
using TCO.SNT.Common.Extensions;
using TCO.SNT.DataAccess.Interfaces;

namespace TCO.SNT.UseCases.ApplicationServices
{
    internal class ErrorHelper
    {
        private readonly IDbContext _context;

        public ErrorHelper(IDbContext context)
        {
            _context = context;
        }

        public async Task FillErrorDescriptionAsync<T>(IReadOnlyList<T> items, CancellationToken cancellationToken)
            where T : IWithError
        {
            if (items.IsNullOrEmpty())
                return;

            var itemsWithErrors = items
                .Where(x => !string.IsNullOrEmpty(x.ErrorCode))
                .Where(x => Entities.ErrorCode.IsErrorCode(x.ErrorCode))
                .ToList();

            var errorCodes = itemsWithErrors
                .Select(x => x.ErrorCode)
                .Distinct()
                .ToList();

            if (errorCodes.IsNullOrEmpty())
                return;

            var errors = await _context.ErrorCodes.Where(x => errorCodes.Contains(x.Code))
                .ToDictionaryAsync(x => x.Code, x => x.Description, cancellationToken);

            foreach (var item in itemsWithErrors)
            {
                // Show error code if message not found.
                if (errors.TryGetValue(item.ErrorCode, out var description))
                {
                    item.SetErrorDescription(description);
                }
            }
        }

        public async Task<IReadOnlyList<Entities.ErrorCode>> GetErrorDescriptionAsync(Error[] errors, CancellationToken cancellationToken)
        {

            var errorCodes = await _context.ErrorCodes
                .Where(x => errors.Select(o => o.errorCode).Contains(x.Code))
                .ToListAsync(cancellationToken);

            return errorCodes;
        }
    }
}
