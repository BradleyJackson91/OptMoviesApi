using MoviesApiDTO.Enums;
using System;
using System.Diagnostics;

namespace MoviesApiDTO.Models;

internal class ProgressDto
{
    public string? TaskName { get; set; }
    public string? SubTaskName { get; set; }
    public string? Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Exception? Exception { get; set; }
    public string? Message { get; set; }
    public ProgressState State { get; set; } = ProgressState.NotStarted;


    public void SetToError(Exception exception)
    {
        Exception = exception;
        Message = exception.Message;
        State = ProgressState.Error;
        EndTime = DateTime.Now;
    }

    public void SetToComplete()
    {
        State = ProgressState.Completed;
        EndTime = DateTime.Now;
    }
}

