using PastebookApp.PastebookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookApp.Models
{
    public class PostModel
    {
        public GetNewsfeed_Result post { get; set; }
        public List<GetPostComments_Result> comments { get; set; }
        public List<GetPostLikes_Result> likes { get; set; }
    }
}