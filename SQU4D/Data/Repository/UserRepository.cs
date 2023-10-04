using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SQU4D.Data.Context;
using SQU4D.Data.DTOs;
using SQU4D.Data.Models;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using FluentValidation.Results;
namespace SQU4D.Data.Repository;

public class UsuarioRepository
{
    private Squ4dContext _context;
    private IMapper _mapper;
    public UsuarioRepository(Squ4dContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ValidationResult CadastraNovoUsuario([FromBody]CadastroUsuarioDTO novoUsuario)
    {
        var result = new ValidationResult();
        Usuario usuario = _mapper.Map<Usuario>(novoUsuario);
        try
        {

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
         return result;
        }catch (Exception ex) {
            result.Errors.Add(new ValidationFailure("", "Erro ao cadastrar usuário"));
            return result;
        }
    }

    public ValidationResult ValidaCredenciaisUsuario(LoginUsuarioDTO usuario)
    {
        var result = new ValidationResult();    
        var usuarioExiste = _context.Usuarios.Where(x => x.Email == usuario.Email).FirstOrDefault();
        if (usuarioExiste == null)
        {
            result.Errors.Add(new ValidationFailure("Email", "E-mail não encontrado"));
            return result;
        }

        if(!BCrypt.Net.BCrypt.Verify(usuario.Senha, usuarioExiste.Senha))
        {
            result.Errors.Add(new ValidationFailure("Senha", "Senha incorreta"));
        }
        return result;
    }
    
}