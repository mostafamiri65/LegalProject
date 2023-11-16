using Legal.Application.DTOs.Common;
using Legal.Application.DTOs.Parvandeh;
using Legal.Application.Services.Interfaces;
using Legal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace Legal.Application.Services.Implementations
{
    public class DocService : IDocService
    {
        private readonly LowDbContext _context;
        public DocService(LowDbContext context)
        {
            _context = context;
        }

        public async Task<List<DadgaheMarjaDto>> GetAllDadgahList(int parvandeId)
        {
            List<DadgaheMarjaDto> list = new List<DadgaheMarjaDto>();
            var marjas = await _context.TbNoyehParvandehMarjas
                .Include(s => s.NoyehParvandehCodeNavigation).Where(m =>
            m.NoyehParvandehCode == parvandeId).ToListAsync();
            foreach (var item in marjas)
            {
                DadgaheMarjaDto dto = new DadgaheMarjaDto()
                {
                    Id = item.Id,
                    Lev = item.Lev,
                    Titel = item.Titel,
                    NoyehParvandehTitle = item.NoyehParvandehCodeNavigation.Title
                };
                list.Add(dto);
            }
            return list;
        }

        public async Task<List<ParvandeDto>> GetAllParvandeList(long userId)
        {
            var userRole = await _context.TbUserRoles.SingleAsync(r => r.UserId == userId);
            var role = await _context.TbRoles.SingleAsync(r => r.Id == userRole.RoleId);
            List<ParvandeDto> list = new List<ParvandeDto>();
            var parvandehs = await _context.TbParvandehs.ToListAsync();
            List<TbParvandeh> parvandeList = new List<TbParvandeh>();
            var user = await _context.TbUsers.SingleAsync(u => u.Id == userId);
            if (role.IsHeadquarters || role.HasDeveloperAccess)
                parvandeList = parvandehs;
            else if (!role.IsHeadquarters && role.HasOstanAccess)
            {
                var shahrestans = await _context.TbShahrestans
                    .Where(r => r.OstanId == user.OstanId).ToListAsync();
                foreach (var shahr in shahrestans)
                {
                    foreach (var p in parvandehs)
                    {
                        if (shahr.Id == p.ShahrestanId)
                            parvandeList.Add(p);
                    }
                }

            }
            else
            {
                parvandeList = parvandehs.Where(r => r.ShahrestanId == user.ShahrestanId).ToList();
            }


            foreach (var item in parvandeList)
            {
                ParvandeDto dto = new ParvandeDto()
                {
                    Id = item.Id,
                    ParvandehId = item.ParvandehId,
                    DateIjad = item.DateIjad,
                    DateRay = item.DateRay,
                    EjraDate = item.EjraDate,
                    EjraIs = item.EjraIs,
                    HagVekalat = item.HagVekalat,
                    HazinehDadresi = item.HazinehDadresi,
                    Jaryan = item.Jaryan,
                    Khahan = item.Khahan,
                    Khasteh = item.Khasteh,
                    Lah = item.Lah,
                    MakhtoomeDalil = item.MakhtoomeDalil,
                    MakhtoomeDate = item.MakhtoomeDate,
                    MakhtoomeIs = item.MakhtoomeIs,
                    Maly = item.Maly,
                    MarjaName = item.MarjaName,
                    NoyehParvandehCode = item.NoyehParvandehCode,
                    RakedDalil = item.RakedDalil,
                    RakedDate = item.RakedDate,
                    RakedIs = item.RakedIs,
                    RayTajdidDate = item.RayTajdidDate,
                    RayTajdidOk = item.RayTajdidOk,
                    Search1 = item.Search1,
                    Search2 = item.Search2,
                    ShahrestanId = item.ShahrestanId,
                    ShParvandeh = item.ShParvandeh,
                    ShParvandeh24 = item.ShParvandeh24,
                    ShShobeh = item.ShShobeh,
                    TajdidDate = item.TajdidDate,
                    TajdidHagVekalat = item.TajdidHagVekalat,
                    TajdidHazinehDadresi = item.TajdidHazinehDadresi,
                    TajdidIs = item.TajdidIs,
                    TajdidKhahan = item.TajdidKhahan
                };
                list.Add(dto);
            }
            return list;
        }

        public async Task<List<OstansListDto>> GetOstansByUserId(long userId)
        {
            List<OstansListDto> list = new List<OstansListDto>();
            var userRole = await _context.TbUserRoles.SingleAsync(r => r.UserId == userId);
            var role = await _context.TbRoles.SingleAsync(r => r.Id == userRole.RoleId);
            var user = await _context.TbUsers.SingleAsync(u => u.Id == userId);
            if (role.HasDeveloperAccess || role.IsHeadquarters)
            {
                var ostans = await _context.TbOstans.ToListAsync();
                foreach (var ostan in ostans)
                {
                    OstansListDto dto = new OstansListDto()
                    {
                        Id = ostan.Id,
                        Title = ostan.Title,
                        RegionId = ostan.RegionId
                    };
                    list.Add(dto);
                }
            }
            else
            {
                var ostans = await _context.TbOstans
                    .Where(r => r.Id == user.OstanId).ToListAsync();
                foreach (var ostan in ostans)
                {
                    OstansListDto dto = new OstansListDto()
                    {
                        Id = ostan.Id,
                        Title = ostan.Title,
                        RegionId = ostan.RegionId
                    };
                    list.Add(dto);
                }
            }

            return list;
        }

        public async Task<List<ShahrestansListDto>> GetAllShahrestansByOstanId(int ostanId, long userId)
        {
            var user = await _context.TbUsers.SingleAsync(r => r.Id == userId);
            var userRole = await _context.TbUserRoles.SingleAsync(u => u.UserId == userId);
            var role = await _context.TbRoles.SingleAsync(r => r.Id == userRole.RoleId);

            var list = new List<ShahrestansListDto>();

            if (role is
                {
                    HasDeveloperAccess: false, HasOstanAccess: false,
                    HasRegionAccess: false, IsHeadquarters: false, IsOrganization: false
                })
            {
                var shahr = await _context.TbShahrestans
                    .SingleAsync(r => r.Id == user.ShahrestanId);
                ShahrestansListDto dto = new ShahrestansListDto()
                {
                    Id = shahr.Id,
                    OstanId = ostanId,
                    Title = shahr.Title
                };
                list.Add(dto);

            }
            else
            {
                var shahrs = await _context.TbShahrestans.
                    Where(r => r.OstanId == ostanId).ToListAsync();
                foreach (var shahr in shahrs)
                {
                    ShahrestansListDto dto = new ShahrestansListDto()
                    {
                        Id = shahr.Id,
                        OstanId = ostanId,
                        Title = shahr.Title
                    };
                    list.Add(dto);
                }
            }

            return list;

        }

        public async Task<List<MarjaListDto>> GetAllMarjaList(int noeId)
        {
            var marjas = await _context.TbNoyehParvandehMarjas
                .Where(m => m.NoyehParvandehCode == noeId).ToListAsync();
            List<MarjaListDto> list = new List<MarjaListDto>();
            foreach (var marja in marjas)
            {
                MarjaListDto dto = new MarjaListDto()
                {
                    Id = marja.Id,
                    Lev = marja.Lev,
                    NoeId = marja.NoyehParvandehCode,
                    Title = marja.Titel
                };
                list.Add(dto);
            }
            return list;
        }

        public async Task ChangeParvandeNoe(int parvandeId, int noeId)
        {
            var parvande = await _context.TbParvandehs.SingleAsync(p => p.Id == parvandeId);
            parvande.NoyehParvandehCode = (byte)noeId;
            _context.TbParvandehs.Update(parvande);
            await _context.SaveChangesAsync();
        }

        public async Task<CreateParvandeDto> GetParvandeForCreating(int parvandeId)
        {
            var parvande = await _context.TbParvandehs.SingleAsync(p => p.Id == parvandeId);
            var shahr = await _context.TbShahrestans.SingleOrDefaultAsync(sh => sh.Id == parvande.ShahrestanId);
            CreateParvandeDto dto = new CreateParvandeDto()
            {
                Id = parvande.Id,
                NoyehParvandehCode = parvande.NoyehParvandehCode,
                OstanId = shahr.OstanId,
                ShahrestanId = parvande.ShahrestanId,
                Maly = parvande.Maly,
                ShShobeh = parvande.ShShobeh,
                ShParvandeh24 = parvande.ShParvandeh24,
                ShParvandeh = parvande.ShParvandeh,
                Search2 = parvande.Search2,
                Search1 = parvande.Search1,
                DateIjad = parvande.DateIjad,
                DateRay = parvande.DateRay,
                HagVekalat = parvande.HagVekalat,
                HazinehDadresi = parvande.HazinehDadresi,
                Jaryan = parvande.Jaryan,
                Khahan = parvande.Khahan,
                Khasteh = parvande.Khasteh,
                Lah = parvande.Lah,
                MarjaName = parvande.MarjaName
                
            };
            //TODO: set marjId & MogId
            return dto;
        }

        public async Task ChangeMarjaeParvande(int parvandeId, int marjId)
        {
            var parvande = await _context.TbParvandehs.SingleAsync(p => p.Id == parvandeId);
            var marjae = await _context.TbNoyehParvandehMarjas.SingleAsync(m =>
                m.Id == marjId);
            parvande.MarjaName = marjae.Titel;
            _context.TbParvandehs.Update(parvande);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeShahrestan(int parvandeId, int shahrestanId)
        {
            var parvande = await _context.TbParvandehs.SingleAsync(p => p.Id == parvandeId);
            parvande.ShahrestanId = shahrestanId;
            _context.TbParvandehs.Update(parvande);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeShomare24Parvande(int parvandeId, string shomare)
        {
            var parvande = await _context.TbParvandehs.SingleAsync(p => p.Id == parvandeId);
            parvande.ShParvandeh24 = shomare;
            _context.TbParvandehs.Update(parvande);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeShobeParvande(int parvandeId, string shobe)
        {
            var parvande = await _context.TbParvandehs.SingleAsync(p => p.Id == parvandeId);
            parvande.ShShobeh = Convert.ToInt32(shobe);
            _context.TbParvandehs.Update(parvande);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeDateIjad(int parvandeId, string date)
        {
            var parvande = await _context.TbParvandehs.SingleAsync(p => p.Id == parvandeId);
            parvande.DateIjad = date;
            _context.TbParvandehs.Update(parvande);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CreateParvande(int noe, int marj, int shahr, string sh24, string shShobe, string shP, int mog, string date)
        {
            var marja =await _context.TbNoyehParvandehMarjas.SingleAsync(m =>
                m.Id == marj);
            TbParvandeh parvande = new TbParvandeh()
            {
                NoyehParvandehCode = (byte?)noe,
                ShahrestanId = shahr,
                DateIjad = date,
                ShShobeh = Convert.ToInt32(shShobe),
                ShParvandeh24 = sh24,
                ShParvandeh = shP,
                MarjaName = marja.Titel
            };
            if (parvande.DateIjad != null)
            {
                await _context.TbParvandehs.AddAsync(parvande);
                await _context.SaveChangesAsync();
            }
          
            return parvande.Id;
        }

        public async Task<List<KhahaneParvandeDto>> CreateKhahan(CreateShakhsDto create, long userId)
        {
            TbAshkha shakhs = new TbAshkha()
            {
                Address = create.Address,
                CodeMeli = create.CodeMeli,
                CodePosti = create.CodePosti,
                DateTavalod = create.DateTavalod,
                Email = create.Email,
                Faks = create.Faks,
                Jens = create.Jens,
                LastName = create.LastName,
                Mobile = create.Mobile,
                Name = create.Name,
                NamePedar = create.NamePedar,
                Pisheh = create.Pisheh,
                Semat = create.Semat,
                Site = create.Site,
                Tel = create.Tel,
                NoehAshkhasCode = create.NoehAshkhasCode,
                UpUserId = Convert.ToInt32(userId)
            };
            await _context.TbAshkhas.AddAsync(shakhs);
            await _context.SaveChangesAsync();
            TbTarafeyn tarafeyn = new TbTarafeyn()
            {
                UpUserId = Convert.ToInt32(userId),
                AshkhasId = shakhs.Id,
                Khahan = 1,
                ParvandehId = create.ParvandeId
            };
            await _context.TbTarafeyns.AddAsync(tarafeyn);
            await _context.SaveChangesAsync();
            List<KhahaneParvandeDto> list = new List<KhahaneParvandeDto>();
            var khahan = await _context.TbTarafeyns.Where(t => t.ParvandehId == create.ParvandeId
                                                               && t.Khahan == 1).ToListAsync();
            foreach (var item in khahan)
            {
                KhahaneParvandeDto dto = new KhahaneParvandeDto()
                {
                    ParvandeId = Convert.ToInt32(item.ParvandehId),
                    Name = shakhs.Name,
                    Lastname = shakhs.LastName,
                    Mobile = shakhs.Mobile,
                    CodeMeli = shakhs.CodeMeli,
                    TarafainId = tarafeyn.Id
                };
                list.Add(dto);
            }
            return list;
        }

        public async Task<List<NoeParvandehDto>> GetAnvaeParvande()
        {
            List<NoeParvandehDto> list = new List<NoeParvandehDto>();
            var anvae = await _context.TbNoyehParvandehs.ToListAsync();
            foreach (var noe in anvae)
            {
                NoeParvandehDto dto = new NoeParvandehDto()
                {
                    Id = noe.Code,
                    Title = noe.Title,
                    KhahanBadvi = noe.KhahanBadvi,
                    KhandehBadvi = noe.KandehBadvi,
                    KhahanTajdid = noe.KhahanTajdid,
                    KhandehTajdid = noe.KhandehTajdid
                };
                list.Add(dto);
            }
            return list;
        }

        public async Task<List<MojtamaeParvandeDto>> GetMojtamahayeParvande(int shahrestanId)
        {
            var majtames = await _context.TbNoyehParvandehMogs.Include(d => d.Shahrestan)
                .Where(m => m.ShahrestanId == shahrestanId).ToListAsync();
            List<MojtamaeParvandeDto> list = new List<MojtamaeParvandeDto>();
            foreach (var majtama in majtames)
            {
                MojtamaeParvandeDto dto = new MojtamaeParvandeDto()
                {
                    Id = majtama.Id,
                    Title = majtama.Title,
                    ShahrestanTitle = majtama.Shahrestan.Title
                };
                list.Add(dto);
            }
            return list;
        }
    }
}
