using _4._07._23_2_.Abstract;
using _4._07._23_2_.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4._07._23_2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class Auth2Controller : ControllerBase
    {

        IUserService _userService;
        // api/auth/register
        public Auth2Controller(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public async Task<UserManagerResponse> RegisterAsync([FromBody]RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);
                if (result.IsSuccess)
                    return result;

                return null;
            }

            return null;
        }

        [HttpPost("Login")]

        public async Task<UserManagerResponse> LoginAsync([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);

                if (result.IsSuccess)
                    return (result);

                return null;
            }

            return null;
        }

    }
}
