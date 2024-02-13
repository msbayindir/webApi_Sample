using System.Text;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace WebApi.Utilities.Formatters;

public class CsvOutputFormatter:TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanWriteType(Type? type)
    {
        if(typeof(ProductDto).IsAssignableFrom(type) ||
           typeof(IEnumerable<ProductDto>).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }
        return false;
    }
    private static void FormatCsv(StringBuilder buffer, ProductDto product)
    {
        buffer.AppendLine($"{product.Id}, {product.ProductName}, {product.Price}");
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
        Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();

        if (context.Object is IEnumerable<ProductDto>)
        {
            foreach (var book in (IEnumerable<ProductDto>)context.Object)
            {
                FormatCsv(buffer, book);
            }
        }
        else
        {
            FormatCsv(buffer, (ProductDto)context.Object);
        }

        await response.WriteAsync(buffer.ToString());

    }
}