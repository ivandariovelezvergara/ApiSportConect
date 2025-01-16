using Entity.Enumerable;

namespace Entity.Service.Security
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string ObjName { get; set; } = null!;
        public List<EnumAction> Actions { get; set; } = new();
    }
}
