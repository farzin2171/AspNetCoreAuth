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
