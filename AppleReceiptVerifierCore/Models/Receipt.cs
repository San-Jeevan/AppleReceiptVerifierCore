using System.Collections.Generic;

namespace AppleReceiptVerifierCore.Models
{
    public class InApp
    {
        public string quantity { get; set; }
        public string product_id { get; set; }
        public string transaction_id { get; set; }
        public string original_transaction_id { get; set; }
        public string purchase_date { get; set; }
        public string purchase_date_ms { get; set; }
        public string purchase_date_pst { get; set; }
        public string original_purchase_date { get; set; }
        public string original_purchase_date_ms { get; set; }
        public string original_purchase_date_pst { get; set; }
        public string is_trial_period { get; set; }
    }

    public class Receipt
    {
        public string receipt_type { get; set; }
        public long adam_id { get; set; }
        public long app_item_id { get; set; }
        public string bundle_id { get; set; }
        public string application_version { get; set; }
        public long download_id { get; set; }
        public long version_external_identifier { get; set; }
        public string receipt_creation_date { get; set; }
        public string receipt_creation_date_ms { get; set; }
        public string receipt_creation_date_pst { get; set; }
        public string request_date { get; set; }
        public string request_date_ms { get; set; }
        public string request_date_pst { get; set; }
        public string original_purchase_date { get; set; }
        public string original_purchase_date_ms { get; set; }
        public string original_purchase_date_pst { get; set; }
        public string original_application_version { get; set; }
        public List<InApp> in_app { get; set; }
    }

    public class AppleReceiptResponse
    {
        public Receipt receipt { get; set; }
        public int status { get; set; }
        public string environment { get; set; }

        public Receipt latest_expired_receipt_info { get; set; }
        public Receipt latest_receipt_info { get; set; }
        public string latest_receipt { get; set; }
        public string expiration_intent { get; set; }
        public string is_in_billing_retry_period { get; set; }
        public string IsInBillingRetryPeriodDescription
        {
            get
            {
                switch (this.is_in_billing_retry_period)
                {
                    case "1": return "App Store is still attempting to renew the subscription.";
                    case "0": return "App Store has stopped attempting to renew the subscription.";
                    case null:
                    case "":
                        return "No value was set for 'is_in_billing_retry_period'";
                    default: return "Unknown value";
                }
            }
        }
        public string ExpirationIntentDescription
        {
            get
            {
                switch (this.expiration_intent)
                {
                    case "1": return "Customer canceled their subscription.";
                    case "2": return "Billing error; for example customer’s payment information was no longer valid.";
                    case "3": return "Customer did not agree to a recent price increase.";
                    case "4": return "Product was not available for purchase at the time of renewal.";
                    case "5": return "Unknown error.";
                    case null:
                    case "":
                        return "No value was set for 'expiration_intent'";
                    default: return "Unknown value";
                }
            }
        }

        public string StatusDescription
        {
            get
            {
                switch (status)
                {
                    case 2100:
                        return "The App Store could not read the JSON object you provided.";
                    case 21002:
                        return "The data in the receipt-data property was malformed or missing.";
                    case 21003:
                        return "The receipt could not be authenticated.";
                    case 21004:
                        return "The shared secret you provided does not match the shared secret on file for your account. Only returned for iOS 6 style transaction receipts for auto - renewable subscriptions.";
                    case 21005:
                        return "The receipt server is not currently available.";
                    case 21006:
                        return "This receipt is valid but the subscription has expired. When this status code is returned to your server, the receipt data is also decoded and returned as part of the response. Only returned for iOS 6 style transaction receipts for auto - renewable subscriptions.";
                    case 21007:
                        return "This receipt is from the test environment, but it was sent to the production environment for verification. Send it to the test environment instead.";
                    case 21008:
                        return "This receipt is from the production environment, but it was sent to the test environment for verification. Send it to the production environment instead.";
                    case 21010:
                        return "This receipt could not be authorized. Treat this the same as if a purchase was never made.";

                    case 1:
                        return "Something went wrong...";
                    case 0:
                        return "OK";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}