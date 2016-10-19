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
                    && accountDataAccess.UserIDExists(request.post.POSTER_ID))
                {
                    request.post.CREATED_DATE = DateTime.Now;
                    resp.Status = postDataAccess.CreatePost(request.post) > 0 ? true : false;
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

        public GetPostListResponse GetNewsfeed(GetPostsRequest request)
        {
            GetPostListResponse resp = new GetPostListResponse();
            try
            {
                if (accountDataAccess.UserIDExists(request.accountID))
                {
                    resp.postList = postDataAccess.GetNewsfeed(request.accountID, request.StartRange);
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

        public GetPostListResponse GetAccountRelatedPosts(GetPostsRequest request)
        {
            GetPostListResponse resp = new GetPostListResponse();
            try
            {
                if (accountDataAccess.UserIDExists(request.accountID))
                {
                    resp.postList = PostMapper.toGetNewsfeed_Result(postDataAccess
                        .GetAccountRelatedPosts(request.accountID, request.StartRange).ToList());
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
                    resp.Status = postDataAccess.LikePost(request.like) > 0 ? true : false;
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
                    resp.likeList = postDataAccess.GetPostLikes(request.POST_ID);
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
        public CommentOnPostResponse CommentOnPost(CommentOnPostRequest request)
        {
            CommentOnPostResponse resp = new CommentOnPostResponse();
            try
            {
                if (postDataAccess.PostExists(request.comment.POST_ID))
                {
                    resp.commentDateTime = request.comment.DATE_CREATED = DateTime.Now;
                    if(postDataAccess.CommentOnPost(request.comment)>0)
                    {
                        resp.Status = true;
                    }
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
                    resp.commentsList = postDataAccess.GetPostComments(request.POST_ID);
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

        public int GetPostOwnerID(int postID)
        {
            return postDataAccess.GetPostOwnerID(postID);
        }

        public int getCommentID(int posterID, DateTime dateCreated)
        {
            return postDataAccess.getCommentID(posterID, dateCreated);
        }

        public bool PostLiked(int postID, int userID)
        {
            return postDataAccess.CheckIfPostIsLikedAlready(postID, userID);
        }
    }
}