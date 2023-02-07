namespace WalletCore.entity;

public class Account: BaseEntity
{
    public Client Client { get; set; }
    public decimal Balance { get; set; }

    public Account(Client client)
    {
        if(client == null)
            throw new ArgumentNullException("Client is mandatory to create an account");

        Client = client;
        Balance = 0;
    }

    public decimal Credit(decimal amount)
    {
        Balance += amount;
        UpdateAt = DateTime.Now;

        return Balance;
    }


    public decimal Debit(decimal amount)
    {
        Balance -= amount;
        UpdateAt = DateTime.Now;

        return Balance;
    }



}