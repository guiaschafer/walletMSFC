using FluentAssertions;
using NSubstitute;
using WalletCore.entity;
using WalletCore.gateway;
using WalletCore.useCases.CreateAccount;

namespace WalletCoreTest.useCases;

[TestClass]
public class CreateAccountUseCaseTest
{
    public IAccountRepository accountRepository { get; private set; }
    public IClientGateway clientRepository { get; private set; }

    public CreateAccountUseCaseTest()
    {
        accountRepository = Substitute.For<IAccountRepository>();
        clientRepository = Substitute.For<IClientGateway>();
    }

    [TestMethod]
    public void CreateAccount_ExecuteAsExpected()
    {
        var guidClient = Guid.NewGuid();
        clientRepository.Get(Arg.Any<Guid>()).Returns(new Client("Teste", "teste@teste.com")
        {
            CreateAt = DateTime.Now.AddDays(-1),
            UpdateAt = DateTime.Now
        });

        var inputDto = new CreateAccountInputDto
        {
            ClientId = guidClient
        };

        var useCase = new CreateAccountUseCase(accountRepository, clientRepository);
        var output = useCase.Execute(inputDto);

        output.GetType().Should().Be(typeof(CreateAccountOutputDto));
        output.Id.Should().NotBe(Guid.Empty);
        clientRepository.Received(1).Get(Arg.Is<Guid>(guidClient));
        accountRepository.Received(1).Save(Arg.Any<Account>());
    }
}