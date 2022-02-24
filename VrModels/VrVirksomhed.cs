// ***********************************************************************
// Assembly         : FCS.Virk
// Author           : FH
// Created          : 02-21-2022
//
// Last Modified By : FH
// Last Modified On : 02-24-2022
// ***********************************************************************
// <copyright file="VrVirksomhed.cs" company="FCS">
//    Copyright (C) 2022 FCS Frede's Computer Services.
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU Affero General Public License as
//    published by the Free Software Foundation, either version 3 of the
//    License, or (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU Affero General Public License for more details.
//
//    You should have received a copy of the GNU Affero General Public License
//    along with this program.  If not, see [https://www.gnu.org/licenses]
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace FCS.Lib.Virk.VrModels
{
    /// <summary>
    /// Class VrVirksomhed.
    /// </summary>
    public class VrVirksomhed
    {
        /// <summary>
        /// Gets or sets the CVR nummer.
        /// </summary>
        /// <value>The CVR nummer.</value>
        public string CvrNummer { get; set; } = "";
        /// <summary>
        /// Gets or sets the virksomheds status.
        /// </summary>
        /// <value>The virksomheds status.</value>
        public List<VirksomhedsStatus> VirksomhedsStatus { get; set; } = new ();
        /// <summary>
        /// Gets or sets the virksomhed metadata.
        /// </summary>
        /// <value>The virksomhed metadata.</value>
        public VirksomhedMetadata VirksomhedMetadata { get; set; } = new();

    }
}