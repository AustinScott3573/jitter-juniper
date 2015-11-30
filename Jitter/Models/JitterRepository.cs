using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jitter.Models
{
    public class JitterRepository
    {
        private JitterContext _context;
        public JitterContext Context { get { return _context; } }

        public JitterRepository()
        {
            _context = new JitterContext();
        }

        public JitterRepository(JitterContext a_context)
        {
            _context = a_context;
        }

        public List<JitterUser> GetAllUsers()
        {
            var query = from users in _context.JitterUsers select users;
            return query.ToList();
        }

        public JitterUser GetUserByHandle(string handle)
        {
            //SQL: Select * from JitterUsers where JitterUser.Handler = handle;
            var query = from users in _context.JitterUsers where users.Handle == handle select users;
            // IQueryable<JitterUser> query = from user in _conext.JitterUsers where user.Handle == handle select unselect;
            return query.Single<JitterUser>();
            // throw new NotImplementedException();
        }
    }
}