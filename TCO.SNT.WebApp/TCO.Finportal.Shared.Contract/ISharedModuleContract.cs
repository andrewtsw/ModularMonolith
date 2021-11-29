using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Common.Esf;
using TCO.SNT.Common.Roles;
using TCO.SNT.Common.Serialization;
using DomainEntities = TCO.Finportal.Framework.Domain.Entities;

namespace TCO.Finportal.Shared.Contract
{
    public interface ISharedModuleContract
    {
        Task<DigitalSignatureInfo> CreateSignatureAsync<T>(T obj, XmlMetadata metadata, CancellationToken cancellationToken);

        bool IsCurrentUserHasAnyRole(RoleType[] roles);

        bool IsCurrentUserInRole(RoleType role);

        Task<Dictionary<string, DomainEntities.MeasureUnit>> GetMeasureUnitsDictionaryByCodeAsync(CancellationToken cancellationToken);

        ValueTask<DomainEntities.MeasureUnit> GetMeasureUnitByIdAsync(int id, CancellationToken cancellationToken);
        
        Task<DomainEntities.MeasureUnit> GetMeasureUnitByCodeAsync(string code, CancellationToken cancellationToken);

        Task ImportMeasureUnitsAsync(CancellationToken cancellationToken);
    }
}
