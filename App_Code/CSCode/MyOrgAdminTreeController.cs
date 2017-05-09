using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;

using Umbraco.Core;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using MyOrg.Admin.UI.Data;
using MyOrg.Admin.UI.Controllers;


/// <summary>
/// Summary description for UnpublishedTreeController
/// </summary>
/// 

namespace MyOrg.Admin.UI.Trees
{
    //add treecontroller
    [Tree("myorgadmin", "unpublishedTree", "Content for Approval")]
    [PluginController("MyOrgAdmin")]
    public class UnpublishedTreeController : TreeController
    {


        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            //check if we're rendering the root node's children
            if (id == Constants.System.Root.ToInvariantString())
            {
                var ctrl = new UnpublishedApiController();
                var nodes = new TreeNodeCollection();

                foreach (var unpublisheddoc in ctrl.GetAll())
                {
                    var node = CreateTreeNode(unpublisheddoc.NodeId.ToString(), "-1", queryStrings, "(" + unpublisheddoc.NodeId.ToString() + ") " + unpublisheddoc.Text.ToString(), "icon-document-dashed-line", false);
                    
                    if (unpublisheddoc.Published)
                        node.Icon = "icon-document";

                    nodes.Add(node);

                }
                return nodes;
            }

            //this tree doesn't suport rendering more than 1 level
            throw new NotSupportedException();
        }



        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {

            var menu = new MenuItemCollection();
            var l = new MenuItem("reload", "Reload");
            l.Icon = "icon-refresh";
            menu.Items.Add(l);


            return menu;
        }
    }

}
