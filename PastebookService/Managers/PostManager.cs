using PastebookModel;
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
                    resp.Status = true;
                    foreach (var item in postDataAccess.GetNewsfeed(request.accountID))
                    {
                        resp.postList.Add(new CompletePost()
                        {
                            post = item,
                            comments = GetPostComments(item.ID),
                            likes = GetPostLikes(item.ID)
                        });
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

        public GetPostListResponse GetAccountRelatedPosts(GetPostsRequest request)
        {
            GetPostListResponse resp = new GetPostListResponse();
            try
            {
                if (accountDataAccess.UserIDExists(request.accountID))
                {
                    foreach (var item in postDataAccess.GetAccountRelatedPosts(request.accountID))
                    {
                        resp.postList.Add(new CompletePost()
                        {
                            post = item,
                            comments = GetPostComments(item.ID),
                            likes = GetPostLikes(item.ID)
                        });
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

        public List<GetPostLikes_Result> GetPostLikes(int ID)
        {     
            return postDataAccess.GetPostLikes(ID); 
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
                    if (postDataAccess.CommentOnPost(request.comment) > 0)
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

        public List<GetPostComments_Result> GetPostComments(int ID)
        {
            return postDataAccess.GetPostComments(ID);
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