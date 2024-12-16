namespace Framework.Application
{
    public  class AuthViewModel
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }    
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public List<int> Permissions;
        public long StateCategoryId { get; set; }



        public AuthViewModel()
        {
           
        }
        public AuthViewModel(long id, long roleId, string fullname, string username,string mobile, List<int> permissions, long stateCategoryId)
        {
            Id = id;
            RoleId = roleId;
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            Permissions = permissions;
            StateCategoryId = stateCategoryId;
        }
    }
}
