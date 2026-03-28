using DLL.Repositoy;

namespace Cat.HostedServices
{
    public class CatHostedServices : BackgroundService, IHostedService
    {
            private readonly IServiceScopeFactory _scopeFactory;
            private readonly ILogger<CatHostedServices> _logger;

            public CatHostedServices(
                IServiceScopeFactory scopeFactory,
                ILogger<CatHostedServices> logger)
            {
                _scopeFactory = scopeFactory;
                _logger = logger;
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    using var scope = _scopeFactory.CreateScope();
                    var repository = scope.ServiceProvider.GetRequiredService<CatRepository>();

                    var cats = await repository.GetAll(int.MaxValue, 0);

                    if (cats.Any())
                    {
                        var random = new Random();
                        var randomCat = cats[random.Next(cats.Count)];

                        _logger.LogInformation("Випадковий кіт: {Name} (Id: {Id})",
                            randomCat.Name,
                            randomCat.Id);
                    }
                    else
                    {
                        _logger.LogInformation("У базі ще немає котів 🐾");
                    }

                    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                }
            }
        }
    }
