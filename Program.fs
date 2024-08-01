// Define the genre discriminated union
type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

// Define the Director record type
type Director = {
    Name: string
    Movies: int
}

// Define the Movie record type
type Movie = {
    Name: string
    RunLength: int
    Genre: Genre
    Director: Director
    ImdbRating: float
}

// Step 1: Create movie instances
let movies = [
    {
        Name = "CODA"
        RunLength = 111
        Genre = Drama
        Director = { Name = "Sian Heder"; Movies = 9 }
        ImdbRating = 8.1
    }
    {
        Name = "Belfast"
        RunLength = 98
        Genre = Comedy
        Director = { Name = "Kenneth Branagh"; Movies = 23 }
        ImdbRating = 7.3
    }
    {
        Name = "Don't Look Up"
        RunLength = 138
        Genre = Comedy
        Director = { Name = "Adam McKay"; Movies = 27 }
        ImdbRating = 7.2
    }
    {
        Name = "Drive My Car"
        RunLength = 179
        Genre = Drama
        Director = { Name = "Ryusuke Hamaguchi"; Movies = 16 }
        ImdbRating = 7.6
    }
    {
        Name = "Dune"
        RunLength = 155
        Genre = Fantasy
        Director = { Name = "Denis Villeneuve"; Movies = 24 }
        ImdbRating = 8.1
    }
    {
        Name = "King Richard"
        RunLength = 144
        Genre = Sport
        Director = { Name = "Reinaldo Marcus Green"; Movies = 15 }
        ImdbRating = 7.5
    }
    {
        Name = "Licorice Pizza"
        RunLength = 133
        Genre = Comedy
        Director = { Name = "Paul Thomas Anderson"; Movies = 49 }
        ImdbRating = 7.4
    }
    {
        Name = "Nightmare Alley"
        RunLength = 150
        Genre = Thriller
        Director = { Name = "Guillermo Del Toro"; Movies = 22 }
        ImdbRating = 7.1
    }
]

// Step 2: Create a list of all movie names
let movieNames =
    movies
    |> List.map (fun movie -> movie.Name)

// Step 3: Convert movie run length to hours and minutes format
let convertRunLengthToHoursMinutes runLength =
    let hours = runLength / 60
    let minutes = runLength % 60
    sprintf "%dh %dmin" hours minutes

let movieRunLengthsInHoursMinutes = 
    movies
    |> List.map (fun movie -> convertRunLengthToHoursMinutes movie.RunLength)

// Step 4: Identify probable Oscar winners
let probableOscarWinners = 
    movies
    |> List.filter (fun movie -> movie.ImdbRating > 7.4)

// Output results
printfn "List of All Movies:"
movieNames |> List.iter (fun name -> printfn "%s" name)

printfn "\nMovie Run Lengths in Hours and Minutes:"
movieRunLengthsInHoursMinutes |> List.iter (fun runLength -> printfn "%s" runLength)

printfn "\nProbable Oscar Winners:"
probableOscarWinners |> List.iter (fun movie -> printfn "%s" movie.Name)
