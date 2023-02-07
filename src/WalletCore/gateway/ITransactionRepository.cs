using WalletCore.entity;

namespace WalletCore.gateway;

public interface ITransactionRepository
{
    void Create(Transactions transaction);
}