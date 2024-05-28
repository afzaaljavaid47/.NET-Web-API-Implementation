using Microsoft.EntityFrameworkCore;
using Web.API.Models;
using Web.API.WebAPI.DB;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LiveConnection")));
List<string> urls = new List<string>();
var dbContext=builder.Services.BuildServiceProvider().GetService<ApplicationDBContext>();
if(dbContext!=null)
{
    
    List<ApiAccessModel> apiList= new List<ApiAccessModel>();
    apiList= dbContext.ApiAccess.Where(x=>x.isActive=="true").ToList();
    if(apiList.Count>0)
    {
        apiList.ForEach(item =>
        {
            urls.Add(item.url);
        });
    }
}
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecific", builder =>
           builder.WithOrigins(urls.ToArray())
                  .AllowAnyMethod()
                  .AllowAnyHeader());
});
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowSpecific");

app.MapControllers();

app.Run();