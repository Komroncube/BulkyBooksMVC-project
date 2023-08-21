using Microsoft.AspNetCore.Mvc;

namespace firstdemo
{
    public class HtmlResult:IActionResult
    {
        string htmlCode;

        public HtmlResult(string html)=> htmlCode = html;
        public async Task ExecuteResultAsync(ActionContext actionContext)
        {
            string fullHtmlCode= @$"<!DOCTYPE html>
            <html>
                <head>
                    <title>METANIT.COM</title>
                    <meta charset=utf-8 />
                </head>
                <body>{htmlCode}</body>
            </html>";
            await actionContext.HttpContext.Response.WriteAsync(fullHtmlCode);

        }
    }
}
