using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Filters
{
    public class CustomModelStateValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var validateInputViewModel = new ValidateInputViewModel(
                                            context.ModelState
                                            .SelectMany(sm => sm.Value.Errors)                                            
                                            .Select(s=> s.ErrorMessage
                                            ));

                context.Result = new BadRequestObjectResult(validateInputViewModel);
            }            
        }
    }
}