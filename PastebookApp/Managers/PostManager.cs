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
        //static int endRange = 1;

        public List<CompletePost> GetNewsfeed(int accountID)
        {
            List<CompletePost> model = new List<CompletePost>();

            GetPostListResponse resp = service.GetNewsfeed(new GetPostsRequest() {
                accountID = accountID
            });

            if(resp.Status && resp.errorList.ToList().Count == 0)
            {
                model = resp.postList.ToList();
            }
            return model;
        }

        public bool PublishNewPost(int id, string post)
        {
            return service.CreatePost(new PostRequest() {
                post = new Post() {
                    POSTER_ID = id,
                    PROFILE_OWNER_ID = id,
                    CONTENT = post
                }
            }).Status;
        }

        public bool CommentOnPost(int posterID, int postID, string comment)
        {
            return service.CommentOnPost(new CommentOnPostRequest()
            {
                comment = new Comment()
                {
                    POSTER_ID = posterID,
                    POST_ID = postID,
                    CONTENT =comment
                }
            }).Status;
        }

        public bool LikePost(int postID, int likedBy)
        {
            return service.LikePost(new LikePostRequest()
            {
                like = new Like() {
                    POST_ID = postID,
                    LIKED_BY = likedBy
                }
            }).Status;
        }
    }
}