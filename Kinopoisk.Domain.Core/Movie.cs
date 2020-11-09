using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kinopoisk.Domain.Core
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(50), MinLength(1)]

        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public string Name { get; set; }
        public string description { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public double Rating { get; set; }
        public string PhotoPath { get; set; }
        public List<MovieActors> Actors { get; set; }

        public Movie()
        {
            Actors = new List<MovieActors>();

        }
    }
}
