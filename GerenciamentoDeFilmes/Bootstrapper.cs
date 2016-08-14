namespace GerenciamentoDeFilmes
{
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper


        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {

            pipelines.AfterRequest += ctx =>
            {

                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*");
                ctx.Response.WithHeader("Access-Control-Allow-Headers", "accept, client-token, content-type");
                ctx.Response.WithHeader("Access-Control-Allow-Methods", "POST,GET,PUT,DELETE");
                ctx.Response.WithHeader("Access-Control-Max-Age", "30758400");
            };
        }
    }
}