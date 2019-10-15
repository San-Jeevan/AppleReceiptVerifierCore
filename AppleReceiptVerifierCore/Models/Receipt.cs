using System.Collections.Generic;

namespace AppleReceiptVerifierCore.Models
{
    public class InApp
    {
        public string quantity { get; set; }
        public string product_id { get; set; }
        public string transaction_id { get; set; }
        public string original_transaction_id { get; set; }
        public string promotional_offer_id { get; set; }
        public string purchase_date { get; set; }
        public string purchase_date_ms { get; set; }
        public string purchase_date_pst { get; set; }
        public string original_purchase_date { get; set; }
        public string original_purchase_date_ms { get; set; }
        public string original_purchase_date_pst { get; set; }
        public string cancellation_date { get; set; }
        public string cancellation_date_ms { get; set; }
        public string cancellation_date_pst { get; set; }
        public string cancellation_reason { get; set; }
        public string expires_date { get; set; }
        public string expires_date_ms { get; set; }
        public string expires_date_pst { get; set; }
        public string is_in_intro_offer_period { get; set; }
        public string is_trial_period { get; set; }
        public string web_order_line_item_id { get; set; }
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
        public string original_transaction_id { get; set; }
        public string expiration_date { get; set; }
        public string expiration_date_ms { get; set; }
        public string expiration_date_pst { get; set; }
        public string preorder_date { get; set; }
        public string preorder_date_ms { get; set; }
        public string preorder_date_pst { get; set; }
        public List<InApp> in_app { get; set; }
    }

    public class LatestReceipt
    {
        public string cancellation_date { get; set; }
        public string cancellation_date_ms { get; set; }
        public string cancellation_date_pst { get; set; }
        public string cancellation_reason { get; set; }
        public string expires_date { get; set; }
        public string expires_date_ms { get; set; }
        public string expires_date_pst { get; set; }
        public string is_in_intro_offer_period { get; set; }
        public string is_trial_period { get; set; }
        public string is_upgraded { get; set; }
        public string original_purchase_date { get; set; }
        public string original_purchase_date_ms { get; set; }
        public string original_purchase_date_pst { get; set; }
        public string original_transaction_id { get; set; }
        public string product_id { get; set; }
        public string promotional_offer_id { get; set; }
        public string purchase_date { get; set; }
        public string purchase_date_ms { get; set; }
        public string purchase_date_pst { get; set; }
        public string quantity { get; set; }
        public string subscription_group_identifier { get; set; }
        public string transaction_id { get; set; }
        public string web_order_line_item_id { get; set; }
    }    
  
    public class PendingRenewal
    {
        public string auto_renew_product_id { get; set; }
        public string auto_renew_status { get; set; }
        public string expiration_intent { get; set; }
        public string grace_period_expires_date { get; set; }
        public string grace_period_expires_date_ms { get; set; }
        public string grace_period_expires_date_pst { get; set; }
        public string is_in_billing_retry_period { get; set; }
        public string original_transaction_id { get; set; }
        public string price_consent_status { get; set; }
        public string product_id { get; set; }
    }

    public class AppleReceiptResponse
    {
        public Receipt receipt { get; set; }
        public int status { get; set; }
        public string environment { get; set; }
        public PendingRenewal pending_renewal_info { get; set; }
        public LatestReceipt latest_receipt_info { get; set; }
        public string latest_receipt { get; set; }

        public string AutoRenewStatusDescription
        {
            get
            {
                switch (this.pending_renewal_info?.auto_renew_status)
                {
                    case "1": return "The subscription will renew at the end of the current subscription period.";
                    case "0": return "The customer has turned off automatic renewal for the subscription.";
                    case null:
                    case "":
                        return "No value was set for 'auto_renew_status'";
                    default: return "Unknown value";
                }
            }
        }

        public string IsInBillingRetryPeriodDescription
        {
            get
            {
                switch (this.pending_renewal_info?.is_in_billing_retry_period)
                {
                    case "1": return "The App Store is attempting to renew the subscription.";
                    case "0": return "The App Store has stopped attempting to renew the subscription.";
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
                switch (this.pending_renewal_info?.expiration_intent)
                {
                    case "1": return "The customer voluntarily canceled their subscription.";
                    case "2": return "Billing error; for example, the customer's payment information was no longer valid.";
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
                    case 21000:
                        return "The request to the App Store was not made using the HTTP POST request method.";
                    case 21002:
                        return "The data in the receipt-data property was malformed or missing.";
                    case 21003:
                        return "The receipt could not be authenticated.";
                    case 21004:
                        return "The shared secret you provided does not match the shared secret on file for your account.";
                    case 21005:
                        return "The receipt server is not currently available.";
                    case 21006:
                        return "This receipt is valid but the subscription has expired. When this status code is returned to your server, the receipt data is also decoded and returned as part of the response. Only returned for iOS 6-style transaction receipts for auto-renewable subscriptions.";
                    case 21007:
                        return "This receipt is from the test environment, but it was sent to the production environment for verification. Send it to the test environment instead.";
                    case 21008:
                        return "This receipt is from the production environment, but it was sent to the test environment for verification. Send it to the production environment instead.";
                    case 21009:
                        return "Internal data access error. Try again later.";
                    case 21010:
                        return "The user account cannot be found or has been deleted.";
                        
                    case 0:
                        return "OK";
                    default:
                      return "Something went wrong...";
                }
            }
        }
    }
}