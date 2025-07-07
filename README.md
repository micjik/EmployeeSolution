Please install Scalar.AspNetCore to view the Api UI part
add the following to program.cs file
app.MapScalarApiReference(options =>
{
    options
    .WithTitle("Employee Demo Api")
    .WithTheme(ScalarTheme.Mars)
    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    
});
