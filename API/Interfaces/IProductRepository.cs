using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        void Update(AppProduct product);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppProduct>> GetProductsAsync();
        Task<AppProduct> GetProductByIdAsync(int id);
        Task<AppProduct> GetProductByTitleAsync(String title);
        // Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
        // Task<MemberDto> GetMemberAsync(string username);
    }
}