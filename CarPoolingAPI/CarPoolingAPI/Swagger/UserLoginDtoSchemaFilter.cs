using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CarPoolingAPI.Swagger;

public class UserLoginDtoSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties.ContainsKey("email"))
            schema.Properties["email"].Type = "test@test.com";

        if (schema.Properties.ContainsKey("password"))
            schema.Properties["password"].Type = "String123!";
    }
}