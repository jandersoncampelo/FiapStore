using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System.Text;

namespace FiapStore.Common;

public class ValidationException : Exception
{
    public IList<ValidationResult> ValidationErrors { get; } = new List<ValidationResult>();

    public LogLevel LogLevel { get; set; } = LogLevel.Warning;

    public ValidationException(string message) : base(message)
    {
        ValidationErrors = new List<ValidationResult>();
        LogLevel = LogLevel.Warning;
    }

    public ValidationException(string message, IList<ValidationResult> validationErrors) : base(message)
    {
        ValidationErrors = validationErrors;
        LogLevel = LogLevel.Warning;
    }


    public void Log(ILogger logger)
    {
        if (!ValidationErrors.Any())
        {
            return;
        }

        var validationErrors = new StringBuilder();
        validationErrors.AppendLine("There are " + ValidationErrors.Count + " validation errors:");
        foreach (var validationResult in ValidationErrors)
        {
            var rules = "";
            if (validationResult.RuleSetsExecuted != null && validationResult.RuleSetsExecuted.Any())
            {
                rules = " (" + string.Join(", ", validationResult.RuleSetsExecuted) + ")";
            }

            validationErrors.AppendLine(validationResult.Errors + rules);
        }

        logger.Log(LogLevel, validationErrors.ToString());
    }
}
