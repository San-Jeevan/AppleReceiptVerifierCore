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
        /// <param name="receiptData">The Base64 encoded receipt data.</param>
        /// <param name="password">Your app's shared secret (a hexadecimal string). Use this field only for receipts that contain auto-renewable subscriptions.</param>
        /// <param name="excludeOldTransactions">Set this value to true for the response to include only the latest renewal transaction for any subscriptions. Use this field only for app receipts that contain auto-renewable subscriptions.</param>
        /// <returns>returns Response</returns>
        Task<AppleReceiptResponse> ValidateReceipt(Uri postUri, string base64_receiptData, string password = null, bool excludeOldTransactions = false);
    }
}
