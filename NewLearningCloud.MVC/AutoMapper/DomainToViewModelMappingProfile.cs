using AutoMapper;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.MVC.Areas.Admin.ViewModels;

namespace NewLearningCloud.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        //protected override void Configure()
        //{
        //    CreateMap<Aula, AulaViewModel>();
        //}

        public DomainToViewModelMappingProfile()
        {
            CreateMap<Aula, AulaViewModel>();
        }

    }
}