using GUI.Models;
using System.Linq;

namespace Logic
{
    public class GetData
    {
        private readonly librarysystemdbContext _db = new librarysystemdbContext();
        public IQueryable<UserDb> GetUsers() => _db.UserDbs;
        public IQueryable<PersonalDb> GetPesonal() => _db.PersonalDbs;
        public IQueryable<BookDb> GetBooks() => _db.BookDbs;

        public BookDb FindBook(int id)
        {
            var obj = GetBooks();

           var book = obj.SingleOrDefault(x => x.Id == id);

            return book;
        }

        public async void UpdateBook(BookDb updatedBook)
        {
            _db.BookDbs.Update(updatedBook);
            await _db.SaveChangesAsync();
        }
        public UserDb GetUserinfo(string email)
        {
             var obj = GetUsers();

            return obj.SingleOrDefault(x => x.Email == email); 
        }
        public PersonalDb GetPersonalinfo(string email)
        {
            var obj = GetPesonal();

            return obj.SingleOrDefault(x => x.Email == email);
        }

        public async void AddUserAsync(UserDb users)
        {

          await _db.UserDbs.AddAsync(users);
          await  _db.SaveChangesAsync();

        }

        public async void UpdateUserAsync(UserDb users)
        {
            _db.UserDbs.Update(users);
            await _db.SaveChangesAsync();
        }

        public async void RemoveUserAsyc(string email)
        {
            var objlist = GetUsers();

            var user = objlist.SingleOrDefault(x => x.Email == email);

            _db.UserDbs.Remove(user);
            await _db.SaveChangesAsync();

        }

        public async void AddPersonalAsync(PersonalDb personal)
        {
            await _db.PersonalDbs.AddAsync(personal);
            await _db.SaveChangesAsync();
        }

        public async void UpdatePersonalAsync(PersonalDb personal)
        {
            _db.PersonalDbs.Update(personal);
            await _db.SaveChangesAsync();
        }

        public async void RemovePersonalAsyc(string email)
        {
            var personal = GetPesonal().SingleOrDefault(x => x.Email == email);
            _db.PersonalDbs.Remove(personal);
            await _db.SaveChangesAsync();
        }

    }
}
