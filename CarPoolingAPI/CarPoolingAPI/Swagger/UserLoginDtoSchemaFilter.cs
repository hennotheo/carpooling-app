using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CarPoolingAPI.Swagger;

public class UserLoginDtoSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties.ContainsKey("email"))
            schema.Properties["email"].Default = new OpenApiString("test@test.com");
        
        if (schema.Properties.ContainsKey("password"))
            schema.Properties["password"].Default = new OpenApiString("String123!");
    }
}