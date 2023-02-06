using FluentAssertions;
using NSubstitute;
using WalletCore.entity;
using WalletCore.gateway;
using WalletCore.useCases.CreateClient;

namespace WalletCoreTest.useCases;

[TestClass]
public class CreateClientUseCaseTest
{
    [TestMethod]
    public void CreateClientUseCase_ExecuteAsExpected()
    {
        IClientGateway gateway = Substitute.For<IClientGateway>();

        var useCase = new CreateClientUseCase(gateway);
        CreateClientOutputDto output = useCase.Execute(new CreateClientInputDto{
            Name = "Teste",
            Email = "teste@teste.com"
        });

        output.Should().NotBeNull();
        output.Name.Should().Be("Teste");
        output.Email.Should().Be("teste@teste.com");
        output.GetType().Should().Be(typeof(CreateClientOutputDto));
        gateway.Received(1).Save(Arg.Any<Client>());
    }
}