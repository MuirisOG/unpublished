using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.Editors;
using Umbraco.Core.Models;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Persistence;
using MyOrg.Admin.Models;



namespace MyOrg.Admin.Controllers
{
    /// <summary>
    /// Summary description for UnpublishedApiController
    /// </summary>
    [PluginController("MyOrgAdmin")]
    public class UnpublishedApiController : UmbracoAuthorizedJsonController
    {
        public IList<IContent> UnpublishedContent { get; set; }
        public IList<IContent> descendantsOfMyPage { get; set; }

        //public IEnumerable<IContent> GetAll(IUser user)
        //to do: define the tree structure as some content may have an unpublished parent
        public IEnumerable<UnpublishedDoc> GetAll()
        {

            //var db = UmbracoContext.Application.DatabaseContext.Database;
            var db = ApplicationContext.DatabaseContext.Database;
            var query = new Sql().Select("*").From("myorgCmsDocument_Unpublished").OrderBy("nodeId");

            return db.Fetch<UnpublishedDoc>(query);

        }


        public IContent GetById(int id)
        {
            IContent content = ApplicationContext.Services.ContentService.GetById(id);
            return content;
        }

        public String GetUserById(int id)
        {
            IUser umbUser = ApplicationContext.Services.UserService.GetUserById(GetById(id).WriterId);
            string userName = umbUser.Name;
            return userName;
        }

        public IContent PostPublish(int id)
        {
            IContent node = ApplicationContext.Services.ContentService.GetById(id);
            ApplicationContext.Services.ContentService.Publish(node);

            return node;
        }

    }

}
