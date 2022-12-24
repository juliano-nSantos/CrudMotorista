using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Validations
{
    public interface IValidationModel<T>
    {
        bool ValidateModel(T entity);
    }
}