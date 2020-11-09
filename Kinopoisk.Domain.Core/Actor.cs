using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kinopoisk.Domain.Core
{
    public class Actor
    {

        public int Id { get; set; }
        [MaxLength(50), MinLength(1)]
        [Required(ErrorMessage = "Поле не может быть пустым.")]
        public string Name { get; set; }
        public string Bio { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public List<MovieActors> Movies { get; set; }
        public double Rating { get; set; }
        public string PhotoPath { get; set; }
        public Actor()
        {
            Movies = new List<MovieActors>();
            Rating = 0;

        }

    }
}
