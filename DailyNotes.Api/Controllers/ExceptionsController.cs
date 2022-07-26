﻿using DailyNotes.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DailyNotes.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error() 
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            switch (exception)
            {
                case UserException userException:
                    return Problem(title: userException.MessageForUser, statusCode: userException.StatusCode);
                case NoteException noteException:
                    return Problem(title: noteException.MessageForUser, statusCode: noteException.StatusCode);
                default:
                    return Problem(title: exception?.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}