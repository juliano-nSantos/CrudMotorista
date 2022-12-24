using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Extensions;
using Domain.Core.Interfaces.Validations;
using Domain.Models;

namespace Domain.Services.Validations
{
    public class ValidateFilter : IValidationModel<FiltroBuscaMotorista>
    {
        public bool ValidateModel(FiltroBuscaMotorista entity)
        {
            if (!entity.Nome.NotIsNullOrEmpty() && !entity.CPF.NotIsNullOrEmpty()
                && !entity.Sexo.NotIsNullOrEmpty() && !entity.StatusMotorista.NotIsNullOrGreaterThanZero()
                && !entity.AnoNascimentoInicial.NotIsNullOrGreaterThanZero()
                && !entity.AnoNascimentoFinal.NotIsNullOrGreaterThanZero())
            {
                return false;
            }

            return true;
        }
    }
}