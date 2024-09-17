﻿namespace Framework.Application
{
    public  interface  IAuthHelper
    {
        void Signin(AuthViewModel account);
        void Signout ();
        bool IsAuthenticated ();
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();
        long CurrentAccountId();
        List<int> GetPrimissions();

    }
}
