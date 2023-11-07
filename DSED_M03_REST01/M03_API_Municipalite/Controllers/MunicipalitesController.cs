using M03_API_Municipalite.Models;
using M03_Svr_Municipalite;
using Microsoft.AspNetCore.Mvc;

namespace M03_API_Municipalite.Controllers
{
    [Route("api/Municipalite")]
    [ApiController]
    public class MunicipalitesController : ControllerBase
    {
        private ManipulationMunicipalites m_manipulationMunicipalites;

        public MunicipalitesController(ManipulationMunicipalites manipulationMunicipalites)
        {
            m_manipulationMunicipalites = manipulationMunicipalites;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<MunicipaliteModel>> Get()
        {
            return Ok(m_manipulationMunicipalites.ListerMunicipalites().Select(m => new MunicipaliteModel(m)).ToList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<MunicipaliteModel> Get(int id)
        {
            MunicipaliteModel municipalite = new MunicipaliteModel(m_manipulationMunicipalites.ObtenirMunicipalites(id));
            if (municipalite != null)
            {
                return Ok(municipalite);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] MunicipaliteModel p_municipalite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            m_manipulationMunicipalites.AjouterMunicipalite(p_municipalite.VersEntite());
            return CreatedAtAction(nameof(Get), new { id = p_municipalite.codeGeographique }, p_municipalite);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, [FromBody] MunicipaliteModel p_municipalite)
        {
            if (!ModelState.IsValid || p_municipalite.codeGeographique != id)
            {
                return BadRequest();
            }

            int index = m_manipulationMunicipalites.ListerMunicipalites().FindIndex(m => m.CodeGeographique == id);

            if (index < 0)
            {
                return NotFound();
            }

            m_manipulationMunicipalites.MAJMunicipalite(p_municipalite.VersEntite());

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            MunicipaliteModel municipalite = new MunicipaliteModel(m_manipulationMunicipalites.ListerMunicipalites().Where(m => m.CodeGeographique == id).SingleOrDefault());

            if (municipalite == null)
            {
                return NotFound();
            }

            m_manipulationMunicipalites.SupprimerMunicipalite(municipalite.codeGeographique);

            return NoContent();
        }
    }
}
