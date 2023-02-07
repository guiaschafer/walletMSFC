using System.Transactions;
using WalletCore.entity;
using WalletCore.gateway;
using Transaction = WalletCore.entity.Transactions;

namespace WalletCore.useCases.CreateTransaction;

public class CreateTransactionUseCase
{
    public ITransactionRepository transactionRepository { get; private set; }
    public IAccountRepository accountRepository { get; private set; }

    public CreateTransactionUseCase(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        this.accountRepository = accountRepository;
        this.transactionRepository = transactionRepository;
    }

    public CreateTransactionOutputDto Execute(CreateTransactionInputDto inputDto)
    {
        Account accountFrom = accountRepository.FindById(inputDto.AccountFromId);
        Account accountTo = accountRepository.FindById(inputDto.AccountToId);

        var transaction = new Transaction(accountFrom, accountTo, inputDto.Amout);

        transactionRepository.Create(transaction);

        return new CreateTransactionOutputDto
        {
            TransactionId = transaction.Id
        };
    }
}