using GUI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GetData
    {
        private readonly librarysystemdbContext _db = new librarysystemdbContext();
        public IEnumerable<UserDb> GetUser() => _db.UserDbs;
        public IEnumerable<PersonalDb> GetPesonal() => _db.PersonalDbs;
        public IEnumerable<BookDb> GetBooks() => _db.BookDbs;

        public IEnumerable<BookDb> FindBook(int id)
        {
            var obj = GetBooks();

           var book = obj.Where(x => x.Id == id);

             return book;
        }

        public  async void UpdateBook(BookDb updatedBook)
        {
            var obj = GetBooks();
            IEnumerable<int> id = obj.Select(x => x).Where(x => x.Id == updatedBook.Id).Select(x => x.Id);

            var book = _db.BookDbs.Find(id.First());
         
                book.UserId = updatedBook.UserId;
           
            book.Title = updatedBook.Title;
            book.Publisher = updatedBook.Publisher;
            book.Author = updatedBook.Author;
            book.Category = updatedBook.Category;
            book.Ddc = updatedBook.Ddc;

            _db.BookDbs.Update(book);
            await _db.SaveChangesAsync();
        }
        public IEnumerable<UserDb> GetUserinfo(string email)
        {
             var obj = GetUser();

             return obj.Select(x => x).Where(x=> x.Email == email).ToList(); 
        }
        public IEnumerable<PersonalDb> GetPersonalinfo(string email)
        {
            var obj = GetPesonal();

            return obj.Select(x => x).Where(x => x.Email == email);

        }
        public async void AddUserAsync(UserDb users)
        {

          await _db.UserDbs.AddAsync(users);
          await  _db.SaveChangesAsync();

        }
        public async void UpdateUserAsync(UserDb users)
        {
            var objlist = GetUser();

            IEnumerable<int> id = objlist.Select(x => x).Where(x => x.Email == users.Email).Select(x => x.Id);

            var user = _db.UserDbs.Find(id.First());
            user.FirstName = users.FirstName;
            user.LastName = users.LastName;
            user.Password = users.Password;
            user.LibraryCard = users.LibraryCard;

            _db.UserDbs.Update(user);
            await _db.SaveChangesAsync();
        }
        public async void RemoveUserAsyc(string email)
        {
            var objlist = GetUser();
    
            IEnumerable<int> id =  objlist.Select(x => x).Where(x => x.Email == email).Select(x => x.Id);

            var user = _db.UserDbs.Find(id.First());
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
            var objlist = GetPesonal();

            IEnumerable<int> id = objlist.Select(x => x).Where(x => x.Email == personal.Email).Select(x => x.Id);

            var personals = _db.PersonalDbs.Find(id.First());
            personals.FirstName = personal.FirstName;
            personals.LastName = personal.LastName;
            personals.Password = personal.Password;
            personals.JobTitle = personal.JobTitle;

            _db.PersonalDbs.Update(personals);
            await _db.SaveChangesAsync();
        }
        public async void RemovePersonalAsyc(string email)
        {
            var objlist = GetPesonal();

            IEnumerable<int> id = objlist.Select(x => x).Where(x => x.Email == email).Select(x => x.Id);

            var personal = _db.PersonalDbs.Find(id.First());
            _db.PersonalDbs.Remove(personal);
            await _db.SaveChangesAsync();
        }

    }
}
