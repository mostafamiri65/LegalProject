using Legal.Application.DTOs.Common;

namespace Legal.Application.Services.Interfaces
{
    public interface ICommonService
    {
        Task<List<RegionsListDto>> GetAllRegions();
        Task<List<OstansListDto>> GetAllOstans();
        Task<List<ShahrestansListDto>> GetAllShahrestans();
        Task AddLog(AppLogDto log);
    }
}
