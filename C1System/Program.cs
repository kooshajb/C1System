using System;
using C1System;
using C1System.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddDbContext<C1SystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("C1System"));
});

#region IOC
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddTransient<IPodcastRepository, PodcastRepository>();
builder.Services.AddTransient<ITechnologyRepository, TechnologyRepository>();
builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<IBlogCategoryRepository, BlogCategoryRepository>();
builder.Services.AddTransient<ITechnologyRepository, TechnologyRepository>();
builder.Services.AddTransient<INewsLetterRepository, NewsLetterRepository>();
builder.Services.AddTransient<ITagRepository, TagRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<ICustomerSuccessRepository, CustomerSuccessRepository>();
builder.Services.AddTransient<IConsultingRepository, ConsultingRepository>();
builder.Services.AddTransient<IUploadRepository, UploadRepository>();
builder.Services.AddTransient<IMediaRepository, MediaRepository>();
builder.Services.AddTransient<UploadRepository>();

#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseMvcWithDefaultRoute();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area:exists}/{controller=AdminDashboard}/{action=Index}/{id?}");

app.Run();