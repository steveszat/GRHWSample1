using GRHWLibrary;
#region Constants
const string dataPath = @"D:\Temp\RandomData";
const string commaDelimitedFilename = "randomdata.csv";
const string commaDelimitedDataPath = $"{dataPath}\\{commaDelimitedFilename}";
const string pipedDataFilename = "pipeddata.csv";
const string pipedDataPath = $"{dataPath}\\{pipedDataFilename}";
const string spacedDataFilename = "spaceddata.csv";
const string spacedDataPath = $"{dataPath}\\{spacedDataFilename}";
Dictionary<char, string> delimFiles
    = new Dictionary<char, string>()
    {
        { ',', commaDelimitedFilename },
        { '|', pipedDataFilename },
        { ' ', spacedDataFilename }
    };
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
        .GetData(new SomeFileHandler(filePath), delimiter);

    return data;
})
.WithName("GetData");


app.MapGet("/getdata/color", () =>
{
    SomeDataProvider provider = new SomeDataProvider();
    var data = provider.GetData(new SomeFileHandler(filePath), delimiter);
    data = provider.SortData("color", data);

    return data;
})
.WithName("GetDataByColor");

app.MapGet("/getdata/birthdate", () =>
{
    SomeDataProvider provider = new SomeDataProvider();
    var data = provider.GetData(new SomeFileHandler(filePath), delimiter);
    data = provider.SortData("birthdate", data);

    return data;
})
.WithName("GetDataByDoB");

app.MapGet("/getdata/name", () =>
{
    SomeDataProvider provider = new SomeDataProvider();
    var data = provider.GetData(new SomeFileHandler(filePath), delimiter);
    data = provider.SortData("name", data);

    return data;
})
.WithName("GetDataByLastNameDescending");

app.MapPost("/putdata", (SomeData someData) =>
{
    char delimiter = '|';
    // let's pretend this is the existing data, since we don't need to persist
    var list = new List<SomeData>()
    {  
        new SomeData { LastName = "Szatkowski", FirstName = "Steve", Email = "steveszat@hotmail.com", FavoriteColor="Blue", DateOfBirth = new DateTime(2000, 12, 12) } // not my acutual DoB 
    };
    list.Add(someData);
    // replace the delimiter if necessary before saving it to file
    var listToString =
    from line in list
    select delimiter == ',' ? line.ToString() 
    : line.ToString().Replace(',', delimiter);

})
.WithName("PutSomeData");

app.Run();
