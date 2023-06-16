using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductlineApp.Domain.Aggregates.User.Entities;
using ProductlineApp.Domain.Aggregates.User.Repository;
using ProductlineApp.Domain.Aggregates.User.ValueObjects;
using ProductlineApp.Infrastructure.Persistance.Entities.Platform;

namespace ProductlineApp.Infrastructure.Persistance.Repositories;

public class PlatformRepository : IPlatformRepository
{
    private readonly ProductlineDbContext _dbContext;
    private readonly IMapper _mapper;

    public PlatformRepository(
        ProductlineDbContext dbContext,
        IMapper mapper)
    {
        this._dbContext = dbContext;
        this._mapper = mapper;
    }

    public async Task<Platform> GetByIdAsync(PlatformId id)
    {
        var platformEntity = await this._dbContext.Platforms.FirstOrDefaultAsync(x => x.Id == id);
        return this._mapper.Map<Platform>(platformEntity);
    }

    public async Task<IEnumerable<Platform>> GetAllAsync()
    {
        var platformEntities = await this._dbContext.Platforms.ToListAsync();
        return this._mapper.Map<List<Platform>>(platformEntities);
    }

    public async Task AddAsync(Platform entity)
    {
        var platformEntity = this._mapper.Map<PlatformEntity>(entity);
        this._dbContext.Add(platformEntity);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Platform entity)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(Platform id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Platform>> GetAllByUserIdAsync(UserId userId)
    {
        throw new NotImplementedException();
    }

    public async Task<Platform> GetByNameAsync(string name)
    {
        var platformEntity = await this._dbContext.Platforms.FirstOrDefaultAsync(x => x.Name == name.ToLower());
        return this._mapper.Map<Platform>(platformEntity);
    }

    public async Task<PlatformId?> GetIdByNameAsync(string name)
    {
        return await this._dbContext.Platforms
            .Where(x => x.Name == name.ToLower())
            .Select(x => x.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<IDictionary<PlatformId, string>> GetPlatformNamesByIdsAsync(IEnumerable<PlatformId> platformIds)
    {
        return await this._dbContext.Platforms
            .Where(x => platformIds.Contains(x.Id))
            .ToDictionaryAsync(x => x.Id, x => x.Name);
    }
}
