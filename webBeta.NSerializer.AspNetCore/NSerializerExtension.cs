using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webBeta.NSerializer.AspNetCore
{
    public static class NSerializerExtension
    {
        public static ContentResult SerializeAndCreated(this NSerializer serializer, object ob, params string[] group)
        {
            return new ContentResult
            {
                Content = serializer.Serialize(ob, group),
                ContentType = "application/json",
                StatusCode = StatusCodes.Status201Created
            };
        }
        
        public static ContentResult SerializeAndOk(this NSerializer serializer, object ob, params string[] group)
        {
            return new ContentResult
            {
                Content = serializer.Serialize(ob, group),
                ContentType = "application/json",
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}