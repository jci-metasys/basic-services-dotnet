using AutoMapper;
using Flurl.Http.Testing;
using JohnsonControls.Metasys.BasicServices;
using JohnsonControls.Metasys.ComServices;
using JohnsonControls.Metasys.ComServices.Interfaces;

namespace MetasysServicesCom.Tests
{
    public class InitializeMethod
    {
        public ComMetasysClientFactory ComMetasysClientFactory;
        public MetasysClient MClient;
        public ILegacyMetasysClient LClient;
        public IMapper Mapper;
        public HttpTest httpTest;

        public void MethodInitialize()
        {
            MClient = new MetasysClient("hostname");
            ComMetasysClientFactory = new ComMetasysClientFactory();
            LClient = ComMetasysClientFactory.GetLegacyClient("hostname");
            httpTest = new HttpTest();

            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AccessToken, IComAccessToken>();
                cfg.CreateMap<Variant, IComVariant>();
                cfg.CreateMap<VariantMultiple, IComVariantMultiple>();
                cfg.CreateMap<MetasysObject, IComMetasysObject>().ForMember(dest => dest.Children, opt => opt.MapFrom(src => Mapper.Map<IComMetasysObject[]>(src.Children)));
                cfg.CreateMap<VariantMultiple, IComVariantMultiple>()
                    .ForMember(dest => dest.Variants, opt => opt.MapFrom(src => Mapper.Map<IComVariant[]>(src.Variants)));
                cfg.CreateMap<Command, IComCommand>();
                cfg.CreateMap<MetasysObjectType, IComMetasysObjectType>();
            }).CreateMapper();
        }
    }
}
