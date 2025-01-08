// ***********************************************************************
//  Solution         : Inno.Api.v2
//  Assembly         : FCS.Lib.Virk
//  Filename         : NyesteNavn.cs
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
///     Represents the most recent name associated with a business.
/// </summary>
/// <remarks>
///     This class is part of the <c>FCS.Lib.Virk</c> namespace and is used to store the latest name
///     information for a business entity.
/// </remarks>
public class NyesteNavn
{
    /// <summary>
    ///     Gets or sets the most recent name of the entity.
    /// </summary>
    /// <value>
    ///     A <see cref="string" /> representing the latest name.
    /// </value>
    public string Navn { get; set; } = "";
}