using AutoMapper;
using SQU4D.Data.Models;

namespace SQU4D.Application.Profiles;

public class AlertProfile : Profile
{
    public AlertProfile() 
    {
        CreateMap<AlertDTO, Alert>()
            .ForMember(dest => dest.AlertApiId, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.DurationType, opt => opt.MapFrom(src => src.Duration.Type))
            .ForMember(dest => dest.DurationValue, opt => opt.MapFrom(src => src.Duration.ValueAsInteger))
            .ForMember(dest => dest.DurationUnit, opt => opt.MapFrom(src => src.Duration.Unit))

            .ForMember(dest => dest.DefinitionLinkType, opt => opt.MapFrom(src => src.Definition.DefinitionLink.Type))
            .ForMember(dest => dest.DefinitionLinkRel, opt => opt.MapFrom(src => src.Definition.DefinitionLink.Rel))
            .ForMember(dest => dest.DefinitionLinkUri, opt => opt.MapFrom(src => src.Definition.DefinitionLink.Uri))
            .ForMember(dest => dest.DefinitionType, opt => opt.MapFrom(src => src.Definition.Type))
            .ForMember(dest => dest.DefinitionSuspectParameterName, opt => opt.MapFrom(src => src.Definition.SuspectParameterName))
            .ForMember(dest => dest.DefinitionFailureModeIndicator, opt => opt.MapFrom(src => src.Definition.FailureModeIndicator))

            .ForMember(dest => dest.EngineHoursType, opt => opt.MapFrom(src => src.EngineHours.Type))
            .ForMember(dest => dest.EngineHoursValue, opt => opt.MapFrom(src => src.EngineHours.ValueAsInteger))
            .ForMember(dest => dest.EngineHoursUnit, opt => opt.MapFrom(src => src.EngineHours.Unit))

            .ForMember(dest => dest.LocationType, opt => opt.MapFrom(src => src.Location.Type))
            .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Location.Lat))
            .ForMember(dest => dest.Lon, opt => opt.MapFrom(src => src.Location.Lon))

            .ForMember(dest => dest.LinkRel, opt => opt.MapFrom(src => src.Link.Rel))
            .ForMember(dest => dest.LinkUri, opt => opt.MapFrom(src => src.Link.Uri))
            .ForMember(dest => dest.LinkType, opt => opt.MapFrom(src => src.Link.Type))
             .ForMember(dest => dest.Id, opt => opt.Ignore());


    }
}
          