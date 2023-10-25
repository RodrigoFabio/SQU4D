using SQU4D.Data.Models;
using SQU4D.Data.Repository;
using System.Security.Claims;

namespace SQU4D.Domain.Application.Service;

public class EncaminhamentoService
{
    private readonly EncaminhamentoRepository _encaminhamentoRepository;
    private readonly AlertRepository _alertRepository;
    private readonly UsuarioRepository _usuarioRepository;
    public EncaminhamentoService(EncaminhamentoRepository encaminhamentoRepository, AlertRepository alertRepository, UsuarioRepository usuarioRepository)
    {
        _encaminhamentoRepository = encaminhamentoRepository;
        _alertRepository = alertRepository;
        _usuarioRepository = usuarioRepository;
    }



    public bool PostSyonet(int AlertaId)
    {
        var alerta = _alertRepository.GetAlert(AlertaId);
        Encaminhamento encaminhamento = new Encaminhamento();

        encaminhamento.AlertId = AlertaId;
        encaminhamento.UsuarioAlt = _usuarioRepository.GetUser();
        encaminhamento.UsuarioInc = _usuarioRepository.GetUser();

        _encaminhamentoRepository.AdicionaEncaminhamento(encaminhamento);
        return true;
    }
}
