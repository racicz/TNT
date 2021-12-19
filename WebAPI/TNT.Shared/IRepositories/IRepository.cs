using Microsoft.AspNetCore.Mvc;
using TNT.Shared.Messages;

namespace TNT.Shared.IRepositories
{
    public interface IRepository<TEntity, TEntityResp>
    {
        public Task<RepositoryResponse<TEntityResp>> CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResponse<TEntityResp>> DeleteAsync(int id, int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResponse<TEntityResp>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResponse<TEntityResp>> GetAsync([FromQuery] TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResponse<TEntityResp>> PatchAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<RepositoryResponse<TEntityResp>> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
