using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSE.BLL.WCF.Contracts.Contracts;
using PSE.BLL.WCF.Contracts.DataContracts;
using PSE.Web.Api.Configuration;
using PSE.Web.Api.Helpers;
using PSE.Web.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Const = PSE.Web.Api.Constants.Constants;

namespace PSE.Web.Api.Controllers
{
    public class ImageUtilityController : PSEBaseController
    {
        IImageUtilityService _imgUtilService;
        IMapper _mapper;

        public ImageUtilityController(IImageUtilityService imgUtilService, ICommonTracing tracing, IMapper mapper) : base(tracing)
        {
            _imgUtilService = imgUtilService;
            _mapper = mapper;
        }

        public bool Get()
        {
            return true;
        }

        [HttpPost]
        public async Task<PullingImagesViewModel> Post(string url)
        {
            return await _tracing.TracingInvoke(async () => 
            _mapper.Map<PullingImagesModel, PullingImagesViewModel>(await _imgUtilService.PullImagesFromWebPage(url)));
        }

    }
}
