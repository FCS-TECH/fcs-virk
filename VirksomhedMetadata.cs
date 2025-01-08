// ***********************************************************************
//  Solution         : Inno.Api.v2
//  Assembly         : FCS.Lib.Virk
//  Filename         : VirksomhedMetadata.cs
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
///     Represents metadata associated with a business, including its latest name and address information.
/// </summary>
/// <remarks>
///     This class is part of the <c>FCS.Lib.Virk</c> namespace and serves as a container for metadata
///     related to a business. It provides access to the most recent name and address details of the business.
/// </remarks>
/// <seealso cref="NyesteNavn" />
/// <seealso cref="NyesteBeliggenhedsadresse" />
public class VirksomhedMetadata
{
    /// <summary>
    ///     Gets or sets the most recent name associated with the business.
    /// </summary>
    /// <remarks>
    ///     This property provides access to the current name of the business, represented by an instance of the
    ///     <see cref="NyesteNavn" /> class.
    /// </remarks>
    public NyesteNavn NyesteNavn { get; set; } = new();

    /// <summary>
    ///     Gets or sets the most recent address of the business location.
    /// </summary>
    /// <remarks>
    ///     This property provides access to the latest address details, including street name, house number range,
    ///     postal code, care-of name, and postal district.
    /// </remarks>
    public NyesteBeliggenhedsadresse NyesteBeliggenhedsadresse { get; set; } = new();
}