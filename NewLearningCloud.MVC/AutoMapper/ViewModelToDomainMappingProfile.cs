using AutoMapper;
using NewLearningCloud.Domain.Entities;
using NewLearningCloud.MVC.Areas.Admin.ViewModels;

namespace NewLearningCloud.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AulaViewModel, Aula>();
            //  CreateMap<AssinaturaNivelViewModel, AssinaturaNivel>();
        }
    }
}