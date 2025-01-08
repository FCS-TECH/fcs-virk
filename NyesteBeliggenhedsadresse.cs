// // ***********************************************************************
// // Solution         : Inno.Api.v2
// // Assembly         : FCS.Lib.Virk
// // Filename         : NyesteBeliggenhedsadresse.cs
// // Created          : 2025-01-03 14:01
// // Last Modified By : dev
// // Last Modified On : 2025-01-04 13:01
// // ***********************************************************************
// // <copyright company="Frede Hundewadt">
// //     Copyright (C) 2010-2025 Frede Hundewadt
// //     This program is free software: you can redistribute it and/or modify
// //     it under the terms of the GNU Affero General Public License as
// //     published by the Free Software Foundation, either version 3 of the
// //     License, or (at your option) any later version.
// //
// //     This program is distributed in the hope that it will be useful,
// //     but WITHOUT ANY WARRANTY; without even the implied warranty of
// //     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// //     GNU Affero General Public License for more details.
// //
// //     You should have received a copy of the GNU Affero General Public License
// //     along with this program.  If not, see [https://www.gnu.org/licenses]
// // </copyright>
// // <summary></summary>
// // ***********************************************************************

namespace FCS.Lib.Virk;

/// <summary>
///     Represents the most recent address of a location, including details such as house number range,
///     postal code, street name, care-of name, and postal district.
/// </summary>
/// <remarks>
///     This class is part of the FCS.Lib.Virk namespace and is used to store address-related metadata.
/// </remarks>
public class NyesteBeliggenhedsadresse
{
    /// <summary>
    ///     Gets or sets the starting house number of the address.
    /// </summary>
    /// <remarks>
    ///     This property represents the lower bound of the house number range
    ///     for the current address.
    /// </remarks>
    public int? HusnummerFra { get; set; }

    /// <summary>
    ///     Gets or sets the ending house number of the address range.
    /// </summary>
    /// <value>
    ///     The ending house number, or <c>null</c> if not specified.
    /// </value>
    public int? HusnummerTil { get; set; }

    /// <summary>
    ///     Gets or sets the postal code of the current address.
    /// </summary>
    /// <remarks>
    ///     This property represents the postal code associated with the address.
    ///     It is an optional value and can be <c>null</c>.
    /// </remarks>
    public int? Postnummer { get; set; }

    /// <summary>
    ///     Gets or sets the name of the street for the current address.
    /// </summary>
    /// <value>
    ///     A <see cref="string" /> representing the street name. Defaults to an empty string if not set.
    /// </value>
    public string Vejnavn { get; set; } = "";

    /// <summary>
    ///     Gets or sets the care-of name (CoNavn) associated with the address.
    ///     This property typically represents an additional name or entity
    ///     associated with the address for identification purposes.
    /// </summary>
    public string CoNavn { get; set; } = "";

    /// <summary>
    ///     Gets or sets the name of the postal district associated with the address.
    /// </summary>
    /// <remarks>
    ///     This property represents the city or locality name corresponding to the postal code.
    /// </remarks>
    public string PostDistrikt { get; set; } = "";
}