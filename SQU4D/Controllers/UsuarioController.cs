using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SQU4D.Application.Service;
using SQU4D.Data.DTOs;
using SQU4D.Data.Models;
using SQU4D.Domain.Interfaces.Service;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SQU4D.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController: ControllerBase
{
    //UsuarioAppService usuarioAppService = new UsuarioAppService();
    private UsuarioAppService _userService;
    private AlertAppService _alertService;

    public UsuarioController(UsuarioAppService userService, AlertAppService alertService)
    {
        _userService = userService;
        _alertService = alertService;
    }

    
    [HttpPost("validar")]
    public IActionResult ValidaUsuario([FromBody] LoginUsuarioDTO usuarioLogin)
    {   //colocar regex email
        var usuario = _userService.ValidarCredenciais(usuarioLogin);
        if (!usuario)
        {
            return BadRequest();
        }
        return Ok(new { Success = true });
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastraUsuario([FromBody] CadastroUsuarioDTO usuarioCadastro)
    {
        var cadastrado = _userService.CadastrarNovoUsuario(usuarioCadastro);
        if (cadastrado)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpPost("json")]
    public IActionResult PostJson([FromBody] JsonElement json)
    {

        if(json.ToString() != null)
        {
            //Console.WriteLine(json.GetProperty("values")[0].ToString());
            _alertService.ConvertJson(json);
           return Ok();
        }
        return BadRequest();
      
        //    Type = json.GetProperty("values")[0].GetProperty("@type").GetString(),
        //    DurationType = json.GetProperty("values")[0].GetProperty("duration")["@type"].GetString(),
        //    DurationValue = json.GetProperty("values")[0].GetProperty("duration")["valueAsInteger"].GetInt32(),
        //    DurationUnit = json.GetProperty("values")[0].GetProperty("duration")["unit"].GetString(),
        //    Occurrences = json.GetProperty("values")[0].GetProperty("occurrences").GetString(),
        //    EngineHoursType = json.GetProperty("values")[0].GetProperty("engineHours")["@type"].GetString(),
        //    EngineHoursValue = json.GetProperty("values")[0].GetProperty("engineHours")["reading"]["@type"].GetString(),
        //    EngineHoursUnit = json.GetProperty("values")[0].GetProperty("engineHours")["reading"]["unit"].GetString(),
        //    MachineLinearTime = json.GetProperty("values")[0].GetProperty("machineLinearTime").GetInt32(),
        //    Bus = json.GetProperty("values")[0].GetProperty("bus").GetInt32(),
        //    Time = DateTime.Parse(json.GetProperty("values")[0].GetProperty("time").GetString()),
        //    LocationType = json.GetProperty("values")[0].GetProperty("location")["@type"].GetString(),
        //    Lat = json.GetProperty("values")[0].GetProperty("location")["lat"].GetDouble(),
        //    Lon = json.GetProperty("values")[0].GetProperty("location")["lon"].GetDouble(),
        //    Color = json.GetProperty("values")[0].GetProperty("color").GetString(),
        //    Severity = json.GetProperty("values")[0].GetProperty("severity").GetString(),
        //    AcknowledgementStatus = json.GetProperty("values")[0].GetProperty("acknowledgementStatus").GetString(),
        //    Ignored = json.GetProperty("values")[0].GetProperty("ignored").GetBoolean(),
        //    Invisible = json.GetProperty("values")[0].GetProperty("invisible").GetBoolean(),
        //    LinkType = json.GetProperty("values")[0].GetProperty("links")[0]["@type"].GetString(),
        //    LinkRel = json.GetProperty("values")[0].GetProperty("links")[0]["rel"].GetString(),
        //    LinkUri = json.GetProperty("values")[0].GetProperty("links")[0]["uri"].GetString(),
        //    DefinitionLinkType = json.GetProperty("values")[0].GetProperty("definition")["@type"].GetString(),
        //    DefinitionLinkRel = json.GetProperty("values")[0].GetProperty("definition")["links"][0]["@type"].GetString(),
        //    DefinitionLinkUri = json.GetProperty("values")[0].GetProperty("definition")["links"][0]["rel"].GetString(),
        //    DefinitionType = json.GetProperty("values")[0].GetProperty("definition")["suspectParameterName"].GetString(),
        //    DefinitionSuspectParameterName = json.GetProperty("values")[0].GetProperty("definition")["failureModeIndicator"].GetString(),
        //    DefinitionFailureModeIndicator = int.Parse(json.GetProperty("values")[0].GetProperty("definition")["bus"].GetString()),
        //    DefinitionBus = json.GetProperty("values")[0].GetProperty("definition")["sourceAddress"].GetString(),
        //    DefinitionSourceAddress = json.GetProperty("values")[0].GetProperty("definition")["threeLetterAcronym"].GetString(),
        //    DefinitionId = int.Parse(json.GetProperty("values")[0].GetProperty("definition")["id"].GetString()),
        //    DefinitionDescription = json.GetProperty("values")[0].GetProperty("definition")["description"].GetString()
       
     }



}




