// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author          : fhdk
// Created          : 2022 12 17 13:33
// 
// Last Modified By: fhdk
// Last Modified On : 2023 03 14 09:16
// ***********************************************************************
// <copyright file="VrVirksomhed.cs" company="FCS">
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

namespace FCS.Lib.Virk
{
    /// <summary>
    /// Business model with registrar
    /// </summary>
    /// <remarks>JSON property 1-1 relation</remarks>
    public class VrVirksomhed
    {
        /// <summary>
        /// Vat number
        /// </summary>
        public string CvrNummer { get; set; } = "";

        /// <summary>
        /// Status list
        /// </summary>
        /// <see cref="VirksomhedsStatus"/>
        public List<VirksomhedsStatus> VirksomhedsStatus { get; set; } = new();

        /// <summary>
        /// Meta data
        /// </summary>
        /// <see cref="VirksomhedMetadata"/>
        public VirksomhedMetadata VirksomhedMetadata { get; set; } = new();

        /// <summary>
        /// Company stages
        /// </summary>
        /// <see cref="LivsforloebModel"/>
        public List<LivsforloebModel> Livsforloeb { get; set; } = new();
    }
}