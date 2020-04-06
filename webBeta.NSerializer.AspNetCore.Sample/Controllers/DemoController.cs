using Microsoft.AspNetCore.Mvc;

namespace webBeta.NSerializer.AspNetCore.Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly NSerializer _serializer;

        public DemoController(NSerializer serializer)
        {
            _serializer = serializer;
        }

        [HttpGet("ascreated")]
        public ActionResult AsCreated()
        {
            return _serializer.SerializeAndCreated(new Demo(), "created_group");
        }

        [HttpGet("asok")]
        public ActionResult AsOk()
        {
            return _serializer.SerializeAndCreated(new Demo(), "ok_group");
        }
    }
}