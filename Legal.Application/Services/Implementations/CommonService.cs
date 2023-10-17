using Legal.Application.DTOs.Common;
using Legal.Application.Services.Interfaces;
using Legal.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Legal.Application.Services.Implementations
{
    public class CommonService : ICommonService
    {
        private LowDbContext _context;
        public CommonService(LowDbContext context)
        {
            _context = context;
        }

        public async Task AddLog(AppLogDto log)
        {
            ApplicationLog app = new ApplicationLog()
            {
                DoingDate = DateTime.Now,
                DoingDescription = log.DoingDescription,
                UserId = log.UserId,
                TableName = log.TableName
            };
            await _context.ApplicationLogs.AddAsync(app);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OstansListDto>> GetAllOstans()
        {
            var ostans = await _context.TbOstans.ToListAsync();
            List<OstansListDto> list = new List<OstansListDto>();
            foreach (var o in ostans)
            {
                OstansListDto dto = new OstansListDto()
                {
                    Id = o.Id,
                    Title = o.Title,
                    RegionId = o.RegionId
                };
                list.Add(dto);
            }
            return list;
        }

        public async Task<List<RegionsListDto>> GetAllRegions()
        {
            var regions = await _context.TbRegions.ToListAsync();
            List<RegionsListDto> list = new List<RegionsListDto>();
            foreach (var region in regions)
            {
                RegionsListDto dto = new RegionsListDto()
                {
                    Id = region.Id,
                    Title = region.Name + " " + region.Last
                };
                list.Add(dto);
            }
            return list;
        }

        public async Task<List<ShahrestansListDto>> GetAllShahrestans()
        {
            var shahrestans = await _context.TbShahrestans.ToListAsync();
            List<ShahrestansListDto> list = new List<ShahrestansListDto>();
            foreach (var shahr in shahrestans)
            {
                ShahrestansListDto dto = new ShahrestansListDto()
                {
                    Id = shahr.Id,
                    Title = shahr.Title,
                    OstanId = shahr.OstanId
                };
                list.Add(dto);
            }
            return list;
        }
    }
}
