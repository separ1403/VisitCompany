namespace Framework.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class NeedsPermissionAttribute : Attribute
    {
        public int Permission { get; }

        public NeedsPermissionAttribute(int permission)
        {
            Permission = permission;
        }
    }

}
