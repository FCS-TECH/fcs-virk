using Newtonsoft.Json.Linq;

namespace FCS.Virk
{
    public class VrQueryMapper
    {
        public JObject VrMapQuery(VrQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.VatNumber))
            {
                return new JObject(
                    new JProperty("_source",
                        new JArray(
                            "Vrvirksomhed.cvrNummer",
                            "Vrvirksomhed.virksomhedMetadata.nyesteNavn.navn",
                            "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.conavn",
                            "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.vejnavn",
                            "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.husnummerFra",
                            "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.husnummerTil",
                            "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postnummer",
                            "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postdistrikt",
                            "Vrvirksomhed.virksomhedsstatus")
                    ),
                    new JProperty("query",
                        new JObject(new JProperty("bool",
                            new JObject(new JProperty("must",
                                new JArray(
                                    new JObject(new JProperty("match",
                                        new JObject(new JProperty(
                                            "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postnummer",
                                            new JObject(new JProperty("query", query.ZipCode),
                                                new JProperty("_name", "postnummer")))))),
                                    new JObject(new JProperty("match",
                                        new JObject(new JProperty(
                                            "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.vejnavn",
                                            new JObject(new JProperty("query", query.StreetName),
                                                new JProperty("_name", "vejnavn")))))),
                                    new JObject(new JProperty("match",
                                        new JObject(new JProperty(
                                            "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.husnummerFra",
                                            new JObject(new JProperty("query", query.HouseNumber),
                                                new JProperty("_name", "husnummerFra"))))))
                                )))))),
                    new JProperty("size", 50));
            }

            return new JObject(
                new JProperty("_source",
                    new JArray(
                        "Vrvirksomhed.cvrNummer",
                        "Vrvirksomhed.virksomhedMetadata.nyesteNavn.navn",
                        "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.conavn",
                        "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.vejnavn",
                        "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.husnummerFra",
                        "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.husnummerTil",
                        "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postnummer",
                        "Vrvirksomhed.virksomhedMetadata.nyesteBeliggenhedsadresse.postdistrikt",
                        "Vrvirksomhed.virksomhedsstatus")
                ),
                new JProperty("query",
                    new JObject(new JProperty("term",
                        new JObject(new JProperty("Vrvirksomhed.cvrNummer", query.VatNumber))))));

        }
    }
}