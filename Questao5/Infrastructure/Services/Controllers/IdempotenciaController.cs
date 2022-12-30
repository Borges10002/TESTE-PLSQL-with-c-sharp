using Microsoft.AspNetCore.Mvc;
using Questao5.Infrastructure.Idempotencia;
using Questao5.Infrastructure.Services.Models;

namespace Questao5.Infrastructure.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdempotenciaController
    {
        private readonly IIdempotenciaProvider idempotenciaProvider;
        private readonly IIdempotenciaRepository idempotenciaRepository;

        public IdempotenciaController(IIdempotenciaProvider idempotenciaProvider,
            IIdempotenciaRepository idempotenciaRepository)
        {
            this.idempotenciaProvider = idempotenciaProvider;
            this.idempotenciaRepository = idempotenciaRepository;
        }

        // Get api/<IdempotenciaController>
        [HttpGet]
        public async Task<IEnumerable<IdempotenciaConta>> Get()
        {
            return await idempotenciaProvider.Get();
        }

        // POST api/<IdempotenciaController>
        [HttpPost]
        public async Task Post([FromBody] IdempotenciaConta idempotencia)
        {
            await idempotenciaRepository.Create(idempotencia);
        }
    }
}

