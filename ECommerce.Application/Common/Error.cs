using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Common
{
    public record Error(string code, string description, ErrorType type = ErrorType.Failure)
    {
        public static Error Failure(string code = "General.Failure", string description = "General failure Description") 
            => new Error(code, description, ErrorType.Failure);
        public static Error Validation(string code = "General.Validation", string description = "General Validation Description")
            => new Error(code, description, ErrorType.Validation);
        public static Error NotFound(string code = "General.NotFound", string description = "General Not Found Description")
            => new Error(code, description, ErrorType.NotFound);
        public static Error Conflict(string code = "General.Conflict", string description = "General Conflict Description")
            => new Error(code, description, ErrorType.Conflict);
        public static Error Unauthorized(string code = "General.Unauthorized", string description = "General Unauthorized Description")
            => new Error(code, description, ErrorType.Unauthorized);
        public static Error Forbidden(string code = "General.Forbidden", string description = "General Forbidden Description")
            => new Error(code, description, ErrorType.Forbidden);
        public static Error InvalidCredentials(string code = "General.InvalidCredentials", string description = "General Invalid Credentials Description")
            => new Error(code, description, ErrorType.InvalidCredentials);
    }
}
