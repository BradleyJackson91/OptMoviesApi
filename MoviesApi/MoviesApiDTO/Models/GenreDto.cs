namespace MoviesApiDTO.Models;

public class GenreDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string? Genre { get; set; }
}

