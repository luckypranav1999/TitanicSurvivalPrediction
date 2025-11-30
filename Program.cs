var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddRouting();

var app = builder.Build();

app.UseRouting();
app.UseCors("AllowAll");

app.MapPost("/api/predict", async (HttpContext context) =>
{
    var passenger = await context.Request.ReadFromJsonAsync<PassengerInput>();

    var psi = new System.Diagnostics.ProcessStartInfo
    {
        FileName = "python",
        Arguments = $"predict.py {passenger.Pclass} {passenger.Sex} {passenger.Age} {passenger.SibSp} {passenger.Parch} {passenger.Fare} {passenger.Embarked}",
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false,
        CreateNoWindow = true
    };

    var process = System.Diagnostics.Process.Start(psi);
    string output = process.StandardOutput.ReadToEnd();
    string error = process.StandardError.ReadToEnd();
    process.WaitForExit();

    if (!string.IsNullOrWhiteSpace(error))
    {
        Console.WriteLine("PYTHON ERROR: " + error);
        return Results.Json(new { error });
    }

    return Results.Content(output, "application/json");
});

app.Run();

public class PassengerInput
{
    public int Pclass { get; set; }
    public string Sex { get; set; } = "";
    public float Age { get; set; }
    public int SibSp { get; set; }
    public int Parch { get; set; }
    public float Fare { get; set; }
    public string Embarked { get; set; } = "";
}
