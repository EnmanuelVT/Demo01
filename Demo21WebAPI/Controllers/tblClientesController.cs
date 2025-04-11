using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Demo21WebAPI.Models;

namespace Demo21WebAPI.Controllers
{
    public class tblClientesController : ApiController
    {
        private MyDataEntities db = new MyDataEntities();

        // GET: api/tblClientes
        public IQueryable<tblCliente> GettblClientes()
        {
            return db.tblClientes;
        }

        // GET: api/tblClientes/5
        [ResponseType(typeof(tblCliente))]
        public IHttpActionResult GettblCliente(int id)
        {
            tblCliente tblCliente = db.tblClientes.Find(id);
            if (tblCliente == null)
            {
                return NotFound();
            }

            return Ok(tblCliente);
        }

        // PUT: api/tblClientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblCliente(int id, tblCliente tblCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCliente.Id)
            {
                return BadRequest();
            }

            db.Entry(tblCliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblClienteExists(id))
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

        // POST: api/tblClientes
        [ResponseType(typeof(tblCliente))]
        public IHttpActionResult PosttblCliente(tblCliente tblCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblClientes.Add(tblCliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblCliente.Id }, tblCliente);
        }

        // DELETE: api/tblClientes/5
        [ResponseType(typeof(tblCliente))]
        public IHttpActionResult DeletetblCliente(int id)
        {
            tblCliente tblCliente = db.tblClientes.Find(id);
            if (tblCliente == null)
            {
                return NotFound();
            }

            db.tblClientes.Remove(tblCliente);
            db.SaveChanges();

            return Ok(tblCliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblClienteExists(int id)
        {
            return db.tblClientes.Count(e => e.Id == id) > 0;
        }
    }
}