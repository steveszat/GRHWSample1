using GRHWLibrary;
#region Constants
const string dataPath = @"D:\Temp\RandomData";
const string randomDataFilename = "randomdata.csv";
const string randomDataPath = $"{dataPath}\\{randomDataFilename}";
const string pipedDataFilename = "pipeddata.csv";
const string pipedDataPath = $"{dataPath}\\{pipedDataFilename}";
const string spacedDataFilename = "spaceddata.csv";
const string spacedDataPath = $"{dataPath}\\{spacedDataFilename}";
#endregion Constants

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
        .GetData(new SomeFileReader(randomDataPath), ',');

    return data;
})
.WithName("GetData");


app.MapGet("/getdata/color", () =>
{
    var data =
        new SomeDataProvider()
        .GetData(new SomeFileReader(randomDataPath), ',')
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
        .GetData(new SomeFileReader(randomDataPath), ',')
        .OrderBy(d => d.DateOfBirth)
         .ToList<SomeData>();

    return data;
})
.WithName("GetDataByDoB");

app.MapGet("/getdata/name", () =>
{
    var data =
        new SomeDataProvider()
        .GetData(new SomeFileReader(randomDataPath), ',')
        .OrderByDescending(d => d.LastName)
                .ToList<SomeData>();

    return data;
})
.WithName("GetDataByLastNameDescending");

app.Run();
