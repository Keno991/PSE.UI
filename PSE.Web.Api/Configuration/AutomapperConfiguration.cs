using AutoMapper;
using PSE.BLL.WCF.Contracts.DataContracts;
using PSE.Web.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSE.Web.Api.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() : this("PSEUIAutoMapper")
        {
        }

        protected AutoMapperConfiguration(string profileName) : base(profileName)
        {
            CreateMap<PullingImagesModel, PullingImagesViewModel>();
        }
    }
}
