using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccMVCTesting.Model;
using ccMVCTesting.Repository.Interfaces;
using System.Data.Entity;

namespace ccMVCTesting.Repository.RealRepository
{
    public class UsersRepository : IUsersRepository
    {
        #region "DB Context and constructors"

        private Entities db = null;

        public UsersRepository()
        {
            db = new Entities();
        }

        public UsersRepository(Entities dbContext)
        {
            db = dbContext;
        }

        #endregion

        #region "Repository methods implementation"

        public IEnumerable<User> SelectAll()
        {
            return db.Users.ToList();
        }

        public User SelectByID(object id)
        {
            return db.Users.Find(id);
        }

        public void Insert(User obj)
        {
            db.Users.Add(obj);
        }

        public void Update(User obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            User existing = db.Users.Find(id);
            db.Users.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            if (null != db)
            {
                //if(db.Database.Connection.State==System.Data.ConnectionState.Open)
                //    db.Database.Connection.Close();
                db = null;
            }
        }

        #endregion

    } // class

} // namespace
