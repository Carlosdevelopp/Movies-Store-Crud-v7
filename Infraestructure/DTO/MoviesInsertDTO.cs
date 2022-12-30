namespace Infrastructure.DTO
{
    public class MoviesInsertDTO
    {
        public string TitleMovie { get; set; }  
        public string DescriptionMovie { get; set; }
        public DateTime ReleaseMovie { get; set; }   
        public int RunningTimeMovie { get; set; }
        public int GenreId { get; set; }    
        public int AwardId { get; set; }    
    }
}
