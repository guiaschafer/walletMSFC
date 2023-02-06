using WalletCore.entity;

namespace WalletCore.gateway;

public interface IClientGateway
{
    Client Get(Guid id);
    void Save(Client client);
}