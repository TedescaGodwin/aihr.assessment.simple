using aihr.assessment.api.Models.Dto;

namespace aihr.assessment.api.Courses.Api.Repositories.Interface
{
    public interface IWorkloadRepository
    {
        Task<IEnumerable<WorkloadDto>> GetWorkloadHistory();
        Task<List<WorkloadDto>> GetWorkloadByStudentId(int studentId);
        Task<List<WorkloadDto>> CreateUpdateWorkload(List<WorkloadDto> workloadDto);
        Task<bool> DeleteWorkload(int workloadId);
    }
}
