// ***********************************************************************
// Assembly         : Inno.Api
// Author           : FH
// Created          : 01-01-2022
//
// Last Modified By : FH
// Last Modified On : 01-09-2022
// ***********************************************************************
// <copyright file="CvrPeriod.cs" company="FCS">
//     Copyright © FCS 2015-2022
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace FCS.Virk.CvrModels
{
    /// <summary>
    /// Class CvrPeriod.
    /// </summary>
    public class CvrPeriod
    {
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public string StartDate { get; set; } = "";
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public string EndDate { get; set; } = "";
    }
}