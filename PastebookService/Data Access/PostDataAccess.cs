using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public class PostDataAccess : BaseDataAccess
    {
        public int CreatePost(PostRequest request)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.PB_POST.Add(PostMapper.ToPB_POST(request.post));
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public List<Post> GetUserRelatedPosts(GetPostsRequest request)
        {
            List<Post> postList = new List<Post>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    var tblPosts = context.PB_POST.Where(x => x.PROFILE_OWNER_ID == request.accountID).ToList();

                    foreach (var item in tblPosts)
                    {
                        postList.Add(PostMapper.ToPost(item));
                    }
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return postList.OrderByDescending(x=>x.CREATED_DATE).ToList();
        }

        public List<Post> GetUserAndFriendsPosts(GetPostsRequest request)
        {
            List<Post> postList = new List<Post>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    var tblPosts = context.PB_POST.Where(x => x.PROFILE_OWNER_ID == request.accountID).ToList();

                    foreach (var item in tblPosts)
                    {
                        postList.Add(PostMapper.ToPost(item));
                    }
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return postList.OrderByDescending(x => x.CREATED_DATE).ToList();
        }

        public int LikePost(LikePostRequest request)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.PB_LIKE.Add(LikeMapper.ToPB_LIKE(request.like));
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public List<GetPostLikes_Result> GetPostLikes(GetPostLikesRequest request)
        {
            List<GetPostLikes_Result> likersList = new List<GetPostLikes_Result>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    likersList = context.GetPostLikes(request.POST_ID).ToList();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return likersList;
        }

        public int CommentOnPost(CommentOnPostRequest request)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.PB_COMMENT.Add(CommentMapper.ToPB_COMMENT(request.comment));
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }
        
        public List<GetPostComments_Result> GetPostComments(GetPostLikesRequest request)
        {
            List<GetPostComments_Result> commentsList = new List<GetPostComments_Result>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    commentsList = context.GetPostComments(request.POST_ID).ToList();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return commentsList;
        }

        public bool PostExists(int ID)
        {
            bool result = false;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    result = context.PB_POST.Any(x => x.ID == ID);
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public bool CheckIfPostIsLikedAlready(int postID, int userID)
        {
            bool result = false;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    result = context.PB_LIKE.Any(x => x.POST_ID == postID && x.LIKED_BY == userID);
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }
    }
}