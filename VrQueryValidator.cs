// ***********************************************************************
//  Solution         : Inno.Api.v2
//  Assembly         : FCS.Lib.Virk
//  Filename         : VrQueryValidator.cs
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
///     Provides validation functionality for <see cref="VrQuery" /> objects to ensure they meet the requirements
///     for processing in various lookup scenarios.
/// </summary>
/// <remarks>
///     This class contains methods to validate the data integrity of <see cref="VrQuery" /> objects. It ensures that
///     the objects contain sufficient and correctly formatted information for either precise lookups or address-based
///     lookups.
/// </remarks>
public static class VrQueryValidator
{
    /// <summary>
    ///     Validates the provided <see cref="VrQuery" /> object to ensure it contains sufficient data for processing.
    /// </summary>
    /// <param name="query">The <see cref="VrQuery" /> object to validate.</param>
    /// <returns>
    ///     <c>true</c> if the query contains valid data for either a precise lookup or an address lookup;
    ///     otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    ///     A precise lookup is considered valid if either the <see cref="VrQuery.VatNumber" /> or
    ///     <see cref="VrQuery.EntityName" /> is not null or whitespace.
    ///     An address lookup is considered valid if all the following conditions are met:
    ///     <list type="bullet">
    ///         <item>
    ///             <description><see cref="VrQuery.StreetName" /> is not null or whitespace.</description>
    ///         </item>
    ///         <item>
    ///             <description><see cref="VrQuery.HouseNumber" /> is not null or whitespace and can be parsed as an integer.</description>
    ///         </item>
    ///         <item>
    ///             <description><see cref="VrQuery.ZipCode" /> is not null or whitespace.</description>
    ///         </item>
    ///     </list>
    ///     If an exception occurs during validation, the method returns <c>false</c>.
    /// </remarks>
    public static bool ValidateVrQuery(VrQuery query)
    {
        try
        {
            // Precise lookup
            if (!string.IsNullOrWhiteSpace(query.VatNumber) || !string.IsNullOrWhiteSpace(query.EntityName))
                return true;
            // Address lookup
            return !string.IsNullOrWhiteSpace(query.StreetName)
                   && !string.IsNullOrWhiteSpace(query.HouseNumber)
                   && !string.IsNullOrWhiteSpace(query.ZipCode)
                   && int.TryParse(query.HouseNumber, out _);
        }
        catch
        {
            return false;
        }
    }
}