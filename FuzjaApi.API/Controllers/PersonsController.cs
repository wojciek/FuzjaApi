﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuzjaApi.DAL;
using FuzjaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FuzjaApi.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly FuzjaApiDbContext _dbcontext;

        public PersonsController(FuzjaApiDbContext context)
        {
            _dbcontext = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            try
            {
                return _dbcontext.Persons;
            }

            catch
            {
                throw;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
