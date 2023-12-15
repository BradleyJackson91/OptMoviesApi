namespace MoviesApiDTO.Models;

public class MovieDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public DateTime ReleaseDate { get; set; } // Release_Date
    public string? Title { get; set; }
    public string? Overview { get; set; }
    public float Popularity { get; set; }
    public int VoteCount { get; set; } // Vote_Count 
    public float VoteAverage { get; set; } // Vote_Average    
    public string? OriginalLanguage { get; set; } // Original_Language 
    public List<GenreDto>? Genres { get; set; }   
    public string? PosterUrl { get; set; } // Poster_Url
}

