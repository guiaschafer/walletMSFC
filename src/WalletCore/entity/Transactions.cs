namespace WalletCore.entity;

public class Transactions
{
    public Guid Id { get; set; }
    public Account AccountFrom { get; set; }

    public Account AccountTo { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public Transactions(Account accountFrom, Account accountTo, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero");

        if (accountFrom.Balance < amount)
            throw new InvalidOperationException("Insufficient funds");

        Id = Guid.NewGuid();
        AccountFrom = accountFrom;
        AccountTo = accountTo;
        Amount = amount;
        CreatedAt = DateTime.Now;

        Commit();
    }

    private void Commit()
    {
        AccountFrom.Debit(Amount);
        AccountTo.Credit(Amount);
    }
}

