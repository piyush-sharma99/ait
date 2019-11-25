using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Project.Models;

namespace Project.Controllers.WebAPI
{
    public class vulnerabilitiesAPIController : ApiController
    {
        private projectContext db = new projectContext();

        // GET: api/vulnerabilitiesAPI
        public IQueryable<vulnerabilityDTO> Getvulnerabilities()
        {

            var vul = from b in db.vulnerabilities
                        select new vulnerabilityDTO()
                        {
                            vulID = b.vulID,
                            Name = b.Name,
                            Date = b.Date,
                            Topic = b.Topic,
                            Details = b.Details
                           
                        };
            return vul;
        }

        // GET: api/vulnerabilitiesAPI/5
        [ResponseType(typeof(vulnerabilityDTO))]
        public async Task<IHttpActionResult> Getvulnerability(int vulID)
        {
            vulnerability v = await db.vulnerabilities.FindAsync(vulID);



            vulnerabilityDTO vulnerability = new vulnerabilityDTO
            {

                Name = v.Name,
                Date = v.Date,
                Topic = v.Topic,
                Details = v.Details
               

            };
            if (v == null)
            {
                return NotFound();
                

            }

            return Ok(vulnerability);
        }

        // PUT: api/vulnerabilitiesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putvulnerability(int id, vulnerability vulnerability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vulnerability.vulID)
            {
                return BadRequest();
            }

            db.Entry(vulnerability).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vulnerabilityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/vulnerabilitiesAPI
        [ResponseType(typeof(vulnerability))]
        public IHttpActionResult Postvulnerability(vulnerability vulnerability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.vulnerabilities.Add(vulnerability);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vulnerability.vulID }, vulnerability);
        }

       

        // DELETE: api/vulnerabilitiesAPI/5
        [ResponseType(typeof(vulnerability))]
        public IHttpActionResult Deletevulnerability(int id)
        {
            vulnerability vulnerability = db.vulnerabilities.Find(id);
            if (vulnerability == null)
            {
                return NotFound();
            }

            db.vulnerabilities.Remove(vulnerability);
            db.SaveChanges();

            return Ok(vulnerability);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vulnerabilityExists(int id)
        {
            return db.vulnerabilities.Count(e => e.vulID == id) > 0;
        }
    }
}