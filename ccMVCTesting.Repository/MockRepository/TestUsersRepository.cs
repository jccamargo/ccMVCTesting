using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccMVCTesting.Model;
using ccMVCTesting.Repository.Interfaces;
using System.Data.Entity;
using System.Security.Permissions;

namespace ccMVCTesting.Repository.MockRepository
{
    public class TestUsersRepository : IUsersRepository
    {

        #region "Repository methods implementation"

        private List<User> data = new List<User>();
 
        public IEnumerable<User> SelectAll()
        {
            return data;
        }
 
        public User SelectByID(object id)
        {
            return data.Find(m => m.UserID == (int) id);
        }
 
        public void Insert(User obj)
        {
            data.Add(obj);
        }
 
        public void Update(User obj)
        {
            User existing = data.Find(m => m.UserID == obj.UserID);
            existing = obj;
        }
 
        public void Delete(object id)
        {
            User existing = data.Find(m => m.UserID == (int) id);
            data.Remove(existing);
        }
 
        public void Save()
        {
            //nothing here
        }

        public void Dispose()
        {
            if (null != data)
            {
                data.Clear();
                data = null;
            }
        }

        #endregion

        #region "Create test data"

        // create as many User test records as requested in param Qty
        public int CreateTestData(int iCase, int Qty)
        {
            int LastID = 0;
            const int PACE = 4;

            for (int i=0; i < Qty; i++)
            {
                //
                int id = PACE * i;
                //
                User u = new User()
                {
                    CurrentEMail = "pato." + i.ToString() + "." + id.ToString() + "@pata.com",
                    Active = true,
                    Created = DateTimeOffset.UtcNow,
                    FailedAttempts = 0,
                    UserID = id
                };
                //
                Insert(u);
                LastID = u.UserID;
                //
            } // for
            //
            return LastID;
            //
        }

        #endregion

    } // class

} // namespace
