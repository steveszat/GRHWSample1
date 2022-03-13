using GRHWLibrary;
#region Constants
const string dataPath = @"D:\Temp\RandomData";
const string commaDelimitedFilename = "randomdata.csv";
const string commaDelimitedDataPath = $"{dataPath}\\{commaDelimitedFilename}";
const string pipedDataFilename = "pipeddata.csv";
const string pipedDataPath = $"{dataPath}\\{pipedDataFilename}";
const string spacedDataFilename = "spaceddata.csv";
const string spacedDataPath = $"{dataPath}\\{spacedDataFilename}";

#endregion Constants
char delimiter = ',';
string filePath = commaDelimitedDataPath;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getdata", () =>
{
    var data =
        new SomeDataProvider()
        .GetData(new SomeFileReader(filePath), delimiter);

    return data;
})
.WithName("GetData");


app.MapGet("/getdata/color", () =>
{
    var data =
        new SomeDataProvider()
        .GetData(new SomeFileReader(filePath), delimiter)
        .OrderBy(d => d.FavoriteColor)
                .ThenBy(d => d.LastName)
                .ToList<SomeData>();

    return data;
})
.WithName("GetDataByColor");

app.MapGet("/getdata/birthdate", () =>
{
    var data =
        new SomeDataProvider()
        .GetData(new SomeFileReader(filePath), delimiter)
        .OrderBy(d => d.DateOfBirth)
         .ToList<SomeData>();

    return data;
})
.WithName("GetDataByDoB");

app.MapGet("/getdata/name", () =>
{
    var data =
        new SomeDataProvider()
        .GetData(new SomeFileReader(filePath), delimiter)
        .OrderByDescending(d => d.LastName)
                .ToList<SomeData>();

    return data;
})
.WithName("GetDataByLastNameDescending");

app.MapPost("/putdata", (SomeData someData) =>
{
    // let's pretend this is the existing data
    var list = new List<SomeData>()
    {  
        new SomeData { LastName = "Szatkowski", FirstName = "Steve", Email = "steveszat@hotmail.com", FavoriteColor="Blue", DateOfBirth = new DateTime(2000, 12, 12) } // not my acutual DoB 
    };
    list.Add(someData);

})
.WithName("PutSomeData");

app.Run();
