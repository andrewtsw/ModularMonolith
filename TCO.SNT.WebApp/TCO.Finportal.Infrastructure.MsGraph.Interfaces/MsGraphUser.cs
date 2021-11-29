using System;

namespace TCO.Finportal.Infrastructure.MsGraph.Interfaces
{
    public class MsGraphUser
    {
        public MsGraphUser(string email, Guid id)
        {
            Email = email;
            Id = id;
        }

        public Guid Id { get; }
        public string Email { get; }
    }
}
