using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestePost.Model;

namespace TestePost.Controllers
{
    [ApiController]
    [Route("Teste")]
    public class ControllerPessoa : ControllerBase
    {


        [HttpGet]
        [Route("BuscarPessoa/{id}")]

        public string GetPessoa(int id)
        {

            Pessoa pessoa = new Pessoa();
            return pessoa.BuscarPessoa(id);
                   

        }

        [HttpGet]
        [Route("BuscarTodasPessoas")]

        public List<Pessoa> BuscaTodasPessoas()
        {
            
            return new Pessoa().listaPessoas();


        }

        [HttpPost]
        [Route("CadastrarPessoa")]
        public void Postpessoa([FromBody] Pessoa pes)
        {

            pes.CadastrarPessoa();

        }



    }
}
