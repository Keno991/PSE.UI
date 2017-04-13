using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSE.BLL.WCF.Contracts.Contracts;
using PSE.Web.Api.Configuration;
using PSE.Web.Api.Helpers;
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
        ILogger _logger;

        public ImageUtilityController(IImageUtilityService imgUtilService, ICommonTracing tracing) : base(tracing)
        {
            _imgUtilService = imgUtilService;

        }

        public bool Get()
        {
            return true;
        }

        [HttpPost]
        public async Task<bool> Post(string url)
        {
            return await _tracing.TracingInvoke(async () => await _imgUtilService.PullImagesFromWebPage(url));
        }

    }
}
