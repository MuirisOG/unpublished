using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umbraco.businesslogic;
using umbraco.interfaces;

namespace MyOrg.Admin.Sections
{


    /// <summary>
    /// Summary description for ApproveItApplication
    /// Note: This method of adding a section has been superceded
    ///       See here for more info: https://our.umbraco.org/forum/developers/extending-umbraco/56428-Adding-a-new-section-in-Umbraco-v7
    /// </summary>
    [Application("myorgadmin", "MyOrgAdmin", "icon-sience", 17)]
    public class MyOrgAdminSection : IApplication
    {
    }
}
