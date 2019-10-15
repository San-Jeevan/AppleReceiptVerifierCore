using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppleReceiptVerifierCore.Interfaces;


namespace AppleReceiptVerifierCore
{
    /// <summary>
    /// Apple Http Request
    /// </summary>
    internal class AppleHttpRequest : IAppleHttpRequest
    {

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="postData">The data to be posted.</param>
        /// <returns>
        /// response as string
        /// </returns>
        public async Task<string> GetResponse(Uri url, string postData)
        {
            string response = string.Empty;
            var postdata = new StringContent(postData, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                var httpResponse = await httpClient.PostAsync(url, postdata);

                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    return responseContent;
                }
            }

            return response;
        }
    }
}
