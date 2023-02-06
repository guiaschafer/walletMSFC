using FluentAssertions;
using WalletCore.entity;

namespace WalletCoreTest.entity;

[TestClass]
public class AccountTest
{
    [TestMethod]
    public void CreateAccount_AsExpected()
    {
        var client = new Client("Cliente Test", "test@teste.com");
        var account = new Account(client);

        account.Should().NotBeNull();
        account.Client.Id.Should().Be(client.Id);
    }

    [TestMethod]
    public void CreateAccount_WithoutClient_ShouldThrowAnException()
    {
        Action act = () => new Account(null);

        act.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void Credit_ExecuteAsExpected()
    {
        var client = new Client("Cliente Test", "test@teste.com");
        var account = new Account(client);

        account.Credit(100);
        var result = account.Credit(10);

        result.Should().Be(110);
    }
}
