using FluentAssertions;
using NSubstitute;
using WalletCore.entity;
using WalletCore.gateway;
using WalletCore.useCases.CreateAccount;
using WalletCore.useCases.CreateTransaction;

namespace WalletCoreTest.useCases;

[TestClass]
public class CreateTransactionUseCaseTest
{
    public ITransactionRepository transactionRepository { get; private set; }
    public IAccountRepository accountRepository { get; private set; }

    public CreateTransactionUseCaseTest()
    {
        transactionRepository = Substitute.For<ITransactionRepository>();
        accountRepository = Substitute.For<IAccountRepository>();
    }

    [TestMethod]
    public void CreateTransaction_AsExpected()
    {
        var accountFrom = new Account(new Client("Tteste", "teste@teste.com"));
        accountFrom.Credit(100);
        var accountTo = new Account(new Client("Teste 2", "teste2@teste.com"));

        accountRepository.FindById(Arg.Is<Guid>(accountFrom.Id)).Returns(accountFrom);
        accountRepository.FindById(Arg.Is<Guid>(accountTo.Id)).Returns(accountTo);

        var transaction = new CreateTransactionInputDto
        {
            AccountFromId = accountFrom.Id,
            AccountToId = accountTo.Id,
            Amout = 10
        };

        var useCase = new CreateTransactionUseCase(accountRepository, transactionRepository);
        var outPut = useCase.Execute(transaction);

        outPut.GetType().Should().Be(typeof(CreateTransactionOutputDto));
        outPut.TransactionId.Should().NotBe(Guid.Empty);
        accountRepository.Received(2).FindById(Arg.Any<Guid>());
        transactionRepository.Received(1).Create(Arg.Any<Transactions>());
    }
}