namespace EM.Domain.User
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserInRole> UserInRole { get; set; }
    }
}
