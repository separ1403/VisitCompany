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
        List<AccountViewModel> Search(AccountSearchModel searchModel, long? provincialAdminStateCategoryId = null);
        AccountViewModel GetLastLogin(string searchModel);
        List<AccountViewModel> SearchTotal(AccountSearchModel searchModel, long? provincialAdminStateCategoryId = null);

        AccountViewModel GetByMobile(string mobile);
        OperationResult Login(Login command);
        void Logout();
        List<AccountViewModel> GetAccounts();
        AccountViewModel GetAccountBy(long id);
        bool ActiveUser(string activeCode);
        void UpdateLastLogin(long accountId);
        OperationResult DisableAccount(long id);
        OperationResult EnableAccount(long id);





    }
}
