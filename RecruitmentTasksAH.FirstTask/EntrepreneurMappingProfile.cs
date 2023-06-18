using AutoMapper;
using RecruitmentTasksAH.FirstTask.Dtos;
using RecruitmentTasksAH.FirstTask.Model;

namespace RecruitmentTasksAH.FirstTask
{
    public class EntrepreneurMappingProfile : Profile
    {
        public EntrepreneurMappingProfile()
        {
            CreateMap<Subject, Entrepreneur>()
                .ForMember(dest => dest.Representatives,
                    opt => opt.MapFrom(src => src.Representatives))
                .ForMember(dest => dest.AccountNumbers,
                    opt => opt.MapFrom(src => src.AccountNumbers.Select(accountNumber => new AccountNumber { Number = accountNumber }).ToList()));

            CreateMap<Dtos.Representative, Model.Representative>();
        }
    }

}
