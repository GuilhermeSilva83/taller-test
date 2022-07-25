using System;
using System.Collections.Generic;
using System.Text;

namespace TallerTest.Domain.Seedwork
{

    public class OperationResult<TData> : OperationResult
    {
        public TData Data { get; set; }

    }


    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static OperationResult Ok<TData>(TData data, string message = "Success")
        {
            return new OperationResult<TData>()
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

        public static OperationResult Ok(string message = "Success")
        {
            return new OperationResult()
            {
                Success = true,
                Message = message,
            };
        }


        public static OperationResult Ok()
        {
            return new OperationResult()
            {
                Success = true,
                Message = "Sucess",
            };
        }

        public static OperationResult Fail(string message = null)
        {
            return new OperationResult()
            {
                Success = false,
                Message = message
            };
        }
    }
}
