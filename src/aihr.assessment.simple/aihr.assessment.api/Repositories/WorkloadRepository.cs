using aihr.assessment.api.Courses.Api.DbContexts;
using aihr.assessment.api.Courses.Api.Repositories.Interface;
using aihr.assessment.api.Models.Dto;
using AutoMapper;
using aihr.assessment.api.Models;
using Microsoft.EntityFrameworkCore;

namespace aihr.assessment.api.Repositories
{
    public class WorkloadRepository : IWorkloadRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public WorkloadRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<WorkloadDto>> CreateUpdateWorkload(List<WorkloadDto> workloadDto)
        {
            var workload = _mapper.Map<List<WorkloadDto>, List<Workload>>(workloadDto);
            _db.Workload.AddRange(workload);
                      await _db.SaveChangesAsync();
            return _mapper.Map<List<Workload>, List<WorkloadDto>>(workload);
        }

        public async Task<bool> DeleteWorkload(int workloadId)
        {
            try
            {
                var workload = await _db.Workload.FirstOrDefaultAsync(u => u.Id == workloadId);
                if (workload == null)
                {
                    return false;
                }
                _db.Workload.Remove(workload);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<WorkloadDto>> GetWorkloadByStudentId(int studentId)
        {
            var workload = await _db.Workload.Where(x => x.StudentId == studentId).ToListAsync();
            return _mapper.Map<List<WorkloadDto>>(workload);
        }

        public async Task<IEnumerable<WorkloadDto>> GetWorkloadHistory()
        {
            List<Workload> workloadList = await _db.Workload.ToListAsync();
            return _mapper.Map<List<WorkloadDto>>(workloadList);
        }
    }
}
