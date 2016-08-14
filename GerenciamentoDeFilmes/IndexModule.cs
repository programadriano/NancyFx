namespace GerenciamentoDeFilmes
{
    using Model;
    using Nancy;
    using Nancy.ModelBinding;
    using System.Data.Entity;
    using System.Linq;

    public class IndexModule : NancyModule
    {
        private Locadora _contexto = new Locadora();

        public IndexModule() : base("/filme")
        {
            Get["/"] = x =>
            {
                var filmes = _contexto.Filmes.ToList();

                return Response.AsJson(filmes);

            };

            Get["/{id:int}"] = parameters =>
            {
                int id = parameters.id;

                var filmes = _contexto.Filmes.FirstOrDefault(x => x.Id == id);

                return Response.AsJson(filmes);
            };

            Post["/"] = _ =>
            {
                var filme = this.Bind<Filmes>();
                _contexto.Filmes.Add(filme);
                _contexto.SaveChanges();

                return HttpStatusCode.OK;
            };

            Put["/{id:int}"] = parameters =>
            {
                Filmes filme = this.Bind<Filmes>();
                filme.Id = parameters.id;

                _contexto.Entry(filme).State = EntityState.Modified;
                _contexto.SaveChanges();

                return HttpStatusCode.OK;
            };

            Delete["/{id:int}"] = x =>
            {
                Filmes filme = this.Bind<Filmes>();
                filme.Id = x.id;

                _contexto.Entry(filme).State = EntityState.Deleted;
                _contexto.SaveChanges();

                return HttpStatusCode.OK;
            };

          

        }
    }
}