using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;
using WebAPICRUDCodeFirstEF.DataContext;
using WebAPICRUDCodeFirstEF.Models;

namespace WebAPICRUDCodeFirstEF.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            using (ApplicationDBContext context=new ApplicationDBContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, context.Persons.ToList());
            }
        }
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                var emp = context.Persons.FirstOrDefault(e=>e.Id==id);
                if(emp!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Emp id is not found with " +id);
                }
            }
        }
        [HttpPost]
        public HttpResponseMessage Post(Person model)
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                if(model!=null)
                {
                    context.Persons.Add(model);
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,"Provide the Input Data");
                }
            }
        }
        [HttpPut]
        public HttpResponseMessage Put(int id, Person model)
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                var emp = context.Persons.FirstOrDefault(e => e.Id == id);
                if(emp!=null)
                {
                    emp.Gender = model.Gender;
                    emp.Name = model.Name;
                    emp.City = model.City;
                    emp.IsActive = model.IsActive;
                    emp.PhoneNo = model.PhoneNo;
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,"Employee with " + id + " not found in the database");
                }
            }
        }
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                var emp = context.Persons.FirstOrDefault(e => e.Id == id);
                if(emp!=null)
                {
                    context.Persons.Remove(emp);
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with " + id + " not found in the database");
                }
            }
        }
    }
}
