using NewChatApp.Application.Services.ChatMessages;
using NewChatApp.Application.Services.Chats;
using NewChatApp.Application.Services.Users;
using NewChatApp.Core.Abstractions;
using NewChatApp.Storage;
using NewChatApp.Storage.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<SqlConnectionFactory>();
builder.Services.AddScoped<IUnitOfWork, DapperUnitOfWork>();

builder.Services.AddScoped<ChatsService>();
builder.Services.AddScoped<ChatMessagesService>();

/*builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IChatsRepository, ChatsRepository>();
builder.Services.AddScoped<IChatMessagesRepository, ChatMessagesRepository>();

builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<ChatsService>();
builder.Services.AddScoped<ChatMessagesService>();*/

builder.Services.Scan(scan => scan
    .FromAssemblyOf<UsersRepository>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
    .AsImplementedInterfaces()
    .WithScopedLifetime()
    .FromAssemblyOf<UsersService>()
    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
    .AsSelf()
    .WithScopedLifetime());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();