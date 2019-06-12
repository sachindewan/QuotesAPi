using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Models;
using QuotesApi.Models.ApiResponse;

namespace QuotesApi.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        QuotesDbContext _quotesDbContext;
        public QuotesController(QuotesDbContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }
        // GET: api/Quotes
        [HttpGet]
        public ApiResponse Get(string sort)
        {
            IQueryable<Quote> quotes;
            switch (sort)
            {
                case "desc":
                    quotes = _quotesDbContext.Quotes.OrderByDescending(q => q.CreateTime);
                    break;
                case "asc":
                    quotes = _quotesDbContext.Quotes.OrderByDescending(q => q.CreateTime);
                    break;
                default:
                    quotes = _quotesDbContext.Quotes;
                    break;
            }
            return new ApiOkResponse(quotes);
        }

        // GET: api/Quotes/5
        [HttpGet("{id}", Name = "Get")]
        public ApiResponse Get(int id)
        {
            var model = _quotesDbContext.Quotes.Find(id);
            if (model != null)
            {
                return new ApiOkResponse(_quotesDbContext.Quotes.Find(id));
            }
            else
            {
                return new ApiNotFoundRequestResponse(StatusCodes.Status404NotFound, "record not found");
            }
        }
       [HttpGet("[action]/{x:allowedgods}")]
        public string Test(string x)
        {
            return x;
        }
        // POST: api/Quotes
        [HttpPost]
        public ApiResponse Post([FromBody] Quote quote)
        {
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
            return new ApiCreated201Response(StatusCodes.Status201Created, "record created sucessfully");
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public ApiResponse Put(int id, [FromBody] Quote quote)
        {
            var model = _quotesDbContext.Quotes.Find(id);
            if (model != null)
            {
                model.Author = quote.Author;
                model.Description = quote.Description;
                model.Title = quote.Title;
                model.Type = quote.Type;
                _quotesDbContext.SaveChanges();
                return new ApiOkResponse(StatusCodes.Status200OK);
            }
            return new ApiNotFoundRequestResponse(StatusCodes.Status404NotFound,"record not found");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            var model = _quotesDbContext.Quotes.Find(id);
            if (model != null) {
                _quotesDbContext.Remove(model);
                _quotesDbContext.SaveChanges();
                return new ApiOkResponse(StatusCodes.Status200OK);
            }
            else
            {
                return new ApiNotFoundRequestResponse(StatusCodes.Status404NotFound,"record not found");
            }
        }
    }
}
