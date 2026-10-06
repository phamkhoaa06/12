using Microsoft.AspNetCore.Http;

namespace BookManagement.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Lấy thời gian hiện tại
            var time = DateTime.Now;

            // Lấy HTTP Method
            var method = context.Request.Method;

            // Lấy URL Path
            var path = context.Request.Path.ToString();

            // Ghi log Request
            Console.WriteLine(
                $"[{time:yyyy-MM-dd HH:mm:ss.fff}] " +
                $"Method: {method} - Path: {path}"
            );

            // Chặn Book ID = 0 hoặc -1
            if (path == "/Book/Detail/0" ||
                path == "/Book/Detail/-1")
            {
                context.Response.StatusCode = 400;

                await context.Response.WriteAsync(
                    "Book id khong hop le"
                );

                // Ghi log Status Code 400
                Console.WriteLine(
                    $"Status Code: {context.Response.StatusCode}"
                );

                return;
            }

            // Cho request đi tiếp
            await _next(context);

            // Ghi Status Code sau khi xử lý
            Console.WriteLine(
                $"Status Code: {context.Response.StatusCode}"
            );
        }
    }
}