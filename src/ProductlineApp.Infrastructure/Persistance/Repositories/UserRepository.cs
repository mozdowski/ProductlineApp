using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductlineApp.Application.Security;
using ProductlineApp.Domain.Aggregates.User;
using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;

namespace ProductlineApp.Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ProductlineDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public UserRepository(
        ProductlineDbContext dbContext,
        IMapper mapper,
        IPasswordHasher passwordHasher)
    {
        this._dbContext = dbContext;
        this._mapper = mapper;
        this._passwordHasher = passwordHasher;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await this._dbContext.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
        return user;
    }

    public async Task<User?> GetUserByIdAsync(UserId userId)
    {
        var user = await this._dbContext.Users.FindAsync(userId);
        return user;
    }

    public async Task<bool> IsUserExistingAsync(string email)
    {
        return await this._dbContext.Users.AnyAsync(x => x.Email.Equals(email));
    }

    public async Task<bool> IsUserExistingAsync(UserId userId)
    {
        return await this._dbContext.Users.AnyAsync(x => x.Id == userId);
    }

    public async Task AddAsync(User user)
    {
        this._dbContext.Users.Add(user);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        if (this._dbContext.Entry(user).State is EntityState.Detached)
        {
            throw new Exception("User not attached to the context");
        }

        await this._dbContext.SaveChangesAsync();
    }

    public async Task AddPlatformConnection(User user, PlatformConnection platformConnection)
    {
        throw new NotImplementedException();
    }

    public async Task AddPlatformConnection(Guid userId, PlatformConnection platformConnection)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PlatformConnection>> GetUserPlatformConnectionsAsync(UserId userId)
    {
        var user = await this._dbContext.Users
            .Include(x => x.PlatformConnections)
            .FirstOrDefaultAsync(x => x.Id == userId);

        return user.PlatformConnections;
    }

    public async Task<string> GetUserPlatformToken(UserId userId, PlatformId platformId)
    {
        throw new NotImplementedException();
    }

    public async Task<(User? User, string? Salt)> GetByEmailWithSaltAsync(string email)
    {
        var user = await this._dbContext.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
        return (user, user?.Salt);
    }

    public async Task<(User? User, string? Salt)> GetByIdWithSaltAsync(UserId id)
    {
        var user = await this._dbContext.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
        return (user, user?.Salt);
    }

    public async Task<IEnumerable<PlatformConnection>> GetAllPlatformConnectionsAsync()
    {
        return await this._dbContext.Users
            .SelectMany(x => x.PlatformConnections)
            .ToListAsync();
    }

    public async Task<IEnumerable<User>> GetUsersBatchAsync(int pageNumber, int pageSize)
    {
        return await this._dbContext.Users
            .OrderBy(u => u.Id)
            .Skip(pageNumber * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
