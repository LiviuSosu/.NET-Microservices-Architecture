using System;
using System.ComponentModel.DataAnnotations;

namespace MicroservicesProjectArchitecture.Domain.Entities
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }
    }
}
