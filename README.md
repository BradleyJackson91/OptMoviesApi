# Opt_MoviesApi

Hello, 
This project is a MoviesApi application written in C# .NET 8.
The project uses a tiered architecture and on first run it builds a sqlite db and populates it using the provided csv file.
The project should run on IIS Express as well as a linux docker container. 

There are a couple of non-critical bugs that I have seen and the GetAll endpoint could be optimized by running the paging on the sql side, rather than the c# side. I have not fixed these due to time constraints.

Additionally I have created some notes below on how I would implement the filtering by actors feature. This would require utilizing a 3rd party api service.

Let me know if you have any questions.

Thank you,
Bradley

## Filter by actors

The data provided does not have any information relating to the actors within the movies. In order to provide this feature, it is necessary to utilise another API. The TMDB apis provide the ability to search for an actor by name, and to search for the movies they have appeared in. 

### Steps to implement: 
<ul>
<li>Sign-up with TMDB</li>
<li>Acquire an API key through the settings section.</li>
<li>Test the API through the TMDB web interface. </li>
<li>Use the test result to access the returned JSON. </li>
<li>Use the JSON to create the C# classes for deserializing the json.</li>
<li>Create the code that calls the first TMDB api.</li>
<li>Create the code that deserializes the TMDB json to the C# class.</li>
<li>Create the code that calls the second TMDB api.</li>
<li>Create the code that deserializes the second TMDB json response to the C# classes.</li>
<li>Create the API endpoint to utilise the above code. </li>
</ul>
