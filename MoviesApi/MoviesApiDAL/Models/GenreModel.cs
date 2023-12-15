using MoviesApiDTO.Models;

namespace MoviesApiDAL.Models;

public class GenreModel : DalBaseModel
{
    public string? Genre { get; set; }

    public Guid MovieModelId { get; set; } 
    public MovieModel Movie { get; set; }

    public GenreModel()
    {
    }

    public GenreModel(GenreDto dto)
    {
        Id = dto.Id;
        CreatedDate = dto.CreatedDate;
        LastModifiedDate = dto.LastModifiedDate;
        Genre = dto.Genre;
    }

    public GenreDto MapToDto()
    {
        return new GenreDto()
        {
            Id = Id,
            CreatedDate = CreatedDate,
            LastModifiedDate = LastModifiedDate,
            Genre = Genre
        };
    }
}

