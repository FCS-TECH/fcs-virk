// ***********************************************************************
//  Solution         : Inno.Api.v2
//  Assembly         : FCS.Lib.Virk
//  Filename         : VirksomhedsStatus.cs
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
///     Represents the status of a company, including its last update date, current status, and the period during which the
///     status is valid.
/// </summary>
/// <remarks>
///     This class is part of the <c>FCS.Lib.Virk</c> namespace and is used to model the status information of a company.
///     It includes details such as the last updated timestamp, the current status description, and the validity period.
/// </remarks>
/// <seealso cref="Periode" />
/// <seealso cref="VrVirksomhed" />
public class VirksomhedsStatus
{
    /// <summary>
    ///     Gets or sets the date and time when the company's status was last updated.
    /// </summary>
    /// <remarks>
    ///     This property represents the most recent update timestamp for the company's status.
    /// </remarks>
    public string SidstOpdateret { get; set; } = "";

    /// <summary>
    ///     Gets or sets the current status of the virksomhed (business).
    /// </summary>
    /// <value>
    ///     A string representing the status of the virksomhed, such as "ACTIVE", "CLOSED", or other relevant states.
    /// </value>
    public string Status { get; set; } = "";

    /// <summary>
    ///     Gets or sets the period during which the status is valid.
    /// </summary>
    /// <remarks>
    ///     The <see cref="Periode" /> object contains the start and end dates that define the validity period.
    /// </remarks>
    public Periode Periode { get; set; } = new();
}