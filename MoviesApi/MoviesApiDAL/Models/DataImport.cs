using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesApiDAL.Interfaces;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using MoviesApiDTO.Enums;
using MoviesApiDTO.Models;

namespace MoviesApiDAL.Models;
internal class DataImport : IDataImport
{
    public bool HasDataBeenImported()
    {
        string fileName = "MoviesApiDb.sqlite";
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);

        return File.Exists(filePath);
    }

    public ProgressDto ImportData()
    {
        ProgressDto progress = new ProgressDto
        {
            TaskName = "Import Data",
            Description = "Importing CSV data into SQLite db.",
            StartTime = DateTime.Now,
            State = ProgressState.Running
        };

        List<MovieDto> movies;

        // Reading csv file into MovieDto objects.
        try
        {
            progress.SubTaskName = "Reading csv file into MovieDto objects.";

            movies = ReadCsvToMoviesList();
        }
        catch (Exception ex)
        {
            progress.SetToError(ex);
            return progress;
        }

        // Creating the Database.
        try
        {
            progress.TaskName = "Creating the MoviesApi database.";
            DatabaseInitializer.InitializeDatabase();
        }
        catch (Exception ex)
        {
            progress.SetToError(ex);
            return progress;
        }


        // Writing all movie objects to the sqlite 
        try
        {
            progress.TaskName = "Writing Movie objects to database.";
            
            MovieDal movieDal = new MovieDal();

            foreach (MovieDto dto in movies)
            {
                MovieModel movie = new MovieModel(dto);
                movieDal.AddToDb(movie);
            }

            progress.SetToComplete();
            return progress;
        }
        catch (Exception ex)
        {
            progress.SetToError(ex);
            return progress;
        }
    }

    private List<MovieDto> ReadCsvToMoviesList()
    {
        string csvFileName = "mymoviedb.csv";
        string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", csvFileName);


        if (File.Exists(csvFilePath) == false)
        {
            throw new InvalidOperationException("Csv file cannot be found.");
        }

        return ReadCsvFile<MovieCsvModel>(csvFilePath)
            .Select(m => m.MapToDto())
            .ToList();
    }

    private static List<T> ReadCsvFile<T>(string csvFilePath)
    {
        using var reader = new StreamReader(csvFilePath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        return csv.GetRecords<T>().ToList();
    }
}
