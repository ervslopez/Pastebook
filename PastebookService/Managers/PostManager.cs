using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public class PostManager
    {
        PostDataAccess postDataAccess = new PostDataAccess();
        AccountDataAccess accountDataAccess = new AccountDataAccess();

        //  "POST" SERVICES
        public StatusResponse CreatePost(PostRequest request)
        {
            StatusResponse resp = new StatusResponse();
            try
            {
                if (accountDataAccess.UserIDExists(request.post.PROFILE_OWNER_ID)
                    && accountDataAccess.UserIDExists(request.post.PROFILE_OWNER_ID))
                {
                    request.post.CREATED_DATE = DateTime.Now;
                    resp.Status = postDataAccess.CreatePost(request) > 0 ? true : false;
                }
                else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public GetPostListResponse GetUserRelatedPosts(GetPostsRequest request)
        {
            GetPostListResponse resp = new GetPostListResponse();
            try
            {
                if (accountDataAccess.UserIDExists(request.accountID))
                {
                    resp.postList = postDataAccess.GetUserRelatedPosts(request);
                }
                else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        //  "LIKE" SERVICES
        public StatusResponse LikePost(LikePostRequest request)
        {
            StatusResponse resp = new StatusResponse();
            try
            {
                if (postDataAccess.PostExists(request.like.POST_ID) && !PostLiked(request.like.POST_ID, request.like.LIKED_BY))
                {
                    resp.Status = postDataAccess.LikePost(request) > 0 ? true : false;
                }
                else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public GetPostLikesResponse GetPostLikes(GetPostLikesRequest request)
        {
            GetPostLikesResponse resp = new GetPostLikesResponse();
            try
            {
                if (postDataAccess.PostExists(request.POST_ID))
                {
                    resp.likeList = postDataAccess.GetPostLikes(request);
                }
                else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        //  "COMMENT" SERVICES
        public StatusResponse CommentOnPost(CommentOnPostRequest request)
        {
            StatusResponse resp = new StatusResponse();
            try
            {
                if (postDataAccess.PostExists(request.comment.POST_ID))
                {
                    request.comment.DATE_CREATED = DateTime.Now;
                    resp.Status = postDataAccess.CommentOnPost(request) > 0 ? true : false;
                }
                else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public GetPostCommentsResponse GetPostComments(GetPostLikesRequest request)
        {
            GetPostCommentsResponse resp = new GetPostCommentsResponse();
            try
            {
                if (postDataAccess.PostExists(request.POST_ID))
                {
                    resp.commentsList = postDataAccess.GetPostComments(request);
                }
                else
                {
                    resp.Status = false;
                }
            }
            catch (Exception e)
            {
                resp.errorList.Add(e.ToString());
            }
            return resp;
        }

        public bool PostLiked(int postID, int userID)
        {
            return postDataAccess.CheckIfPostIsLikedAlready(postID, userID);
        }
    }
}