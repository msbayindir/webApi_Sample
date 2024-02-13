using Microsoft.AspNetCore.Mvc;
using WebApi.Utilities.Formatters;

namespace WebApi.Extensions;

public static class IMvcBuilderExtensions
{
    public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder mvcBuilder )
    {

        mvcBuilder.AddMvcOptions(opt =>
        {
        opt.OutputFormatters.Add(new CsvOutputFormatter());
       
        });
        
        return mvcBuilder;
    }

    public static IMvcBuilder AddCacheProfile(this IMvcBuilder builder)
    {
        builder.AddMvcOptions(opt =>
        {
            opt.CacheProfiles.Add("5mins", new CacheProfile()
            {
                Duration = 300,
                
            });
        });
        return builder;
    }
}