using PastebookApp.Models;
using PastebookApp.PastebookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookApp.Managers
{
    public class PostManager
    {
        Service1Client service = new Service1Client();
        static int endRange = 1;

        public List<PostModel> GetNewsfeed(int accountID)
        {
            List<PostModel> model = new List<PostModel>();
            PostModel currentPost;
            //Gets post details 
            GetPostListResponse resp = service.GetNewsfeed(new GetPostsRequest() {
                accountID = accountID,
                StartRange = endRange += 10
            });
            
            //Populates the model with posts (without commments and likes yet)
            if(resp.Status && resp.errorList.Count() == 0)
            {
                foreach (var item in resp.postList.ToList())
                {
                    currentPost = new PostModel();
                    currentPost.post = item;

                    GetPostCommentsResponse commentsResp = service.GetPostComments(new GetPostLikesRequest() { POST_ID = item.ID});

                    model.Add(currentPost);
                }
            }
            return model;
        }
    }
}