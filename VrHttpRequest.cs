// ***********************************************************************
// Assembly         : FCS.Lib.Virk
// Author           : 
// Created          : 2023-10-02
// 
// Last Modified By : root
// Last Modified On : 2023-10-13 07:33
// ***********************************************************************
// <copyright file="VrHttpRequest.cs" company="FCS">
//     Copyright (C) 2015 - 2023 FCS Frede's Computer Service.
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

using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using FCS.Lib.Common;

namespace FCS.Lib.Virk
{
    /// <summary>
    ///     Registrar http request
    /// </summary>
    public class VrHttpRequest
    {
        /// <summary>
        ///     Async registrar http request
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="jsonData"></param>
        /// <param name="auth"></param>
        /// <param name="userAgent"></param>
        /// <returns>VrResponseView object</returns>
        /// <see cref="HttpResponseView" />
        public async Task<HttpResponseView> GetResponseAsync(string endpoint, string jsonData, string auth,
            string userAgent)
        {
            using var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            using var vrRequest = new HttpRequestMessage(HttpMethod.Post, endpoint);

            vrRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", $"{auth}");
            vrRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            vrRequest.Headers.Add("User-Agent", userAgent);
            vrRequest.Content = content;

            var response = await client.SendAsync(vrRequest).ConfigureAwait(true);
            var jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

            return new HttpResponseView
            {
                Code = response.StatusCode,
                IsSuccessStatusCode = response.IsSuccessStatusCode,
                Message = jsonResult
            };
        }
    }
}