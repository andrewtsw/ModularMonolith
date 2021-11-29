using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.VStore.Interfaces;
using VsSdk.Version;

namespace TCO.SNT.UseCases.ErrorCode.Commands.ImportErrorCodes
{
    internal class ImportErrorCodesCommandHandler : IRequestHandler<ImportErrorCodesCommand, ImportErrorCodesResultDto>
    {
        private readonly IDbContext _context;

        // We can use IVstoreVersionService or IEsfVersionService
        // Both of them return the same error codes.
        private readonly IVstoreVersionService _vstoreVersionService;

        public ImportErrorCodesCommandHandler(IDbContext context,
            IVstoreVersionService vstoreVersionService)
        {
            _context = context;
            _vstoreVersionService = vstoreVersionService;
        }

        public async Task<ImportErrorCodesResultDto> Handle(ImportErrorCodesCommand request, CancellationToken cancellationToken)
        {
            var errors = await _vstoreVersionService.GetErrorCodesAsync(Language.RU);

            errors.ValidateAll(new ErrorCodeValidator());

            var oldErrorCodes = await _context.ErrorCodes.ToDictionaryAsync(x => x.Code, cancellationToken);

            var result = MergeErrorCodes(errors, oldErrorCodes);

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }

        private ImportErrorCodesResultDto MergeErrorCodes(errorDescription[] newErrorCodes, Dictionary<string, Entities.ErrorCode> oldErrorCodes)
        {
            var result = new ImportErrorCodesResultDto { Total = newErrorCodes.Length };
            foreach (var errorCode in newErrorCodes)
            {
                if (oldErrorCodes.TryGetValue(errorCode.errorCode, out var errorCodeEntity))
                {
                    // Update description for existing code
                    errorCodeEntity.Description = errorCode.description;
                }
                else
                {
                    // Create a new code
                    errorCodeEntity = new Entities.ErrorCode
                    {
                        Code = errorCode.errorCode,
                        Description = errorCode.description
                    };
                    _context.ErrorCodes.Add(errorCodeEntity);
                    result.Added++;
                }
            }

            var errorCodesDict = newErrorCodes.ToDictionary(x => x.errorCode);
            foreach (var errorCode in oldErrorCodes)
            {
                if (!errorCodesDict.ContainsKey(errorCode.Key))
                {
                    // Remove not found code from the DB
                    _context.ErrorCodes.Remove(errorCode.Value);
                    result.Removed++;
                }
            }

            return result;
        }
    }
}
