using GUI.Models;
using System.Collections.Generic;

namespace Logic
{
    public interface FuncService
    {
        IEnumerable<BookDb> GetBooks();
        BookDb FindBook(int id);
        void UpdateBook(BookDb updatedBook);

        void AddUser(UserDb users);

        void UpdateUser(UserDb users);

        void RemoveUser(string email);

        void AddPersonal(PersonalDb personal);

        void UpdatePersonal(PersonalDb personal);

        void RemovePersonal(string email);
        UserDb GetUserInfo(string email);
        PersonalDb GetPersonalInfo(string email);
      
    }
}
