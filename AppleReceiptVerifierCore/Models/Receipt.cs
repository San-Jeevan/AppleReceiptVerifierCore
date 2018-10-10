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
        public int adam_id { get; set; }
        public int app_item_id { get; set; }
        public string bundle_id { get; set; }
        public string application_version { get; set; }
        public int download_id { get; set; }
        public int version_external_identifier { get; set; }
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
    }
}