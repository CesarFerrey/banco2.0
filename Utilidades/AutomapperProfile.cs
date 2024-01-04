
using AutoMapper;
using banco.DTO;
using banco.Models;

namespace ApiBiblioteca.Utilidades
{
    public class AutomapperProfile :Profile
    {
        public AutomapperProfile() 
        {
            CreateMap<UserCreacionDTO, UserDTO>();
            
         
        }
    }
}
