// ***********************************************************************
// Assembly         : Inno.Api
// Author           : FH
// Created          : 01-01-2022
//
// Last Modified By : FH
// Last Modified On : 01-31-2022
// ***********************************************************************
// <copyright file="CvrStatus.cs" company="FCS">
//     Copyright © FCS 2015-2022
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace FCS.Virk.CvrModels
{
    /// <summary>
    /// Class CvrStatus.
    /// </summary>
    public class CvrStatus
    {
        /// <summary>
        /// Gets or sets the last update.
        /// </summary>
        /// <value>The last update.</value>
        public string LastUpdate { get; set; } = "";
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; } = "LUKKET";
        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        /// <value>The period.</value>
        public CvrPeriod Period { get; set; } = new();
    }
}