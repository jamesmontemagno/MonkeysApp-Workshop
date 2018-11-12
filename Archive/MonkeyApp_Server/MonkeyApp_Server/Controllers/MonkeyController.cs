using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using MonkeyAppServer.DataObjects;
using MonkeyAppServer.Models;

namespace MonkeyAppServer.Controllers
{
    public class MonkeyController : TableController<Monkey>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            monkeyapp5Context context = new monkeyapp5Context();
            DomainManager = new EntityDomainManager<Monkey>(context, Request);
        }

        // GET tables/Monkey
        public IQueryable<Monkey> GetAllMonkey()
        {
            return Query(); 
        }

        // GET tables/Monkey/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Monkey> GetMonkey(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Monkey/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public async Task<Monkey> PatchMonkey(string id, Delta<Monkey> patch)
        {
            return patch.GetEntity();
            // return UpdateAsync(id, patch);
        }

        // POST tables/Monkey
        public async Task<IHttpActionResult> PostMonkey(Monkey item)
        {
            item.Image = "http://refractored.com/images/monkey_place.jpg";
            Monkey current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Monkey/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMonkey(string id)
        {
            return null;
             //return DeleteAsync(id);
        }

    }
}