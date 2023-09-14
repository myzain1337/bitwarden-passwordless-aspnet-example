using Microsoft.AspNetCore.Identity;
using Passwordless.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataContext();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<PasswordlessContext>()
    .AddPasswordless(builder.Configuration.GetSection("Passwordless"));

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Authorized");
});

var app = builder.Build();

app.MigrateDataContext();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapPasswordless(true);
app.MapRazorPages();
app.MapControllers();

app.Run();