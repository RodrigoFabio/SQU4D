using AutoMapper;
using SQU4D.Data.DTOs;
using SQU4D.Data.Models;

namespace SQU4D.Application.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<LoginUsuarioDTO, Usuario>();
        CreateMap<CadastroUsuarioDTO, Usuario>();
    }
}
