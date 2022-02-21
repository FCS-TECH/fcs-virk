namespace FCS.Virk.VrModels
{
    public class NyesteBeliggenhedsadresse
    {
        public int? HusnummerFra { get; set; }
        public int? HusnummerTil { get; set; }
        public int? Postnummer { get; set; }
        public string Vejnavn { get; set; } = "";
        public string CoNavn { get; set; } = "";
        public string PostDistrikt { get; set; } = "";
    }
}