using Docker.Compose.API.Contracts;
using Docker.Compose.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Docker.Compose.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserRequest request)
        {
            var user = await _userService.AddAsync(
                request.Firstname, 
                request.Login
            );

            /*
             * return CreatedAtAction(actionName, routeValues, value)
             * Метод возвращает:
             * - статусный код состояния 201;
             * - URL - ссылку на новый ресурс (ссылку на вывод данного ресурса (пользователя)):
             *   * URI формируется на основе двух параметров actionName и routeValues.
             * - тело ответа - value.
             * Примечание: 
             * - в параметре actionName необходимо указать метод без суффикса Async - иначе будет ошибка;
             * - если нужно использовать Async, необходимо в при добавлении сервисов в коллекцию сервисов сделать так:
             *   * builder.Services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false)
             */

            return CreatedAtAction(
                nameof(GetByIdAsync),
                new { user.Id },
                user
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var users = await _userService.GetAsync();

            if (!users.Any())
                return NotFound();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
