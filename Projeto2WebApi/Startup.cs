using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Projeto2WebApi.Services;

[assembly: OwinStartup(typeof(Projeto2WebApi.Startup))]

namespace Projeto2WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseCors(CorsOptions.AllowAll);


            AtivarGeracaoTokens(app);


            app.UseWebApi(config);
        }

        private void AtivarGeracaoTokens(IAppBuilder app)
        {

            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                TokenEndpointPath = new PathString("/token"),
                Provider = new ProviderDeTokensDeAcesso()
            };


        }
    }
}
