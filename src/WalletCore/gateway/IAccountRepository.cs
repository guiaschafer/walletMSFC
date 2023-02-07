using WalletCore.entity;

namespace WalletCore.gateway;

public interface IAccountRepository {
    void Save(Account account);
    Account FindById(Guid id);
}