using Microsoft.AspNetCore.Mvc;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using Questao5.Infrastructure.Conta;
using Questao5.Infrastructure.Movimento;
using Questao5.Infrastructure.Services.Models;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoControllerController : ControllerBase
    {
        private readonly IMovimentoProvider movimentoProvider;
        private readonly IMovimentoIdProvider movimentoIdProvider;
        private readonly IMovimentoRepository movimentoRepository;


        public MovimentoControllerController(IMovimentoProvider movimentoProvider,
            IMovimentoIdProvider movimentoIdProvider,
            IMovimentoRepository movimentoRepository)
        {
            this.movimentoProvider = movimentoProvider;
            this.movimentoIdProvider = movimentoIdProvider;
            this.movimentoRepository = movimentoRepository;
        }

        // Get api/<MovimentoController>
        [HttpGet]
        public async Task<IEnumerable<MovimentoConta>> Get()
        {
            return await movimentoProvider.Get("");
        }

        // Get api/<MovimentoController>
        [HttpGet("{id}")]
        public async Task<IEnumerable<MovimentoContaDisponive>> GetId(string id)
        {
            var result1 = await movimentoProvider.Get(id);

            if (result1.Count() > 0)
            {
                return await movimentoIdProvider.GetId(id);
            }
            else
            {
                throw new Exception("Conta não cadastrou ou inativo");
            }
        }

        // POST api/<MovimentoController>
        [HttpPost]
        public async Task Post([FromBody] MovimentoConta movimentoConta)
        {
            await movimentoRepository.Create(movimentoConta);
        }
    }
}