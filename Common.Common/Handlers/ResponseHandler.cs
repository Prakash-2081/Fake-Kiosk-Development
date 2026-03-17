using Common.Common.Response;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Common.Common.Handlers
{
    public static class ResponseHandler
    {
        public static APIResponse GetValidationErrorResponse(ValidationResult? validationResult)
        {
            IDictionary<string, string> errors = new Dictionary<string, string>();
            foreach (var error in validationResult.Errors)
            {
                errors[error.PropertyName] = error.ErrorMessage;
            }
            return new APIResponse(false,HttpStatusCode.BadRequest,errors,Message.ERROR);
        }
        public static APIResponse GetValidationErrorResponse(string validationResult)
        {
            return new APIResponse(false, HttpStatusCode.BadRequest, validationResult, Message.ERROR);
        }
        public static APIResponse GetValidationErrorResponse(List<ValidationResult> validationResult)
        {
            var errors = validationResult.SelectMany(vr => vr.Errors).ToList();
            return new APIResponse(false,HttpStatusCode.BadRequest,errors,Message.ERROR);
        }
        public static APIResponse GetBadRequestResponse(string message)
        {
            return new APIResponse(false,HttpStatusCode.BadRequest,message,Message.ERROR);
        }
        public static APIResponse GetSuccessResponse(dynamic data,string message)
        {
            return new APIResponse(true,HttpStatusCode.OK,data,message);
        }
        public static APIResponse GetSuccessResponse(dynamic data)
        {
            return new APIResponse(true,HttpStatusCode.OK,data,Message.OK);
        }
        public static APIResponse GetUnAuthorizeResponse()
        {
            return new APIResponse(false,HttpStatusCode.Unauthorized,"Invalid UserName or Password");
        }
        public static APIResponse GetUnAuthorizeResponse(dynamic data,string message)
        {
            return new APIResponse(false,HttpStatusCode.Unauthorized,data,message);
        }
        public static ActionResult<APIResponse> ToActionResult(this APIResponse response) 
        {
            return new ObjectResult(response)
            {
                StatusCode = (int)response.Code
            };
        }
    }
}
