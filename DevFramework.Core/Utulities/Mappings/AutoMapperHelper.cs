using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Utulities.Mappings
{
    public class AutoMapperHelper
    {
        public static IMapper mapper;
        public static List<T> MapToSameTypeLis<T>(List<T> list)  //Aynı Tipte bir listenin mapping işlemni için yaptık bunu
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T>();
            });
            mapper = config.CreateMapper();
            List<T> result = mapper.Map<List<T>, List<T>>(list);
            return result;
        }
        public static T MapToSameType<T>(T obj)  //Aynı Tipte bir objenin  mapping işlemi için yaptık bunu
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, T>();
            });
            mapper = config.CreateMapper();
            T result = mapper.Map<T, T>(obj);
            return result;
        }

        //Fraklı tiperl olursa configürasyonun da parametre olarak alınması lazım olacak 
        


    }
}
