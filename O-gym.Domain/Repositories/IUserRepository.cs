using O_gym.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace O_gym.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid userId, CancellationToken cancellationToken);
        Task Update(User user, CancellationToken cancellationToken);
    }
}
