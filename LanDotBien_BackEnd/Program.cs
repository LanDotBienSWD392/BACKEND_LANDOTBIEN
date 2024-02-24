
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.Insfrastructure.Repository;
using LanVar.Service.AutoMapperProfile;
using LanVar.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var serverVersion = new MySqlServerVersion(new Version(8, 0, 23)); // Replace with your actual MySQL server version
builder.Services.AddDbContext<MyDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MyDB");
    options.UseMySql(connectionString, serverVersion, options => options.MigrationsAssembly("LanDotBien_BackEnd"));
}
);

builder.Services.AddTransient<IAuctionRepository, AuctionRepository>();
builder.Services.AddTransient<IBidRepository, BidRepository>();
builder.Services.AddTransient<IBillRepository, BillRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddTransient<IPackageRepository, PackageRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IRoomRegistrationsRepository, RoomRegistrationsRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserPermissionRepository, UserPermissionRepository>();

builder.Services.AddTransient<UserService>();
//sau class service cuar ai tu add vao day

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});


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

app.UseAuthorization();

app.MapControllers();

app.Run();
