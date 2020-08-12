using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;

namespace RealPortfolioWebsite.Models
{
    public class PortfolioModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "headline")]
        public string Headline { get; set; }

        [JsonProperty(PropertyName = "blobimg")]
        public string BlobImg { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        public string ModalId { get { return "#" + Modal; } }

        public string Modal { get { return Headline.Replace(' ', '_') + "Modal"; } }

        public string ModalLable { get { return Modal + "Lable"; } }
    }
}
