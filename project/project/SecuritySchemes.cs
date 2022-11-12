using Microsoft.OpenApi.Models;

namespace project
{
    internal static class SecuritySchemes
    {
        public static OpenApiSecurityScheme BearerScheme(IConfiguration config) => new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.OAuth2,
            Description = "Standard authorisation using the Bearer scheme. Example: \"bearer {token}\"",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Scheme = "Bearer",
            OpenIdConnectUrl = new System.Uri($"{config["TokenServerUrl"]}.well-known/openid-configuration"),
            BearerFormat = "JWT",
            
        };

        public static OpenApiSecurityScheme OAuthScheme => new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

        };
    }
}
