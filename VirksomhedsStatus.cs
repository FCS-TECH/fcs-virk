// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : FH
// Created          : 02-21-2022
//
// Last Modified By : FH
// Last Modified On : 02-24-2022
// ***********************************************************************
// <copyright file="VirksomhedsStatus.cs" company="FCS">
//    Copyright (C) 2022 FCS Frede's Computer Services.
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the Affero GNU General Public License as
//    published by the Free Software Foundation, either version 3 of the
//    License, or (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    Affero GNU General Public License for more details.
//
//    You should have received a copy of the Affero GNU General Public License
//    along with this program.  If not, see [https://www.gnu.org/licenses/agpl-3.0.en.html]
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace FCS.Lib.Virk
{
    /// <summary>
    /// VirksomhedsStatus object
    /// </summary>
    public class VirksomhedsStatus
    {
        /// <summary>
        /// Business last updated with registrar
        /// </summary>
        public string SidstOpdateret { get; set; } = "";
        /// <summary>
        /// Business status with registrar
        /// </summary>
        public string Status { get; set; } = "";
        /// <summary>
        /// Period object
        /// </summary>
        /// <see cref="Periode"/>
        public Periode Periode { get; set; } = new();
    }
}