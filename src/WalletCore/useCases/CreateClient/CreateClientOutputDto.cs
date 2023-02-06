namespace WalletCore.useCases.CreateClient;

public class CreateClientOutputDto
{
    public Guid Id;
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
}