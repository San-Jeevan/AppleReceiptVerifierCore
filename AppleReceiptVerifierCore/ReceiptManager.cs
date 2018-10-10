using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppleReceiptVerifierCore.Interfaces;
using AppleReceiptVerifierCore.Models;
using Newtonsoft.Json;

namespace AppleReceiptVerifierCore
{
    /// <summary>
    /// Receipt Manager
    /// </summary>
    public class ReceiptManager : IReceiptManager
    {
        /// <summary>
        /// The apple HTTP request
        /// </summary>
        private IAppleHttpRequest appleHttpRequest;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptManager" /> class.
        /// </summary>
        public ReceiptManager()
        {
            this.appleHttpRequest = new AppleHttpRequest();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptManager" /> class.
        /// </summary>
        /// <param name="appleHttpRequest">The apple HTTP request.</param>
        internal ReceiptManager(IAppleHttpRequest appleHttpRequest)
        {
            this.appleHttpRequest = appleHttpRequest;
        }

        /// <summary>
        /// Validate Receipt
        /// </summary>
        /// <param name="postUri">Uri to post receipt data to</param>
        /// <param name="receiptData">receipt data from apple</param>
        /// <param name="password">Your app’s shared secret (a hexadecimal string). Only used for receipts that contain auto-renewable subscriptions.</param>
        /// <returns>returns <see cref="Response" />Response</returns>
        public async Task<AppleReceiptResponse> ValidateReceipt(Uri postUri, string base64_receiptData, string password = null)
        {
            try
            {
                Dictionary<string, string> postObject = new Dictionary<string, string>();
                postObject.Add("receipt-data", base64_receiptData);

                if (!string.IsNullOrEmpty(password))
                {
                    postObject.Add("password", password);
                }
                
                string json = JsonConvert.SerializeObject(postObject);

                var rawResponse = await this.appleHttpRequest.GetResponse(postUri, json);
                var serializedResponse = JsonConvert.DeserializeObject<AppleReceiptResponse>(rawResponse);
                if (serializedResponse != null)
                {
                    return serializedResponse;
                }
            }
            catch
            {
            }
            
            return new AppleReceiptResponse() { status = 1 };
        }
    }
}
