using FluentAssertions;
using WalletCore.entity;

namespace WalletCoreTest;


[TestClass]
public class ClientTest
{
    [TestMethod]
    public void ConstructorClient()
    {
        var client = new Client("test", "test@teste.com");

        Assert.IsNotNull(client.Id);
        client.Name.Should().Be("test");
        client.Email.Should().Be("test@teste.com");
    }

    [TestMethod]
    public void ConstructWithInvalidArg()
    {
        Action act = () => new Client("", "");

        act.Should().Throw<Exception>();
    }

    [TestMethod]
    public void UpdateTest_AsExpected()
    {
        var client = new Client("test", "test@teste.com");
        client.Update(name: "Guilherme", email: "gui@gui.com");

        client.Name.Should().Be("Guilherme");
        client.Email.Should().Be("gui@gui.com");
    }

    [TestMethod]
    public void UpdateTest_WithEmptyValue_GenerateErrosAsExpected()
    {
        var client = new Client("test", "test@teste.com");
        Action act = () => client.Update(name: "", email: "");

        act.Should().Throw<Exception>();
    }

    [TestMethod]
    public void AddAccount_ExecuteAsExpected()
    {
        var client = new Client("Cliente Test", "test@teste.com");
        var account = new Account(client);
        client.AddAccount(account);

        client.Accounts.Count.Should().BeGreaterThan(0);
    }
}