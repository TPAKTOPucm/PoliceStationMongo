using Microsoft.AspNetCore.Mvc;
using PoliceStationMongo.Models;
using PoliceStationMongo.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PoliceStationMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceController : ControllerBase
    {
        private readonly IPolicemanRepository _repository;
        public PoliceController(IPolicemanRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<PoliceController>
        [HttpGet]
        public async Task<ICollection<Policeman>> Get(string? id = null, string? firstName = null, string? lastName = null)
        {
            if (id != null)
            {
                var list = new List<Policeman>(1);
                list.Add(_repository.GetPoliceman(id).Result);
                return list;
            }
            if(firstName != null)
                return await _repository.GetPolicemen(firstName, lastName);
            return await _repository.GetPolicemen();
        }

        // POST api/<PoliceController>
        [HttpPost]
        public async Task Post([FromBody] Policeman policeman)
        {
            await _repository.AddPoliceman(policeman);
        }

        // PUT api/<PoliceController>/5
        [HttpPut]
        public async Task Put([FromBody] Policeman policeman)
        {
            await _repository.UpdatePoliceman(policeman);
        }

        // DELETE api/<PoliceController>/5
        [HttpDelete]
        public async Task<Policeman> Delete(string id)
        {
            return await _repository.DeletePoliceman(id);
        }
    }
}
