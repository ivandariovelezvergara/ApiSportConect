namespace Entity.Service.Master
{
    public class MasterTableRequest
    {
        public string MasterName { get; set; } = null!;
        public List<MasterParameterRequest> Parameters { get; set; } = new();
    }
}
