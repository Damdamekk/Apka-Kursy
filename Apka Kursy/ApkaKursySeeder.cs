using Apka_Kursy.Entities;

namespace Apka_Kursy
{
    public class ApkaKursySeeder
    {
        private readonly Apka_KursyDBContext _dbContext;
        public ApkaKursySeeder(Apka_KursyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (!_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Admin"
                },
                new Role()
                {
                    Name = "Kursant"
                },
                new Role()
                {
                    Name = "Nauczyciel"
                }
                
            };

            return roles;

        }
    }
}
