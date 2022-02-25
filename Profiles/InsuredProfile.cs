using AutoMapper;
using GridironInsuranceAPI.Dtos;
using GridironInsuranceAPI.Models;

namespace GridironInsuranceAPI.Profiles
{
    public class InsuredProfile : Profile
    {
        public InsuredProfile()
        {
            // source -> target
            CreateMap<Insured, InsuredReadDto>()
            .ForMember(d => d.Id, opt => { opt.MapFrom(s => s.Id); })
            .ForMember(d => d.FirstName, opt => { opt.MapFrom(s => s.FirstName); })
            .ForMember(d => d.LastName, opt => { opt.MapFrom(s => s.LastName); })
            .ForMember(d => d.Street, opt => { opt.MapFrom(s => s.Address.Street); })
            .ForMember(d => d.City, opt => { opt.MapFrom(s => s.Address.City); })
            .ForMember(d => d.ZipCode, opt => { opt.MapFrom(s => s.Address.ZipCode); })
            .ForMember(d => d.State, opt => { opt.MapFrom(s => s.Address.State); })
            .ForMember(d => d.InsuredValueAmount, opt => { opt.MapFrom(s => s.Rate.InsuredValueAmount); });


            CreateMap<InsuredCreateDto, Insured>()
            .ForMember(d => d.FirstName, opt => { opt.MapFrom(s => s.FirstName); })
            .ForMember(d => d.LastName, opt => { opt.MapFrom(s => s.LastName); })
            .ForPath(d => d.Address.Street, opt => { opt.MapFrom(s => s.Street); })
            .ForPath(d => d.Address.City, opt => { opt.MapFrom(s => s.City); })
            .ForPath(d => d.Address.ZipCode, opt => { opt.MapFrom(s => s.ZipCode); })
            .ForPath(d => d.Address.State, opt => { opt.MapFrom(s => s.State); })
            .ForPath(d => d.Rate.InsuredValueAmount, opt => { opt.MapFrom(s => s.InsuredValueAmount); });

            CreateMap<InsuredUpdateDto, Insured>()
            .ForMember(d => d.FirstName, opt => { opt.MapFrom(s => s.FirstName); })
            .ForMember(d => d.LastName, opt => { opt.MapFrom(s => s.LastName); })
            .ForPath(d => d.Address.Street, opt => { opt.MapFrom(s => s.Street); })
            .ForPath(d => d.Address.City, opt => { opt.MapFrom(s => s.City); })
            .ForPath(d => d.Address.ZipCode, opt => { opt.MapFrom(s => s.ZipCode); })
            .ForPath(d => d.Address.State, opt => { opt.MapFrom(s => s.State); })
            .ForPath(d => d.Rate.InsuredValueAmount, opt => { opt.MapFrom(s => s.InsuredValueAmount); });

            CreateMap<Insured, InsuredUpdateDto>()
            .ForMember(d => d.FirstName, opt => { opt.MapFrom(s => s.FirstName); })
            .ForMember(d => d.LastName, opt => { opt.MapFrom(s => s.LastName); })
            .ForPath(d => d.Street, opt => { opt.MapFrom(s => s.Address.Street); })
            .ForPath(d => d.City, opt => { opt.MapFrom(s => s.Address.City); })
            .ForPath(d => d.ZipCode, opt => { opt.MapFrom(s => s.Address.ZipCode); })
            .ForPath(d => d.State, opt => { opt.MapFrom(s => s.Address.State); })
            .ForPath(d => d.InsuredValueAmount, opt => { opt.MapFrom(s => s.Rate.InsuredValueAmount); });

        }
    }
}
