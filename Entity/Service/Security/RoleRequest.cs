namespace Entity.Service.Security
{
    public class RoleRequest
    {
        public string RoleName { get; set; } = null!;
        public List<Permission> Permissions { get; set; } = new();
        public string Description { get; set; } = null!;
    }
}
