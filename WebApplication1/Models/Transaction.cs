namespace WebApplication1.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public decimal transactionamt { get; set; }
        public DateTime transactiondate { get; set; }
        public int categoryID { get; set; }

        public string transactioncat { get; set; }
        public int account_id { get; set; }

    }
}
