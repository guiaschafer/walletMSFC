namespace WalletCore.entity;

public class Client : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Account> Accounts { get; set; }

    public Client(string name, string email)
    {
        Name = name;
        Email = email;
        Accounts = new List<Account>();
        Validate();
    }

    public override void Validate()
    {
        if (String.IsNullOrEmpty(Name))
            throw new Exception("Name is mandatory"); ;
        if (String.IsNullOrEmpty(Email))
            throw new Exception("Email is mandatory");

    }

    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
        UpdateAt = DateTime.Now;
        Validate();
    }

    public Client AddAccount(Account account)
    {
        if (account.Client.Id != Id)
            throw new Exception("Account doesn't belong to client");

        Accounts.Add(account);
        return this;
    }
}