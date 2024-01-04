
using AutoMapper;
using banco.DTO;
using banco.Models;
using bancos.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace banco.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _repository;

        private readonly IMapper _mapper;
        public UserController(IGenericRepository<User> repository, IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]

        public async Task<ActionResult> Crear(UserCreacionDTO userCreacionDTO)
        {
            var user = _mapper.Map<User>(userCreacionDTO);
            var resultado = await _repository.Insertar(user);
            if (!resultado)
            {
                return NotFound();
            }
            var dto = _mapper.Map<UserCreacionDTO>(user);
            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> ObtenerTodos()
        {
            var users = await _repository.ObtenerTodos();
            var usersDTO = _mapper.Map < IEnumerable < UserDTO>>(users);
            return Ok(usersDTO);
        }

       [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<UserDTO>> Obtener(int id)
        {
            var user = await _repository.Obtener(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }
       
    }
}
