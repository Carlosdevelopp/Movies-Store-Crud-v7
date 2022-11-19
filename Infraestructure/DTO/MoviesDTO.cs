using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DTO
{
    public class MoviesDTO
    {
        public string TitleMovie { get; set; }  
        public string DescriptionMovie { get; set; }
        public int RunningTimeMovie { get; set; }   
        public DateTime ReleaseMovie { get; set; }
        public string Genre { get; set; }   
    }
}
