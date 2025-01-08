// ***********************************************************************
//  Solution         : Inno.Api.v2
//  Assembly         : FCS.Lib.Virk
//  Filename         : VrQueryMapper.cs
//  Created          : 2025-01-03 14:01
//  Last Modified By : dev
//  Last Modified On : 2025-01-04 13:01
//  ***********************************************************************
//  <copyright company="Frede Hundewadt">
//      Copyright (C) 2010-2025 Frede Hundewadt
//      This program is free software: you can redistribute it and/or modify
//      it under the terms of the GNU Affero General Public License as
//      published by the Free Software Foundation, either version 3 of the
//      License, or (at your option) any later version.
// 
//      This program is distributed in the hope that it will be useful,
//      but WITHOUT ANY WARRANTY; without even the implied warranty of
//      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//      GNU Affero General Public License for more details.
// 
//      You should have received a copy of the GNU Affero General Public License
//      along with this program.  If not, see [https://www.gnu.org/licenses]
//  </copyright>
//  <summary></summary>
//  ***********************************************************************

using Newtonsoft.Json.Linq;

namespace FCS.Lib.Virk;

/// <summary>
///     Provides functionality to map a <see cref="VrQuery" /> object to a JSON-compatible format.
/// </summary>
/// <remarks>
///     This class is utilized in various services to transform <see cref="VrQuery" /> instances into
///     objects suitable for HTTP requests or other operations requiring JSON serialization.
/// </remarks>
public class VrQueryMapper
{
    /// <summary>
    ///     Constructs a JSON object representing a query for retrieving company information
    ///     based on the provided <paramref name="query" /> parameters.
    /// </summary>
    /// <param name="query">
    ///     An instance of <see cref="VrQuery" /> containing the search criteria, such as
    ///     VAT number, entity name, zip code, street name, and house number.
    /// </param>
    /// <returns>
    ///     A <see cref="JObject" /> representing the query, tailored to the provided search criteria.
    /// </returns>
    /// <remarks>
    ///     The method dynamically builds the query based on the presence of specific fields in
    ///     the <paramref name="query" /> object. It supports three types of queries:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>Address-based lookup when both VAT number and entity name are absent.</description>
    ///         </item>
    ///         <item>
    ///             <description>VAT number-based lookup when the entity name is absent.</description>
    ///         </item>
    ///         <item>
    ///             <description>Entity name-based lookup when the entity name is provided.</description>
    ///         </item>
    ///     </list>
    ///     The resulting query is limited to a maximum of 50 results.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    ///     Thrown if <paramref name="query" /> is <c>null</c>.
    /// </exception>
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