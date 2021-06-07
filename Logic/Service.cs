using GUI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Service : FuncService
   {
        GetData getData = new GetData();

        void FuncService.UpdateBook(BookDb updatedBook)
        {
            getData.UpdateBook(updatedBook);
        }
      
        public BookDb FindBook(int id) 
        {
          return getData.FindBook(id); 
        }
        public IEnumerable<BookDb> GetBooks() => getData.GetBooks();
        public void AddUser(UserDb users)
        {
            getData.AddUserAsync(users);
        }

        public void UpdateUser(UserDb users)
        {
            getData.UpdateUserAsync(users);
        }

        public void RemoveUser(string email)
        {
            getData.RemoveUserAsyc(email);
        }

        public void AddPersonal(PersonalDb personal)
        {
            getData.AddPersonalAsync(personal);
        }

        public void UpdatePersonal(PersonalDb personal)
        {
            getData.UpdatePersonalAsync(personal);
        }

        public void RemovePersonal(string email)
        {
            getData.RemovePersonalAsyc( email);
        }

        public UserDb GetUserInfo(string email)
        {
           return getData.GetUserinfo( email);
        }
      
        PersonalDb FuncService.GetPersonalInfo(string email)
        {
            return getData.GetPersonalinfo(email);
        }

        public List<BookDb> SearchBooks(string searchWord)
        {
            List<BookDb> searchResult = new List<BookDb>();
            using var dbContex = new librarysystemdbContext();

            searchResult = dbContex.BookDbs.Where(b => b.Author.Contains(searchWord) ||
            b.Isbn.Contains(searchWord) ||
            b.Title.Contains(searchWord) ||
            b.Category.CategoryName.Contains(searchWord))
                .Include(b => b.Category)
                .ToList();

            return searchResult;
        }

       
    }
}
