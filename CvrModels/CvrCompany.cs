// ***********************************************************************
// Assembly         : Inno.Api
// Author           : FH
// Created          : 01-01-2022
//
// Last Modified By : FH
// Last Modified On : 01-31-2022
// ***********************************************************************
// <copyright file="CvrCompany.cs" company="FCS">
//     Copyright © FCS 2015-2022
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace FCS.Virk.CvrModels
{
    /// <summary>
    /// Class CvrCompany.
    /// </summary>
    public class CvrCompany
    {
        /// <summary>
        /// Gets or sets the vat number.
        /// </summary>
        /// <value>The vat number.</value>
        public string VatNumber { get; set; } = "";
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; } = "";
        /// <summary>
        /// Gets or sets the name of the co.
        /// </summary>
        /// <value>The name of the co.</value>
        public string CoName { get; set; } = "";
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; } = "";
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; } = "";
        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>The zip code.</value>
        public string ZipCode { get; set; } = "";
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public List<CvrStatus> Status { get; set; } = new();
    }
}