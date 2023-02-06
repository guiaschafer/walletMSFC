using WalletCore.entity;
using WalletCore.gateway;

namespace WalletCore.useCases.CreateClient;

public class CreateClientUseCase 
{
    readonly IClientGateway _clientGateway;

    public CreateClientUseCase(IClientGateway clientGateway)
    {
        this._clientGateway = clientGateway;
    }

    public CreateClientOutputDto Execute(CreateClientInputDto inputDto){
        var client = new Client(inputDto.Name, inputDto.Email);
        
        _clientGateway.Save(client);
        return new CreateClientOutputDto{
            Id = client.Id,
            Name = client.Name,
            Email = client.Email,
            CreateAt = client.CreateAt,
            UpdateAt = client.UpdateAt
        };
    }
}