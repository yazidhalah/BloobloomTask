
using AutoMapper;
using Core.Models;
using Core.ViewModels;

namespace Core.AutoMapper
{
    public class AutoMapperConfiguration
    {

        public static IMapper CreateMapper()
        {
            var MappConfig = new MapperConfiguration(x =>
            {

                x.CreateMap<LookupCurrency, LookupCurrencyVM>().ReverseMap();
                x.CreateMap<LookupFrame, LookupFrameVM>().ReverseMap();
                x.CreateMap<LookupLens, LookupLensVM>().ReverseMap();
                x.CreateMap<TransactionCart, TransactionCartVM>().ReverseMap();
                //x.CreateMap<FQStudent, FQStudentDetailsVM>().ReverseMap();
                

            });


            return MappConfig.CreateMapper();

        }

    }
}
