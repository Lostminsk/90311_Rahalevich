using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _90311_Rahalevich.Middleware;

namespace _90311_Rahalevich.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app)=> app.UseMiddleware<LogMiddleware>();
    }
}
