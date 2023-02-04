using AutoMapper;
using DtoLayer.DTOs.AnnouncementDTOs;
using DtoLayer.DTOs.ApUserDTOs;
using EntityLayer.Concreate;

namespace TraverselCore.Mapping.AutoMapperProfile
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();// burada şunu demiş oluyoruz. AnnouncementAddDTO Announcement entitisinden beslenecek demek istiyoruz. 
            CreateMap<Announcement, AnnouncementAddDTO>().ReverseMap();// bu tersi de doğrudur diyoruz.
                                                                       // 
            CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();
            CreateMap<Announcement, AnnouncementListDTO>().ReverseMap();

            CreateMap<AnnouncementUpdateDto, Announcement>().ReverseMap();
            CreateMap<Announcement, AnnouncementUpdateDto>().ReverseMap();

            CreateMap<AppUserLoginAddDTO, AppUser>().ReverseMap();
            CreateMap<AppUser, AppUserLoginAddDTO>().ReverseMap();

            CreateMap<AppUserRegisterAddDTO, AppUser>().ReverseMap();
            CreateMap<AppUser, AppUserRegisterAddDTO>().ReverseMap();

           



        }
    }
}
