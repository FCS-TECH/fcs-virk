// ***********************************************************************
//  Solution         : Inno.Api.v2
//  Assembly         : FCS.Lib.Virk
//  Filename         : VrQuery.cs
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

namespace FCS.Lib.Virk;

/// <summary>
///     Represents a query object used for performing lookups in the Danish business registry.
/// </summary>
/// <remarks>
///     The <see cref="VrQuery" /> class encapsulates the necessary details for querying the registry,
///     such as VAT number, address information, and entity name. It is primarily used in scenarios
///     where precise or address-based lookups are required.
///     This class is validated using the <see cref="VrQueryValidator" /> to ensure that the query
///     meets the necessary requirements for processing.
/// </remarks>
public class VrQuery
{
    /// <summary>
    ///     Gets or sets the VAT (Value Added Tax) number associated with the query.
    /// </summary>
    /// <remarks>
    ///     This property is used to perform a precise lookup when validating a <see cref="VrQuery" />.
    ///     A valid precise lookup requires that either this property or the <see cref="EntityName" />
    ///     is not null or whitespace.
    /// </remarks>
    public string VatNumber { get; set; } = "";

    /// <summary>
    ///     Gets or sets the name of the street associated with the query.
    /// </summary>
    /// <remarks>
    ///     This property is used during address lookups to validate that the street name is not null or whitespace.
    /// </remarks>
    public string StreetName { get; set; } = "";

    /// <summary>
    ///     Gets or sets the house number associated with the address lookup.
    /// </summary>
    /// <remarks>
    ///     This property is used during address validation to ensure that the house number is not null,
    ///     not whitespace, and can be parsed as an integer.
    /// </remarks>
    public string HouseNumber { get; set; } = "";

    /// <summary>
    ///     Gets or sets the postal code associated with the query.
    /// </summary>
    /// <remarks>
    ///     This property is used during address lookups to validate the query.
    ///     It must not be null or whitespace to ensure the query is valid.
    /// </remarks>
    public string ZipCode { get; set; } = "";

    /// <summary>
    ///     Gets or sets the name of the entity associated with the query.
    /// </summary>
    /// <remarks>
    ///     This property is used to perform a precise lookup when validating a <see cref="VrQuery" />.
    ///     A valid precise lookup requires that either this property or the <see cref="VatNumber" />
    ///     is not null or whitespace.
    /// </remarks>
    public string EntityName { get; set; } = "";
}