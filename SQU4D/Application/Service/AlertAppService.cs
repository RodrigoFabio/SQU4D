using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using SQU4D.Data.Models;
using SQU4D.Data.Repository;
using System.Text.Json;

namespace SQU4D.Application.Service;

public class AlertAppService
{
    private readonly AlertRepository _alertRepository;
    public AlertAppService(AlertRepository alertRepository) 
    {
        _alertRepository = alertRepository;
    }
    public bool ConvertJson(JsonElement jsonValue)
    {
        var valuesElement = jsonValue.GetProperty("values");
        foreach (var valueElement in valuesElement.EnumerateArray())
        {
            var alertDTO = ConvertJsonAlert(valueElement);
            _alertRepository.AdicionaAlert(alertDTO);
        }
        return true;
    }

    public AlertDTO ConvertJsonAlert(JsonElement json)
    {
        AlertDTO alert = new AlertDTO();
        Console.WriteLine(json);
        alert = JsonConvert.DeserializeObject<AlertDTO>(json.ToString());
        alert.Type = json.GetProperty("@type").ToString();
        alert.Duration.Type = json.GetProperty("duration").GetProperty("@type").ToString();
        alert.Definition.Type = json.GetProperty("definition").GetProperty("@type").ToString();
        alert.EngineHours.Type = json.GetProperty("engineHours").GetProperty("@type").ToString();
        alert.Location.Type = json.GetProperty("location").GetProperty("@type").ToString();
        var linksArray = json.GetProperty("definition").GetProperty("links");

        if (linksArray.EnumerateArray().Any())
        { Link link = new Link();
            var firstLinkElement = linksArray.EnumerateArray().First();
            link.Type = firstLinkElement.GetProperty("@type").ToString();
            link.Rel = firstLinkElement.GetProperty("rel").ToString();
            link.Uri = firstLinkElement.GetProperty("uri").ToString();
            alert.Definition.DefinitionLink = link;
        }

        var alertLinksArray = json.GetProperty("links");
        if (alertLinksArray.EnumerateArray().Any())
        {
            Link link = new Link();
            var firstLinkElement = linksArray.EnumerateArray().First();
            link.Type = firstLinkElement.GetProperty("@type").ToString();
            link.Rel = firstLinkElement.GetProperty("rel").ToString();
            link.Uri = firstLinkElement.GetProperty("uri").ToString();
            alert.Link = link;
        }
        return alert;
    }



}
