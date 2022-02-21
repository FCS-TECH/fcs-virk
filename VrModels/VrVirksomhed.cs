namespace FCS.Virk.VrModels
{
    public class VrVirksomhed
    {
        public string CvrNummer { get; set; } = "";
        public List<VirksomhedsStatus> VirksomhedsStatus { get; set; } = new ();
        public VirksomhedMetadata VirksomhedMetadata { get; set; } = new();

    }
}