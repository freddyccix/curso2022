using Aplicacion.Dominio.Comunes;
using Aplicacion.Persistencia;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacio.Integration.Tests.Comunes;

[CollectionDefinition(nameof(SliceFixture))]
public class SliceFixtureCollection : ICollectionFixture<SliceFixture>
{
}

public partial class SliceFixture
{
    public async Task<T> ExecuteScopeAsync<T>(Func<IServiceProvider, Task<T>> action)
    {
        using var scope = scopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetService<CursoContext>();

        //await dbContext.BeginTransactionAsync().ConfigureAwait(false);

        var result = await action(scope.ServiceProvider).ConfigureAwait(false);

        //await dbContext.CommitTransactionAsync().ConfigureAwait(false);

        return result;
    }

    public Task<T> ExecuteDbContextAsync<T>(Func<CursoContext, Task<T>> action)
    {
        return ExecuteScopeAsync(sp => action(sp.GetService<CursoContext>()));
    }

    public Task<T> ExecuteDbContextAsync<T>(Func<CursoContext, IMediator, Task<T>> action)
    {
        return ExecuteScopeAsync(sp => action(sp.GetService<CursoContext>(), sp.GetService<IMediator>()));
    }

    //==================================================

    public Task InsertAsync<T>(params T[] entities) where T : class, IEntity
    {
        return ExecuteDbContextAsync(db =>
        {
            foreach (var entity in entities) db.Set<T>().Add(entity);
            return db.SaveChangesAsync();
        });
    }

    public Task InsertAsync<T>(List<T> entities) where T : class
    {
        return ExecuteDbContextAsync(db =>
        {
            foreach (var entity in entities) db.Set<T>().Add(entity);
            return db.SaveChangesAsync();
        });
    }

    public Task InsertAsync<TEntity>(TEntity entity) where TEntity : class
    {
        return ExecuteDbContextAsync(db =>
        {
            db.Set<TEntity>().Add(entity);

            return db.SaveChangesAsync();
        });
    }

    public Task InsertAsync<TEntity, TEntity2>(TEntity entity, TEntity2 entity2)
        where TEntity : class
        where TEntity2 : class
    {
        return ExecuteDbContextAsync(db =>
        {
            db.Set<TEntity>().Add(entity);
            db.Set<TEntity2>().Add(entity2);

            return db.SaveChangesAsync();
        });
    }

    public Task InsertAsync<TEntity, TEntity2, TEntity3>(TEntity entity, TEntity2 entity2, TEntity3 entity3)
        where TEntity : class
        where TEntity2 : class
        where TEntity3 : class
    {
        return ExecuteDbContextAsync(db =>
        {
            db.Set<TEntity>().Add(entity);
            db.Set<TEntity2>().Add(entity2);
            db.Set<TEntity3>().Add(entity3);

            return db.SaveChangesAsync();
        });
    }

    public Task InsertAsync<TEntity, TEntity2, TEntity3, TEntity4>(TEntity entity, TEntity2 entity2,
        TEntity3 entity3, TEntity4 entity4)
        where TEntity : class
        where TEntity2 : class
        where TEntity3 : class
        where TEntity4 : class
    {
        return ExecuteDbContextAsync(db =>
        {
            db.Set<TEntity>().Add(entity);
            db.Set<TEntity2>().Add(entity2);
            db.Set<TEntity3>().Add(entity3);
            db.Set<TEntity4>().Add(entity4);

            return db.SaveChangesAsync();
        });
    }

    public Task InsertAsync<TEntity, TEntity2, TEntity3, TEntity4, TEntity5>(TEntity entity, TEntity2 entity2,
        TEntity3 entity3, TEntity4 entity4, TEntity5 entity5)
        where TEntity : class
        where TEntity2 : class
        where TEntity3 : class
        where TEntity4 : class
        where TEntity5 : class
    {
        return ExecuteDbContextAsync(db =>
        {
            db.Set<TEntity>().Add(entity);
            db.Set<TEntity2>().Add(entity2);
            db.Set<TEntity3>().Add(entity3);
            db.Set<TEntity4>().Add(entity4);
            db.Set<TEntity5>().Add(entity5);

            return db.SaveChangesAsync();
        });
    }

    public Task<T> FindAsync<T>(int id)
        where T : class, IEntity
    {
        return ExecuteDbContextAsync(db => db.Set<T>().SingleAsync(x => x.Id == id));
    }

    public Task<T> FindOrDefaultAsync<T>(int id)
        where T : class, IEntity
    {
        return ExecuteDbContextAsync(db => db.Set<T>().SingleOrDefaultAsync(x => x.Id == id));
    }

    public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        return ExecuteScopeAsync(sp =>
        {
            var mediator = sp.GetService<IMediator>();
            return mediator?.Send(request);
        });
    }

    public Task<TResult> MapReverseAsync<TFrom, TResult>(TFrom request)
        where TResult : class, IEntity, IAuditableEntity
    {
        return ExecuteScopeAsync(sp =>
        {
            var mapper = sp.GetService<IMapper>();
            return Task.FromResult(mapper?.Map<TResult>(request));
        });
    }

    public Task<TResult> MapAsync<TFrom, TResult>(TFrom request)
        where TFrom : class, IEntity, IAuditableEntity
    {
        return ExecuteScopeAsync(sp =>
        {
            var mapper = sp.GetService<IMapper>();
            return Task.FromResult(mapper!.Map<TResult>(request));
        });
    }

    public Task SendAsync(IRequest request)
    {
        return ExecuteScopeAsync(sp =>
        {
            var mediator = sp.GetService<IMediator>();
            return mediator.Send(request);
        });
    }

    public Task<CursoContext> Context()
    {
        return ExecuteScopeAsync(sp => Task.FromResult(sp.GetService<CursoContext>()));
    }
}