namespace FCS.Virk.VrModels
{
    public class VirksomhedsStatus
    {
        public string SidstOpdateret { get; set; } = "";
        public string Status { get; set; } = "";
        public Periode Periode { get; set; } = new();
    }
}