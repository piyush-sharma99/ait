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
    public class securesAPIController : ApiController
    {
        private projectContext db = new projectContext();

        // GET: api/securesAPI
        public IQueryable<secureDTO> GetSecures()
        {

            var secures = from b in db.secures
                                  select new secureDTO()
                                  {
                                      secID = b.secID,
                                      Name = b.Name,
                                      Date = b.Date,
                                      Topic = b.Topic,
                                      Details = b.Details
                                  };
            return secures;
        }

        // GET: api/securesAPI/5
        [ResponseType(typeof(secure))]
        public async Task<IHttpActionResult> GetSecure(int secID)
        {
            secure s = await db.secures.FindAsync(secID);

            if (s == null)
            {
                return NotFound();
            }

            secureDTO secure = new secureDTO
            {
                secID = s.secID,
                Name = s.Name,
                Date = s.Date,
                Topic = s.Topic,
                Details = s.Details

            };

            return Ok(secure);
        }

        // PUT: api/securesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsecure(int id, secure secure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != secure.secID)
            {
                return BadRequest();
            }

            db.Entry(secure).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!secureExists(id))
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

        // POST: api/securesAPI
        [ResponseType(typeof(secure))]
        public IHttpActionResult Postsecure(secure secure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.secures.Add(secure);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = secure.secID }, secure);
        }

        // DELETE: api/securesAPI/5
        [ResponseType(typeof(secure))]
        public IHttpActionResult Deletesecure(int id)
        {
            secure secure = db.secures.Find(id);
            if (secure == null)
            {
                return NotFound();
            }

            db.secures.Remove(secure);
            db.SaveChanges();

            return Ok(secure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool secureExists(int id)
        {
            return db.secures.Count(e => e.secID == id) > 0;
        }
    }
}