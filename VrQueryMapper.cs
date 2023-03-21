// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author          : fhdk
// Created          : 2022 12 17 13:33
// 
// Last Modified By: fhdk
// Last Modified On : 2023 03 14 09:16
// ***********************************************************************
// <copyright file="VrQueryMapper.cs" company="FCS">
//     Copyright (C) 2022-2023 FCS Frede's Computer Services.
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU Affero General Public License as
//     published by the Free Software Foundation, either version 3 of the
//     License, or (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU Affero General Public License for more details.
// 
//     You should have received a copy of the GNU Affero General Public License
//     along with this program.  If not, see [https://www.gnu.org/licenses]
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json.Linq;

namespace FCS.Lib.Virk
{
    /// <summary>
    /// VrQueryMapper
    /// </summary>
    /// <remarks>Maps the VrQuery object into an Elastic Search JObject</remarks>
    public class VrQueryMapper
    {
        /// <summary>
        /// VrMapQuery
        /// </summary>
        /// <param name="query"></param>
        /// <returns>Elastic Search JObject</returns>
        /// <see cref="VrQuery"/>
        public JObject VrMapQuery(VrQuery query)
        {
            // lookup based on address
            if (string.IsNullOrWhiteSpace(query.VatNumber) && string.IsNullOrWhiteSpace(query.EntityName))
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
                            "Vrvirksomhed.virksomhedsstatus",
                            "Vrvirksomhed.livsforloeb")
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
            // vat number query
            if (string.IsNullOrWhiteSpace(query.EntityName))
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
                            "Vrvirksomhed.virksomhedsstatus",
                            "Vrvirksomhed.livsforloeb")
                    ),
                    new JProperty("query",
                        new JObject(new JProperty("term",
                            new JObject(new JProperty("Vrvirksomhed.cvrNummer", query.VatNumber))))
                    )
                );

            query.EntityName = query.EntityName.Replace("A/S", "").Trim().Replace(" ", " AND ").Replace("-", " AND ");
            // name query
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
                        "Vrvirksomhed.virksomhedsstatus",
                        "Vrvirksomhed.livsforloeb")
                ),
                new JProperty("query",
                    new JObject(new JProperty("query_string",
                            new JObject(
                                new JProperty("default_field", "Vrvirksomhed.virksomhedMetadata.nyesteNavn.navn"),
                                new JProperty("query", query.EntityName)
                            )
                        )
                    )),
                new JProperty("size", 50));
        }
    }
}