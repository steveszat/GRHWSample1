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
List<string> commaData = new List<string>()
{
    "Szatkowski,Steve,steveszat@hotmail.com,Blue,12/21/2012"
};

List<string> pipeData = new List<string>()
{
    "Szatkowski|Steve|steveszat@hotmail.com|Blue|12/21/2012"
};

List<string> spaceData = new List<string>()
{
    "Szatkowski Steve steveszat@hotmail.com Blue 12/21/2012"
};
var someData = new List<SomeData>()
{
    new SomeData { LastName = "Szatkowski", FirstName = "Steve", Email = "steveszat@hotmail.com", FavoriteColor="Blue", DateOfBirth = new DateTime(2000, 12, 12) } // not my acutual DoB 
};


char delimiter = ',';
string filePath = commaDelimitedDataPath;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
    someData =
        new SomeDataProvider()
        .GetData(new SomeFileHandler(filePath), delimiter);

    return someData;
})
.WithName("GetData");


app.MapGet("/getdata/color", () =>
{
    SomeDataProvider provider = new SomeDataProvider();
    someData = provider.GetData(new SomeFileHandler(filePath), delimiter);
    someData = provider.SortData("color", someData);

    return someData;
})
.WithName("GetDataByColor");

app.MapGet("/getdata/birthdate", () =>
{
    SomeDataProvider provider = new SomeDataProvider();
    var someData = provider.GetData(new SomeFileHandler(filePath), delimiter);
    someData = provider.SortData("birthdate", someData);

    return someData;
})
.WithName("GetDataByDoB");

app.MapGet("/getdata/name", () =>
{
    SomeDataProvider provider = new SomeDataProvider();
    var someData = provider.GetData(new SomeFileHandler(filePath), delimiter);
    someData = provider.SortData("name", someData);

    return someData;
})
.WithName("GetDataByLastNameDescending");

app.MapPost("/putdata", (SomeData data) =>
{
    someData.Add(data);

})
.WithName("PutSomeData");

app.MapPost("/putdata/comma-delimited", (string lastName, string firstName, string email, string favoriteColor, string birthDate) =>
{
    char delimiter = ',';
    string newData = string.Join(delimiter, 
        new string[] { lastName, firstName, email, favoriteColor, birthDate.ToString() });
    commaData.Add(newData);
})
.WithName("PutDataCommaDelimited");

app.MapPost("/putdata/pipe-delimited", (string lastName, string firstName, string email, string favoriteColor, string birthDate) =>
{
    char delimiter = '|';
    string newData = string.Join(delimiter,
        new string[] { lastName, firstName, email, favoriteColor, birthDate.ToString() });
    pipeData.Add(newData);

})
.WithName("PutDataPipeDelimited");

app.MapPost("/putdata/space-delimited", (string lastName, string firstName, string email, string favoriteColor, string birthDate) =>
{
    char delimiter = ' ';
    string newData = string.Join(delimiter,
        new string[] { lastName, firstName, email, favoriteColor, birthDate.ToString() });
    spaceData.Add(newData);

})
.WithName("PutDataSpaceDelimited");

app.Run();
