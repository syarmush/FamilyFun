using FamilyFun.Persistance;
using FamilyFun.Persistence.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyFun.Web.Persistance
{
    public interface IMitzvahRepository
    {
        Task LogMitzvahAsync(int mitzvahId, int familyMemberId, int points);
        Task<IEnumerable<MitzvahOccurence>> RetriveMitzvosAsync(int familyMemberId);
    }


    internal class MitzvahRepository : IMitzvahRepository
    {
        private readonly IAsyncRepository<MitzvahOccurence> _mitzvosRepository;

        public MitzvahRepository(IAsyncRepository<MitzvahOccurence> mitzvosRepository)
        {
            _mitzvosRepository = mitzvosRepository ?? throw new ArgumentNullException(nameof(mitzvosRepository));
        }

        public async Task LogMitzvahAsync(int mitzvahId, int familyMemberId, int points)
        {
            await _mitzvosRepository.InsertAsync(new MitzvahOccurence(mitzvahId, familyMemberId, points, DateTime.Now));
        }

        public Task<IEnumerable<MitzvahOccurence>> RetriveMitzvosAsync(int familyMemberId)
        {
            return _mitzvosRepository.GetAllWhereAsync(m => m.FamilyMemberId == familyMemberId);
        }
    }
}