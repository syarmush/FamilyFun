using FamilyFun.Persistance;
using FamilyFun.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyFun.Web.Persistance
{
    public interface IMitzvahRepository
    {
        Task LogMitzvahPointsForDateAsync(int familyMemberId, int mitzvahId, DateTime mitzvahDate, int points);
        Task<IEnumerable<MitzvahOccurence>> RetrieveAllMitzvahOccurencesAsync(int familyMemberId, DateTime mitzvahDate);
        Task<IEnumerable<MitzvahOccurence>> RetrievePendingMitzvahOccurencesAsync(int familyMemberId);
        Task<IEnumerable<MitzvahOccurence>> RetrieveApprovedMitzvahOccurencesAsync(int familyMemberId);
        Task<bool> MemberHasMitzvahForDate(int familyMemberId, int mitzvahId, DateTime mitzvahDate);
        Task<MitzvahOccurence> RetrieveSinlgeMitzvahOccuranceAsync(string occuranceId);
        Task UpdateAsync(MitzvahOccurence mitzvahOccurence);
        Task DeleteSinlgeMitzvahOccuranceAsync(string id);
    }


    internal class MitzvahRepository : IMitzvahRepository
    {
        private readonly IAsyncRepository<MitzvahOccurence> _mitzvosRepository;

        public MitzvahRepository(IAsyncRepository<MitzvahOccurence> mitzvosRepository)
        {
            _mitzvosRepository = mitzvosRepository ?? throw new ArgumentNullException(nameof(mitzvosRepository));
        }

        public Task<IEnumerable<MitzvahOccurence>> RetrieveAllMitzvahOccurencesAsync(int familyMemberId, DateTime mitzvahDate)
        {
            return _mitzvosRepository.GetAllWhereAsync(m => m.FamilyMemberId == familyMemberId && m.OccuredOn.Date == mitzvahDate.Date);
        }

        public Task<IEnumerable<MitzvahOccurence>> RetrievePendingMitzvahOccurencesAsync(int familyMemberId)
        {
            return _mitzvosRepository.GetAllWhereAsync(m => m.FamilyMemberId == familyMemberId && m.ApproveOn == null);
        }

        public Task<IEnumerable<MitzvahOccurence>> RetrieveApprovedMitzvahOccurencesAsync(int familyMemberId)
        {
            return _mitzvosRepository.GetAllWhereAsync(m => m.FamilyMemberId == familyMemberId && m.ApproveOn != null);
        }

        public async Task LogMitzvahPointsForDateAsync(int familyMemberId, int mitzvahId, DateTime mitzvahDate, int points)
        {
            await _mitzvosRepository.InsertAsync(new MitzvahOccurence(mitzvahId, familyMemberId, points, mitzvahDate));
        }

        public async Task<bool> MemberHasMitzvahForDate(int familyMemberId, int mitzvahId, DateTime mitzvahDate)
        {
            return (await _mitzvosRepository
                .GetAllWhereAsync(m => m.FamilyMemberId == familyMemberId && m.MitzvahId == mitzvahId && m.OccuredOn.Date == mitzvahDate.Date))
                .Any();
               
        }

        public Task<MitzvahOccurence> RetrieveSinlgeMitzvahOccuranceAsync(string occuranceId)
        {
            return _mitzvosRepository.GetOneAsync(occuranceId);
        }

        public Task UpdateAsync(MitzvahOccurence mitzvahOccurence)
        {
            return _mitzvosRepository.UpdateAsync(mitzvahOccurence);
        }

        public Task DeleteSinlgeMitzvahOccuranceAsync(string occuranceId)
        {
            return _mitzvosRepository.DeleteAsync(occuranceId);
        }
    }
}