namespace Entity.Service.Master
{
    public class MasterParameterRequest
    {
        public string Name { get; set; } = null!;
        public string Diminutive { get; set; } = null!;
        public string Code { get; set; } = null!;
        public Guid? IdFather { get; set; }
    }
}
