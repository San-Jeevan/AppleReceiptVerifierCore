using System;
using System.Threading.Tasks;
using AppleReceiptVerifierCore.Models;

namespace AppleReceiptVerifierCore.Interfaces
{
    /// <summary>
    /// Receipt Manager Interface
    /// </summary>
    public interface IReceiptManager
    {
        /// <summary>
        /// Validate Receipt
        /// </summary>
        /// <param name="postUri">Uri to post receipt data to</param>
        /// <param name="receiptData">receipt data from apple</param>
        /// <param name="password">Your app’s shared secret (a hexadecimal string). Only used for receipts that contain auto-renewable subscriptions.</param>
        /// <returns>returns Response</returns>
        Task<AppleReceiptResponse> ValidateReceipt(Uri postUri, string base64_receiptData, string password = null);
    }
}
