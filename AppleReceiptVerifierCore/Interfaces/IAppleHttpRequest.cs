using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleReceiptVerifierCore.Interfaces
{
    /// <summary>
    /// Apple Http Request interface
    /// </summary>
    internal interface IAppleHttpRequest
    {
        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="postData">The data to be posted.</param>
        /// <returns>
        /// response as string
        /// </returns>
        Task<string> GetResponse(Uri url, string postData);
    }
}
