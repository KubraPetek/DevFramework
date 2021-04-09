using AutoMapper;
using DevFramework.NorthWind.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramewok.NorthWind.Business.Mappings.AutoMappers.Profiles
{
    public class BusinessProfile:Profile
    {
        /// <summary>
        /// Temel serilestirme işlemlerini yapmak için bu mapping işlemlerini yapıyoruz 
        /// </summary>
        public BusinessProfile()
        {
            CreateMap<Product, Product>();
        }


    }
}
