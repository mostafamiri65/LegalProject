using Legal.Application.DTOs.Common;
using Legal.Application.DTOs.Parvandeh;

namespace Legal.Application.Services.Interfaces
{
    public interface IDocService
    {
        Task<List<NoeParvandehDto>> GetAnvaeParvande();
        Task<List<MojtamaeParvandeDto>> GetMojtamahayeParvande(int shahrestanId);
        Task<List<DadgaheMarjaDto>> GetAllDadgahList(int parvandeId);
        Task<List<ParvandeDto>> GetAllParvandeList(long userId);
        Task<List<OstansListDto>> GetOstansByUserId(long userId);
        Task<List<ShahrestansListDto>> GetAllShahrestansByOstanId(int ostanId,long userId);
        Task<List<MarjaListDto>> GetAllMarjaList(int noeId);
        Task ChangeParvandeNoe(int parvandeId, int noeId);
        Task<CreateParvandeDto> GetParvandeForCreating(int parvandeId);
        Task ChangeMarjaeParvande(int parvandeId, int marjId);
        Task ChangeShahrestan(int parvandeId,int shahrestanId);
        Task ChangeShomare24Parvande(int parvandeId, string shomare);
        Task ChangeShobeParvande(int parvandeId,string shobe);
        Task ChangeDateIjad(int parvandeId, string date);
        Task<int> CreateParvande(int noe, int marj, int shahr, string sh24, string shShobe, 
            string shP, int mog, string date);

        Task<List<KhahaneParvandeDto>> CreateKhahan(CreateShakhsDto create, long userId);

    }
}
