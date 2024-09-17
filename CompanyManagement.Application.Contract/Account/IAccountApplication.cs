using Framework.Application;

namespace AccountManagement.Application.Contracts.Account
{
    public  interface IAccountApplication
    {
        OperationResult Edit(EditAccount command);
        OperationResult Register (RegisterAccount command);
        OperationResult ChangePassword(ChangePassword command);
        EditAccount Getdetails(long id);
        ChangePassword Getdetail(long id);
        List<AccountViewModel> Serach(AccountSearchModel searchModel);
        AccountViewModel GetLastLogin(string searchModel);
        AccountViewModel GetByMobile(string mobile);
        OperationResult Login(Login command);
        void Logout();
        List<AccountViewModel> GetAccounts();
        AccountViewModel GetAccountBy(long id);
        bool ActiveUser(string activeCode);
        void UpdateLastLogin(long accountId);




    }
}
