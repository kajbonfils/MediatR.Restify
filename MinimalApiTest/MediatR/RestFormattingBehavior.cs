using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

    internal class ConflictRestFormatter : IRestFormatter
    {
        public bool CanFormat(ApiResult apiResult) => apiResult.StatusCode == HttpStatusCode.Conflict;

        public IResult FormatRest(ApiResult apiResult) 
        {
            return Results.Conflict(apiResult.Message);
        }
    }

    internal class DefaultRestFormatter : IRestFormatter
    {
        public bool CanFormat(ApiResult apiResult) => true;

        public IResult FormatRest(ApiResult apiResult)
        {
            return Results.StatusCode((int)apiResult.StatusCode);
        }
    }

    internal class OkRestFormatter : IRestFormatter
    {
        public bool CanFormat(ApiResult apiResult) => apiResult.StatusCode == HttpStatusCode.OK;

        public IResult FormatRest(ApiResult apiResult)
        {
            return Results.Ok(apiResult.Payload);
        }
    }

    public interface IRestFormatter
    {
        public bool CanFormat(ApiResult apiResult);
        IResult FormatRest(ApiResult apiResult);
    }
}
