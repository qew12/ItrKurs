using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ItrKurs.Models
{
    public class Collection
    {
        public byte bitMask{ get; set; }
        public int Id { get; set; }
        public string Discriminator { get; set; }
        public string ImgSrc { get; set; }
        [Required]
        public string Name { get; set; }
        public string Discription { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset Date { get; set; }
        [Required]
        public string Tags { get; set; }
    }

    public class Book : Collection
    {
        public string Genres { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }

    }

    public class Car : Collection
    {
        public string Brand { get; set; }
        public string Country { get; set; }
        public string Engine { get; set; }
        public int Mileage { get; set; }
    }

    public class Anime : Collection
    {
        public string Genres { get; set; }
        public string Studio { get; set; }        
        public string Author { get; set; }
        public int Episodes { get; set; }
    }
}
