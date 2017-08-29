using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence;


/// <summary>
/// Summary description for Unpublished Documents matching the View in the database
/// </summary>
namespace MyOrg.Admin.Models
{

    [TableName("myorgCmsDocument_Unpublished")]
    [DataContract(Name = "unpublishedDoc", Namespace = "")]
    public class UnpublishedDoc
    {


        [DataMember(Name = "userName")]
        public string UserName { get; set; }

        [DataMember(Name = "nodeId")]
        public int NodeId { get; set; }

        [DataMember(Name = "published")]
        public bool Published { get; set; }

        [DataMember(Name = "documentUser")]
        public int DocumentUser { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }

        [DataMember(Name = "releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [DataMember(Name = "expireDate")]
        public DateTime ExpireDate { get; set; }

        [DataMember(Name = "updateDate")]
        public DateTime UpdateDate { get; set; }

        [DataMember(Name = "templateId")]
        public int TemplateId { get; set; }

        [DataMember(Name = "newest")]
        public bool Newest { get; set; }

    }
}
