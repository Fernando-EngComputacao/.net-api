using System.Reflection;
using DoctorAPI.Assets.Security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DoctorAPI.core;

public class SwaggerString : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Verifique se o controlador ou a ação possui o atributo RequireAuthentication
        var hasRequiredAttribute = context.MethodInfo.DeclaringType!.GetCustomAttributes<RequireAuthenticationAttribute>().Any() ||
                                   context.MethodInfo.GetCustomAttributes<RequireAuthenticationAttribute>().Any();

        if (hasRequiredAttribute)
        {
            // Adicione uma descrição ou qualquer outra formatação que você deseja para identificar que a autenticação é necessária
            operation.Summary += " + 🔒 Autenticação Requerida";
        }
    }
}
