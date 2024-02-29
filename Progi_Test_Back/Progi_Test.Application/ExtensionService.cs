using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Progi_Test.Application.Interfaces;
using Progi_Test.Application.Mapping;
using Progi_Test.Application.Services;

namespace Progi_Test.Application;

public static class ExtensionServices
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        var mappingConfig = new MapperConfiguration(c => { c.AddProfile(new MappingProfile()); });
        var mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
        services.AddScoped<IFeeService, FeeService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}