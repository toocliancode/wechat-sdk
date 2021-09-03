using Mediator;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using WeChat.Mp.Request;

namespace WeChat.Mp.Web.Controllers
{
    /// <summary>
    /// 微信公众号接口
    /// </summary>
    [Route("api/wechat-mp")]
    [ApiController]
    public class WeChatMpController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeChatMpController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// 获取jssdk配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("jsapi-config")]
        public async Task<IActionResult> GetJsapiConfig(WeCahtMpJsapiConfigModel model)
        {
            var request = new WeChatMpJsapiConfigRequest(model.Url);
            var response = await _mediator.Send(request, HttpContext.RequestAborted);
            return Ok(response);
        }

        ///// <summary>
        ///// 素材转换成url
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //[HttpPost("media-convert")]
        //public async Task<IActionResult> MediaGet(WeChatMpMediaGetModel model)
        //{
        //    var request = new WeChatMpMediaGetRequest(model.MediaId);
        //    var response = await _mediator.Send(request, HttpContext.RequestAborted);
        //    return Ok(response);
        //}
    }
}
