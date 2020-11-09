using Kinopoisk.Domain.Core;
using System.Collections.Generic;
using System.Linq;

namespace Kinopoisk.Domain.Interfaces
{
    public interface IActorRepository
    {
        
        Actor Like(int id);
        Actor Dislike(int id);
        Actor GetActor(int id);
        IQueryable<Actor> GetActorOrdered(int options);

    }
}
