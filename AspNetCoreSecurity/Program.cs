var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication("cookies")
    .AddCookie("cookies", o =>
   {
       o.Cookie.Name = "demo";
       o.ExpireTimeSpan = TimeSpan.FromHours(8);

       o.LoginPath = "/account/login";
       o.AccessDeniedPath = "/account/login";
   }).AddGoogle("google" , o =>
   {
       o.ClientId = "635672167628-qc09tqq0rhe4hlf431ivqp5g30ab1e4r.apps.googleusercontent.com";
       o.ClientSecret = "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";

       //o.CallbackPath = "/signin-google";
       o.SignInScheme = "cookies";
   });

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("ManageCustomers", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("department", "sales");
        policy.RequireClaim("status", "senior");
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages().RequireAuthorization();

app.Run();
