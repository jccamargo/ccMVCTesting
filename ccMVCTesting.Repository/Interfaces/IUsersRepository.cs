using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ccMVCTesting.Model;

namespace ccMVCTesting.Repository.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<User> SelectAll();
        User SelectByID(object id);
        void Insert(User obj);
        void Update(User obj);
        void Delete(object id);
        void Save();
        void Dispose();

    } // interface

} // namespace
