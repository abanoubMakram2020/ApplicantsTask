using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernal.Common;
using SharedKernal.Middlewares.Basees;

namespace ApplicantsTask.Presentation.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route(APIRoute.VersioningTemplate)]
    public class BaseController : ControllerBase
    {
        #region Properties
        public Presenter _Presenter;
        #endregion

        #region Constructor
        public BaseController(Presenter Presenter)
        {
            _Presenter = Presenter;
        }
        #endregion
    }
}
