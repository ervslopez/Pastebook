using PastebookApp.PastebookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookApp.Models
{
    public class PostModel
    {
        public List<CompletePost> post;

        public PostModel()
        {
            post = new List<CompletePost>();
        }
    }
}