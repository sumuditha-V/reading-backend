var builder = WebApplication.CreateBuilder(args);

const string corsPolicy = "FrontendPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors(corsPolicy);

// In-memory demo data (good enough for the lab; no database required).
var readingItems = new[]
{
    new ReadingItem(1, "The Pragmatic Programmer", false),
    new ReadingItem(2, "Clean Code", false),
    new ReadingItem(3, "Designing Data-Intensive Applications", true)
};

app.MapGet("/api/reading", () => Results.Ok(readingItems));

app.Run();

record ReadingItem(int Id, string Title, bool IsRead);
