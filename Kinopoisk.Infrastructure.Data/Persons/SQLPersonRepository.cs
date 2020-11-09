using Kinopoisk.Domain.Core;
using Kinopoisk.Domain.Interfaces;
using System.Linq;

namespace Kinopoisk.Infrastructure.Data.Persons
{
    public class SQLPersonRepository: IPersonRepository
    {
        private  KinopoiskDbContext _context;

        public SQLPersonRepository(KinopoiskDbContext kinopoiskDbContext)
        {
            _context = kinopoiskDbContext;
        }

        public Person GetPerson(string login)
        {
            return _context.Persons.FirstOrDefault(x=>x.Login== login);
        }

        public Person Add(Person Person)
        {
            _context.Persons.Add(Person);
            _context.SaveChanges();
            return Person;
        }

        public Person Chek(string login, string password)
        {
            return _context.Persons.FirstOrDefault(x => x.Login == login  && x.Password == password);
        }
    }
}
