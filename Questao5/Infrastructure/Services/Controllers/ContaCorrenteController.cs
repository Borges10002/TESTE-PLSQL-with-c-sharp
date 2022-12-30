using Microsoft.AspNetCore.Mvc;
using Questao5.Infrastructure.Conta;
using Questao5.Infrastructure.Services.Models;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteProvider contaCorrenteProvider;
        private readonly IContaCorrenteRepository contaCorrenteRepository;

        public ContaCorrenteController(IContaCorrenteProvider contaCorrenteProvider,
            IContaCorrenteRepository contaCorrenteRepository)
        {
            this.contaCorrenteProvider = contaCorrenteProvider;
            this.contaCorrenteRepository = contaCorrenteRepository;
        }

        // Get api/<ContaCorrenteController>
        [HttpGet]
        public async Task<IEnumerable<ContaCorrente>> Get()
        {
            try
            {
                return await contaCorrenteProvider.Get();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        // POST api/<ContaCorrenteController>
        [HttpPost]
        public async Task Post([FromBody] ContaCorrente contaCorrente)
        {
            try
            {
                await contaCorrenteRepository.Create(contaCorrente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }



    }
}