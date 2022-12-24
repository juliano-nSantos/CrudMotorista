using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Service;
using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;
using Domain.Core.Interfaces.Validations;
using Domain.Models;
using Domain.Services.Services;
using Domain.Services.Validations;
using Infra.CrossCutting.Adapter.Interfaces;
using Infra.CrossCutting.Adapter.Map;
using Infra.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IOC.InversionOfControl
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection LoadDI(this IServiceCollection services)
        {
            #region Registers IOC

            #region IOC Application
            services.AddScoped<IApplicationServiceMotorista, ApplicationServiceMotorista>();
            #endregion

            #region IOC Services
            services.AddScoped<IServiceMotorista, ServiceMotorista>();
            #endregion

            #region  IOC RepositorySQL
            services.AddScoped<IRepositoryMotorista, RepositoryMotorista>();
            #endregion

            #region IOC Mapper
            services.AddScoped<IMapperMotorista, MapperMotorista>();

            #endregion

            #region IOC Validates
            services.AddScoped<IValidationModel<FiltroBuscaMotorista>,ValidateFilter>();
            #endregion

            #endregion

            return services;
        }
    }
}