using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FudbalskiKlub.Model.Requests;

namespace FudbalskiKlub.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database1.Bolest, Model.Bolest>();
            CreateMap<BolestInsertRequest, Database1.Bolest>();
            CreateMap<BolestUpdateRequest, Database1.Bolest>();

            CreateMap<Database1.Clanarina, Model.Clanarina>();
            CreateMap<ClanarinaInsertRequest, Database1.Clanarina>();
            CreateMap<ClanarinaUpdateRequest, Database1.Clanarina>();

            CreateMap<Database1.Korisnik, Model.Korisnik>();
            CreateMap<KorisnikInsertRequest, Database1.Korisnik>();
            CreateMap<KorisnikUpdateRequest, Database1.Korisnik>();
            ////////////////////////////////////////////////////////////////////////////////////
            CreateMap<Database1.KorisnikBolest, Model.KorisnikBolest>();
            CreateMap<Database1.KorisnikPozicija, Model.KorisnikPozicija>();
            CreateMap<Database1.KorisnikTransakcijskiRacun, Model.KorisnikTransakcijskiRacun>();
            CreateMap<Database1.KorisnikUloga, Model.KorisnikUloga>();
            ////////////////////////////////////////////////////////////////////////////////////

            CreateMap<Database1.Platum, Model.Platum>();
            CreateMap<PlatumInsertRequest, Database1.Platum>();
            CreateMap<PlatumUpdateRequest, Database1.Platum>();

            CreateMap<Database1.Pozicija, Model.Pozicija>();
            CreateMap<PozicijaInsertRequest, Database1.Pozicija>();
            CreateMap<PozicijaUpdateRequest, Database1.Pozicija>();

            CreateMap<Database1.Stadion, Model.Stadion>();
            CreateMap<StadionInsertRequest, Database1.Stadion>();
            CreateMap<StadionUpdateRequest, Database1.Stadion>();

            CreateMap<Database1.Statistika, Model.Statistika>();
            CreateMap<StatistikaInsertRequest, Database1.Statistika>();
            CreateMap<StatistikaUpdateRequest, Database1.Statistika>();

            CreateMap<Database1.Termin, Model.Termin>();
            CreateMap<TerminInsertRequest, Database1.Termin>();
            CreateMap<TerminUpdateRequest, Database1.Termin>();

            CreateMap<Database1.TransakcijskiRacun, Model.TransakcijskiRacun>();
            CreateMap<TransakcijskiRacunInsertRequest, Database1.TransakcijskiRacun>();
            CreateMap<TransakcijskiRacunUpdateRequest, Database1.TransakcijskiRacun>();

            CreateMap<Database1.Trening, Model.Trening>();
            CreateMap<TreningInsertRequest, Database1.Trening>();
            CreateMap<TreningUpdateRequest, Database1.Trening>();
            ////////////////////////////////////////////////////////////////////////////////////
            CreateMap<Database1.TreningStadion, Model.TreningStadion>();
            ////////////////////////////////////////////////////////////////////////////////////
            CreateMap<Database1.Uloga, Model.Uloga>();
            CreateMap<UlogaInsertRequest, Database1.Uloga>();
            CreateMap<UlogaUpdateRequest, Database1.Uloga>();

        }
    }

    //public UserProfile()
    //{
    //    CreateMap<User, UserViewModel>();
    //}
}
