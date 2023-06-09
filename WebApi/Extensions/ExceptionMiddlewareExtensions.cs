﻿using System;
using System.Net;
using Entities.ErrorModels;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contract;

namespace WebApi.Extensions
{
	public static class ExceptionMiddlewareExtensions
	{
		public static void ConfigureExceptionHandler(this WebApplication app,ILoggerService logger)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{

					context.Response.ContentType = "application/json";
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if(contextFeature is not null)
					{
						context.Response.StatusCode = contextFeature.Error switch
						{
							NotFoundException => StatusCodes.Status404NotFound,
							_=>StatusCodes.Status500InternalServerError
						};
						logger.LogError($"Somting went wrong {contextFeature.Error.Message}");
						await context.Response.WriteAsync(new ErrorDetails()
						{
							Message = contextFeature.Error.Message,
							StatusCode = context.Response.StatusCode

                        }.ToString());
					}

                }
				 

						
				);
				
			});
		}
	}
}

