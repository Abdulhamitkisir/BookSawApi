using BookSawApi.DataAccessLayer.Context;
using BookSawApi.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookSawContext>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<BookSawContext>();


builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();

var app = builder.Build();

//This is for apply error page 
app.UseStatusCodePages(async x =>
{
    if (x.HttpContext.Response.StatusCode==404)
    {
        x.HttpContext.Response.Redirect("/ErrorPage/ErrorPage404");
    }
}
);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

	endpoints.MapDefaultControllerRoute();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
