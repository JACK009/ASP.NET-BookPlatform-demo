using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BookPlatform.Context;
using BookPlatform.Models;
using BookPlatform.Models.Api;
using BookPlatform.Repositories;

namespace BookPlatform.Controllers.Api
{
    public class AuthorsController : ApiController
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new BookContext());

        // GET: api/Authors
        [EnableCors("*", "*", "*")]
        public IEnumerable<AuthorDto> GetAuthors()
        {
            return _unitOfWork.Authors.GetAuthorsDto();
        }

        // GET: api/Authors/5
        [EnableCors("*", "*", "*")]
        [ResponseType(typeof(AuthorDto))]
        public IHttpActionResult GetAuthor(int id)
        {            
            AuthorDto author = _unitOfWork.Authors.GetAuthorDto(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [EnableCors("*", "*", "*")]
        [ResponseType(typeof(AuthorDto))]
        public IHttpActionResult GetAuthor(string name)
        {
            IEnumerable<AuthorDto> authors = _unitOfWork.Authors.GetAuthorDtoByNameWithLimit(name, 5);

            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }

        // PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAuthor(int id, Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Authors.Add(author);            

            try
            {
                _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
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

        // POST: api/Authors
        [ResponseType(typeof(Author))]
        public IHttpActionResult PostAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.Authors.Add(author);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
        }

        // DELETE: api/Authors/5
        [ResponseType(typeof(Author))]
        public IHttpActionResult DeleteAuthor(int id)
        {

            Author author = _unitOfWork.Authors.Get(id);
            if (author == null)
            {
                return NotFound();
            }

            _unitOfWork.Authors.Remove(author);
            _unitOfWork.Complete();

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AuthorExists(int id)
        {
            return null != _unitOfWork.Authors.Find(e => e.Id == id);
        }
    }
}