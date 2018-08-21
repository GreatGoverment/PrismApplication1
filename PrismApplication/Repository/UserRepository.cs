using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismApplication.Entity;

namespace PrismApplication.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MyDbContext context) : base(context, context.Users) { }



        public User FindOne(string userId, string Password) => 
            base.FindOne(u => u.Id == userId && u.Password == Password);
        
        public override void Insert(User u)
        {
            context.Users.Add(u);
            context.SaveChanges();
        }
        
    }
}
