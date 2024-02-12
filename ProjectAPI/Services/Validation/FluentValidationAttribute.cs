using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProjectAPI.Services.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class FluentValidationAttribute : Attribute, IActionFilter
    {
        private readonly Type _validatorType;

        public FluentValidationAttribute(Type validatorType)
        {
            _validatorType = validatorType ?? throw new ArgumentNullException(nameof(validatorType));
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            foreach (var argument in context.ActionArguments.Values)
            {
                var validationResult = validator.Validate(new ValidationContext<object>(argument));

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }

                    context.Result = new Microsoft.AspNetCore.Mvc.BadRequestObjectResult(context.ModelState);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)  { }
    }
}
