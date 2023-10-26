using Newtonsoft.Json;
using SQU4D.Data.Models;
using SQU4D.Data.Repository;
using System.Security.Claims;
using System.Text;

namespace SQU4D.Domain.Application.Service;

public class EncaminhamentoService
{
    private readonly EncaminhamentoRepository _encaminhamentoRepository;
    private readonly AlertRepository _alertRepository;
    private readonly UsuarioRepository _usuarioRepository;
    private readonly VeiculoRepository _veiculoRepository;
    public EncaminhamentoService(EncaminhamentoRepository encaminhamentoRepository, AlertRepository alertRepository, UsuarioRepository usuarioRepository, VeiculoRepository veiculoRepository)
    {
        _encaminhamentoRepository = encaminhamentoRepository;
        _alertRepository = alertRepository;
        _usuarioRepository = usuarioRepository;
        _veiculoRepository = veiculoRepository;
    }

    public async Task<bool> PostSyonet(int AlertaId)
    {
        var alerta = _alertRepository.GetAlert(AlertaId);
        var veiculo = _veiculoRepository.RecuperaVeiculoById(alerta.VeiculoId);
        Encaminhamento encaminhamento = new Encaminhamento();
        encaminhamento.UsuarioAlt = _usuarioRepository.GetUser();
        encaminhamento.UsuarioInc = _usuarioRepository.GetUser();
        encaminhamento = new Encaminhamento();
        encaminhamento.AlertId = AlertaId;

        var jsonData = new
        {
            idInterfaceNegociacao = 0,
            notificacoes = new
            {
                key = "ENCAMINHAMENTO",
                value = 0
            },
            encaminhamentoAtivo = new
            {
                idEncaminhamento = 0,
                idEvento = 0,
                idUsuarioEncaminhador = 0,
                idUsuario = 0,
                motivo = "string",
                idEmpresa = 0,
                encaminhamentoAtivo = true,
                dataInclusao = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                dataAlteracao = 0,
                usuarioInc = encaminhamento.UsuarioInc,
                usuarioAlt = encaminhamento.UsuarioAlt,
                origemRetorno = 0
            },
            veiculo = new
            {
                idVeiculo = veiculo.Id.ToString(),
                idCliente = veiculo.ClienteId,
                placa = veiculo.Placa,
                cor = veiculo.Cor,
                chassi = veiculo.Chassi,
                modelo = veiculo.Modelo
            },
            evento = new
            {
                idCliente = veiculo.ClienteId,
                idEmpresa = 0,
                idGrupoEvento = "string",
                idTipoEvento = "string",
                formaContato = "string",
                midia = "string",
                temperatura = "BOLSAO",
                marca = "string",
                modelo = "string",
                idAgente = 0,
                observacao = "string",
                dataProximaAcao = 0
            }
        };
        string json = JsonConvert.SerializeObject(jsonData);

        using (var httpClient = new HttpClient())
        {

            string apiUrl = "sua_url_destino"; 

            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

     
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiUrl, content);

        
            if (response.IsSuccessStatusCode)
            {
         
                var responseContent = await response.Content.ReadAsStringAsync();
              
                _encaminhamentoRepository.AdicionaEncaminhamento(encaminhamento);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
