namespace Apka_Kursy.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password_hash { get; set; }
        public DateTime GetDateTime { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
