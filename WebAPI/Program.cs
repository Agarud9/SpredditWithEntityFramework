using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicIntrefaces;
using FileData;
using FileData.DAOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<FileContext>();

builder.Services.AddScoped<IUserDao,UserDaoImpl>();
builder.Services.AddScoped<IUserLogic,UserLogic>();

builder.Services.AddScoped<IPostDao, PostDaoImpl>();
builder.Services.AddScoped<IPostLogic, PostLogic>();

builder.Services.AddScoped<ICommentDao, CommentDaoImpl>();
builder.Services.AddScoped<ICommentLogic,CommentLogic>();

builder.Services.AddScoped<IVoteDao, VoteDao>();
builder.Services.AddScoped<IVoteLogic,VoteLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true)
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();