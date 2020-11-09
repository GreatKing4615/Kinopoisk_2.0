using Kinopoisk.Domain.Core;

namespace Kinopoisk.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Person Add(Person Person);
        Person GetPerson(string login);
        Person Chek(string login, string password);
    }
}
