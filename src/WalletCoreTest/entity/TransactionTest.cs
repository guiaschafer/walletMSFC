using FluentAssertions;
using WalletCore.entity;

namespace WalletCoreTest.entity;

[TestClass]
public class TransactionTest
{
    [TestMethod]
    public void CreateTransaction_ExecuteAsExpected()
    {
        var clientFrom = new Client("Cliente From", "test@teste.com");
        var accountFrom = new Account(clientFrom);
        accountFrom.Credit(100);

        var clientTo = new Client("Cliente To", "test@teste.com");
        var accountTo = new Account(clientTo);
        accountTo.Credit(100);

        var transaction = new Transactions(accountFrom, accountTo, 50);

        transaction.Should().NotBeNull();      
        accountFrom.Balance.Should().Be(50);
        accountTo.Balance.Should().Be(150);
    }


    [TestMethod]
    public void CreateTransactionWithoutBalance_ExecuteAsExpected()
    {
        var clientFrom = new Client("Cliente From", "test@teste.com");
        var accountFrom = new Account(clientFrom);

        var clientTo = new Client("Cliente To", "test@teste.com");
        var accountTo = new Account(clientTo);

        Action act = () => new Transactions(accountFrom, accountTo, 50);
        act.Should().Throw<InvalidOperationException>();
    }
}
