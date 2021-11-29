using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.Finportal.Infrastructure.KeyVault.Interfaces;
using TCO.Finportal.Shared.ApplicationServices;
using TCO.Finportal.Shared.Contract;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.Finportal.Shared.UseCases.MeasureUnits.Commands.ImportMeasureUnits;
using TCO.SNT.Common.Esf;
using TCO.SNT.Common.Roles;
using TCO.SNT.Common.Serialization;
using TCO.SNT.Infrastructure.Interfaces;
using DomainEntities = TCO.Finportal.Framework.Domain.Entities;

namespace TCO.Finportal.Shared.ContractImplementation
{
    internal class SharedModuleContract : ISharedModuleContract
    {
        private readonly ISharedDbContext _context;
        private readonly IKeyVaultService _keyVaultService;
        private readonly ICurrentUserService _currentUserService;
        private readonly RolesService _rolesService;
        private readonly ISender _sender;

        public SharedModuleContract(ISharedDbContext context,
            IKeyVaultService keyVaultService,
            ICurrentUserService currentUserService,
            RolesService rolesService,
            ISender sender)
        {
            _context = context;
            _keyVaultService = keyVaultService;
            _currentUserService = currentUserService;
            _rolesService = rolesService;
            _sender = sender;
        }

        public async Task<DigitalSignatureInfo> CreateSignatureAsync<T>(T obj, XmlMetadata metadata, CancellationToken cancellationToken)
        {
            var body = SerializationHelper.SerializeToXml(obj, metadata);
            var profile = await _context.GetSignEsfUserProfileAsync(_currentUserService.UserId, cancellationToken);
            var signature = await _keyVaultService.SignAsync(profile.SignRSAKeyName, body, cancellationToken);
            var certificate = await _keyVaultService.GetSecretAsync(profile.Base64SignCertificateSecretName, cancellationToken);

            return new DigitalSignatureInfo(body, signature, certificate);
        }

        public bool IsCurrentUserHasAnyRole(RoleType[] roles) => _rolesService.IsInRoles(roles);

        public bool IsCurrentUserInRole(RoleType role) => _rolesService.IsInRole(role);

        #region MeasureUnits

        public ValueTask<DomainEntities.MeasureUnit> GetMeasureUnitByIdAsync(int id, CancellationToken cancellationToken) =>
            _context.MeasureUnits.FindOrExceptionAsync(id, cancellationToken);

        public Task<DomainEntities.MeasureUnit> GetMeasureUnitByCodeAsync(string code, CancellationToken cancellationToken) =>
            _context.MeasureUnits.SingleOrExceptionAsync(x => x.Code == code, cancellationToken);

        public Task<Dictionary<string, DomainEntities.MeasureUnit>> GetMeasureUnitsDictionaryByCodeAsync(CancellationToken cancellationToken) =>
            _context.MeasureUnits.AsNoTracking().ToDictionaryAsync(x => x.Code, cancellationToken);

        public Task ImportMeasureUnitsAsync(CancellationToken cancellationToken) =>
            _sender.Send(new ImportMeasureUnitsCommand(), cancellationToken);

        #endregion
    }
}
