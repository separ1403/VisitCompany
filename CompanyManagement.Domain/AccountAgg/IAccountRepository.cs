using AccountManagement.Application.Contracts.Account;
using Framework.Domain;

namespace CompanyManagement.Domain.AccountAgg
{
    public  interface IAccountRepository :IRepository<long ,Account >
    {
        EditAccount Getdetails(long id);
        ChangePassword Getdetail(long id);
        List<AccountViewModel> Serach(AccountSearchModel searchModel);
        List<Account> GetAccountsByIds(List<long> accountIds);

        AccountViewModel GetLastLogin( string searchModel);
        Account GetBy(string userName);
        Account GetById(long id);
        Account GetByMobile(string mobile); // Add this method to fetch account by mobile number

        List<AccountViewModel> GetAccounts();
        bool ActiveUser(string activeCode);

    }
}
