namespace WalletCore.useCases.CreateTransaction;

public class CreateTransactionInputDto
{
    public Guid AccountFromId { get; set; }
    public Guid AccountToId { get; set; }
    public decimal Amout { get; set; }
}