﻿using BookLib;

namespace BookApi;

public class InitService : IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public InitService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        var service = _serviceScopeFactory.CreateScope()
                                          .ServiceProvider
                                          .GetRequiredService<BookService>();
        service.Initialize();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
