using Commission.Domain.ValueObjects;

namespace Commission.Domain.Entities
{
    public class SaleCommission
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public Guid SaleId { get; private set; }
        public string? CurrencyCode { get; private set; }
        public string? CommissionType { get; private set; }
        public bool IsProcessed { get; private set; }

        public Currency Currency => new(CurrencyCode);
        private SaleCommission() { }
        
        public SaleCommission(
            Guid sale_id,
            decimal amount,
            DateTime date,
            Currency currency,
            string commission_type
        )
        {
            if (amount <= 0) throw new ArgumentException(
                "Amount must be greater then zero."
            );
            if (string.IsNullOrEmpty(commission_type)) throw new ArgumentException(
                "CommissionType cannot be null or empty."
            );

            Id = Guid.NewGuid();
            SaleId = sale_id;
            Amount = amount;
            Date = date;
            CurrencyCode = currency.Code;
            CommissionType = commission_type;
            IsProcessed = false;
        }
        public void Process()
        {
            if (IsProcessed) throw new InvalidOperationException(
                "Commission has already been processed."
            );
            IsProcessed = true;
        }
        public void ApplyRate(decimal rate)
        {
            if (rate <= 0) throw new ArgumentException(
                "Rate must be greater then zero."
            );
            Amount *= rate;
        }
    } 
}