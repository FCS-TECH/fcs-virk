﻿// ***********************************************************************
// Assembly         : FCS.Virk
// Author           : FH
// Created          : 02-21-2022
//
// Last Modified By : FH
// Last Modified On : 02-24-2022
// ***********************************************************************
// <copyright file="VrHttpRequest.cs" company="FCS">
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

using System.Net.Http.Headers;
using System.Text;

namespace FCS.Lib.Virk
{
    /// <summary>
    /// Class VrHttpRequest.
    /// </summary>
    public class VrHttpRequest
    {
        /// <summary>
        /// Get response as an asynchronous operation.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="jsonData">The json data.</param>
        /// <param name="auth">The authentication.</param>
        /// <returns>A Task&lt;VrResponseView&gt; representing the asynchronous operation.</returns>
        public async Task<VrResponseView> GetResponseAsync(string endpoint, string jsonData, string auth)
        {
            using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            using var vrRequest = new HttpRequestMessage(HttpMethod.Post, endpoint);

            vrRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", $"{auth}");
            vrRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            vrRequest.Content = content;

            var response = await client.SendAsync(vrRequest).ConfigureAwait(true);
            var jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

            return new VrResponseView
            {
                Code = response.StatusCode,
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                Message = jsonResult
            };
        }
    }
}
