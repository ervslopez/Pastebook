using PastebookApp.PastebookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookApp.Models
{
    public class ViewPostsModel
    {
        public UserModel user { get; set; }
        public List<CompletePost> postList;

        public ViewPostsModel()
        {
            postList = new List<CompletePost>();
        }
    }
}