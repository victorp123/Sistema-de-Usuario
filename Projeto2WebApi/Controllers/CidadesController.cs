using Projeto2WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Projeto2WebApi.Controllers
{
    public class CidadesController : ApiController
    {

        private meuBanco db = new meuBanco();

        public IQueryable<Cidade> GetCidades()
        {
            return db.cidades;
        }

        public IQueryable<Cidade> GetCidades(string nome_cidade)
        {
            //linq
            var cidades = from c in db.cidades
                          where c.nome_cidade.Contains(nome_cidade) select c;

            return cidades;
            // Expressão lambda //return db.cidades.Where(c => c.nome_cidade.Contains(nome_cidade));
        }

        [ResponseType(typeof(Cidade))]
        public async Task<IHttpActionResult> GetCidade(int id)
        {
            Cidade cidade = await db.cidades.FindAsync(id);

            if(cidade == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cidade);
            }
        }


        // Metodo para alterar os dados
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCidade(int id, Cidade cidade)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != cidade.cod_cidade)
            {
                return BadRequest(ModelState);
            }

            //Vai validar o objeto passado e verificar no banco de dados, se o objeto tem valores diferentes, se tiver alterados, vai realizar o UPDATE
            db.Entry(cidade).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception error)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // Metodo para incluir os dados
        [ResponseType(typeof(Cidade))]
        public async Task<IHttpActionResult> PostCidade(Cidade cidade)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cidades.Add(cidade);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception error)
            {
                throw;
            }

            return CreatedAtRoute("DefaultApi", new {id = cidade.cod_cidade}, cidade);
        }


        //Excluindo os dados
        [ResponseType(typeof(Cidade))]
        public async Task<IHttpActionResult> deleteCidade(int id)
        {
            Cidade cidade = await db.cidades.FindAsync(id);

            if (cidade == null)
            {
                return NotFound();
            }

            db.cidades.Remove(cidade);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception error)
            {
                throw;
            }

            return Ok(cidade);

        }

    }
}
