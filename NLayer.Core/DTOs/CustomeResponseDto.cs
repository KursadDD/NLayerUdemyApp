using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomeResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore] //json olarak dönerken görmezden gel, dönme
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }

        public static CustomeResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomeResponseDto<T> { StatusCode = statusCode, Data = data };
        }
        public static CustomeResponseDto<T> Success(int statusCode)
        {
            return new CustomeResponseDto<T> { StatusCode = statusCode};
        }
        public static CustomeResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomeResponseDto<T> { StatusCode = statusCode,  Errors=errors};
        }
        public static CustomeResponseDto<T> Fail(int statusCode, string errors)
        {
            return new CustomeResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { errors }  };
        }
    }
}
