using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.Tables
{
    public class Genres
    {
        [Key]
        public int GenreId { get; set; }    
        public string Genre { get; set; }   

        public virtual ICollection<Movies> Movies { get; set; } 
    }
}
