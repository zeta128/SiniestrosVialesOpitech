using SiniestrosVialesOpitech.Domain.Options.Pagination;
using System.Text.Json.Serialization;


namespace SiniestrosVialesOpitech.Domain.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data, string? message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public Response(bool succeded, T data, string? message = null)
        {
            Succeeded = succeded;
            Message = message;
            Data = data;
        }

        public Response(bool succeded, string message)
        {
            Succeeded = succeded;
            Message = message;
        }

        public Response(string message)
        {
            Succeeded = true;
            Message = message;
        }

        public Response(MetaData metaData, T data)
        {
            Succeeded = true;
            MetaData = metaData;
            Data = data;
        }

        public bool Succeeded { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Message { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MetaData? MetaData { get; private set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T Data { get; private set; } = default!;
    }
}