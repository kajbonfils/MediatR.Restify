using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApiTest.MediatR.RestFormatters;
using Newtonsoft.Json;

namespace MinimalApiTest.MediatR
{
    public static class RestFormatterExtension
    {

        public static async Task<IResult> ToRest(this Task<ApiResult> request) 
        {
            var apiResult = await request;
            var handler = GetRestFormatter(apiResult);
            return handler.FormatRest(apiResult);
        }

        public static List<IRestFormatter> Formatters = new List<IRestFormatter>
        {
            new ConflictRestFormatter(),
            new OkRestFormatter(),
            new DefaultRestFormatter()
        };

        private static IRestFormatter GetRestFormatter(ApiResult apiResult)
        {
            var formatter = Formatters.First(p => p.CanFormat(apiResult));
            return formatter;
        }
    }
}
