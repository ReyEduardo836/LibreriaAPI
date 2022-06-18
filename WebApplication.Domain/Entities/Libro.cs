using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication.Domain.Entities
{
    public partial class Libro
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Temas { get; set; }
        public string Editorial { get; set; }
    }
}
