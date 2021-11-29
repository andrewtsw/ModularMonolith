using Microsoft.Extensions.Options;
using System;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.SNT.Functions.VirtualWarehouse
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly FunctionOptions _options;

        public CurrentUserService(IOptions<FunctionOptions> options)
        {
            _options = options.Value;
        }

        public Guid UserId => _options.SystemUserId;

        public bool IsInGroup(Guid groupId)
        {
            throw new NotImplementedException("This method can be moved to the MsGraph service. But it used only from the Web API for now. So it can be moved when we need its from the functions.");
        }
    }
}
