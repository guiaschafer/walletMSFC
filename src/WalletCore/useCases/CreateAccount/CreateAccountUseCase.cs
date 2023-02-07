using WalletCore.entity;
using WalletCore.gateway;

namespace WalletCore.useCases.CreateAccount;

public class CreateAccountUseCase
{
    public IAccountRepository accountRepository { get; private set; }
    public IClientGateway clientRepository { get; private set; }
    public CreateAccountUseCase(IAccountRepository accountRepository, IClientGateway clientRepository)
    {
        this.accountRepository = accountRepository;
        this.clientRepository = clientRepository;
    }

    public CreateAccountOutputDto Execute(CreateAccountInputDto inputDto)
    {
        var client = clientRepository.Get(inputDto.ClientId);

        var newAccount = new Account(client);
        accountRepository.Save(newAccount);

        return new CreateAccountOutputDto
        {
            Id = newAccount.Id
        };
    }
}