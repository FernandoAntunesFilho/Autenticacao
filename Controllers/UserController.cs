using Autenticacao.DTO;
using Autenticacao.Models;
using Autenticacao.Repositories;
using Autenticacao.Services;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenGenerator _tokenGenerator;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _tokenGenerator = new TokenGenerator();
        }

        [HttpPost("signup")]
        public IActionResult AddUser([FromBody] User user)
        {
            User userCreated = _userRepository.AddUser(user);
            var token = _tokenGenerator.Generate(user);
            return Created("", new { token });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTORequest request)
        {
            User? existingUser = _userRepository.GetUserByEmail(request.Email!);
            if (existingUser == null) return Unauthorized(new { message = "Incorrect e-mail or password" });
            if (existingUser.Password != request.Password) return Unauthorized(new { message = "Incorrect e-mail or password" });

            var token = _tokenGenerator.Generate(existingUser);
            return Ok(new { token });
        }
    }
}