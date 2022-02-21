using FCS.Virk.CvrModels;
using FCS.Virk.VrModels;

namespace FCS.Virk
{
    public class VrCvrMapper
    {
        public CvrCompany MapVrToCvr(VrVirksomhed vrVirk)
        {
            var c = new CvrCompany
            {
                Name = vrVirk.VirksomhedMetadata.NyesteNavn.Navn,
                Address =
                    $"{vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.Vejnavn} {vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.HusnummerFra}",
                CoName = vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.CoNavn,
                ZipCode = vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.Postnummer.ToString(),
                City = vrVirk.VirksomhedMetadata.NyesteBeliggenhedsadresse.PostDistrikt,
                VatNumber = vrVirk.CvrNummer
            };

            foreach (var cs in vrVirk.VirksomhedsStatus.Select(vrStatus => new CvrStatus
                     {
                         Status = vrStatus.Status,
                         LastUpdate = vrStatus.SidstOpdateret,
                         Period = new CvrPeriod
                         {
                             StartDate = vrStatus.Periode.GyldigFra,
                             EndDate = vrStatus.Periode.GyldigTil
                         }
                     }))
            {
                c.Status.Add(cs);
            }
            return c;
        }
    }
}