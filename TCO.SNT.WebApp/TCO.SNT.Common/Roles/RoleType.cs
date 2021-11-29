namespace TCO.SNT.Common.Roles
{
    public enum RoleType
    {
        SntReadOnly,
        Admin,
        SntOperator,
        TCOWarehouse,
        ApReadOnly,
        ApReadWrite,
        ArReadOnly,
        ArReadWrite
    }

    public static class RoleTypeExtensions
    {
        public static readonly RoleType[] AllRoles = new []
        {
            RoleType.SntReadOnly,
            RoleType.Admin,
            RoleType.SntOperator,
            RoleType.TCOWarehouse,
            RoleType.ApReadOnly,
            RoleType.ApReadWrite,
            RoleType.ArReadOnly,
            RoleType.ArReadWrite
        };

        /// <summary>
        /// All roles without admin
        /// </summary>
        public static readonly RoleType[] AllBusinesRoles = new[]
        {
            RoleType.SntReadOnly,
            RoleType.SntOperator,
            RoleType.TCOWarehouse,
            RoleType.ApReadOnly,
            RoleType.ApReadWrite,
            RoleType.ArReadOnly,
            RoleType.ArReadWrite
        };

        public static readonly RoleType[] AdminRoles = new []
        {
            RoleType.Admin
        };

        public static readonly RoleType[] SntModuleRoles = new []
        {
            RoleType.SntReadOnly,
            RoleType.SntOperator,
            RoleType.TCOWarehouse
        };

        public static readonly RoleType[] InvoicingModuleRoles = new []
        {
            RoleType.ApReadOnly,
            RoleType.ApReadWrite,
            RoleType.ArReadOnly,
            RoleType.ArReadWrite
        };
    }
}
