using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public class PostDataAccess : BaseDataAccess
    {
        public int CreatePost(Post post)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.PB_POST.Add(PostMapper.ToPB_POST(post));
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public List<GetNewsfeed_Result> GetNewsfeed(int accountID)
        {
            List<GetNewsfeed_Result> newsfeed = new List<GetNewsfeed_Result>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    newsfeed = context.GetNewsfeed(accountID).Distinct().OrderByDescending(x => x.CREATED_DATE).ToList();
                    //var feeds = context.PB_POST.Include("PB_COMMENT.PB_USER").Include("PB_LIKE.PB_USER")
                    //    .Where(p=>p.POSTER_ID == accountID || p.PROFILE_OWNER_ID == accountID 
                    //    || p.POSTER_ID == context.PB_FRIEND.Where(f=>f.USER_ID == accountID 
                    //    && f.REQUEST == "N" && f.IsBLOCKED == "N").Select(f=>f.FRIEND_ID).SingleOrDefault()).ToList();
                    //var feeds = context.PB_USER.Include("PB_FRIEND.PB_POST.PB_COMMENT").Include("PB_FRIEND.PB_POST.PB_LIKE");

                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return newsfeed;
        }

        public List<GetNewsfeed_Result> GetAccountRelatedPosts(int accountID)
        {
            List<GetNewsfeed_Result> postList = new List<GetNewsfeed_Result>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    postList = PostMapper.ToNewsfeed(context.GetAccountRelatedPosts(accountID, 1).ToList());
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return postList;
        }

        public int LikePost(Like like)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.PB_LIKE.Add(LikeMapper.ToPB_LIKE(like));
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public List<GetPostLikes_Result> GetPostLikes(int postID)
        {
            List<GetPostLikes_Result> likersList = new List<GetPostLikes_Result>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    var likerslist = context.PB_USER
                        .Where(user => context.PB_LIKE.Any(like =>like.LIKED_BY == user.ID && like.POST_ID == postID))
                        .Select(x=> new GetPostLikes_Result { FIRST_NAME = x.FIRST_NAME, LAST_NAME = x.LAST_NAME})
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return likersList;
        }

        public int CommentOnPost(Comment comment)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    context.PB_COMMENT.Add(CommentMapper.ToPB_COMMENT(comment));
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }
        
        public List<GetPostComments_Result> GetPostComments(int postID)
        {
            List<GetPostComments_Result> commentsList = new List<GetPostComments_Result>();
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    commentsList = context.GetPostComments(postID).OrderByDescending(x => x.DATE_CREATED).ToList();
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

        public int GetPostOwnerID(int postID)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    result = context.PB_POST.Where(x => x.ID == postID).SingleOrDefault().POSTER_ID;
                }
            }
            catch (Exception ex)
            {
                listOfException.Add(ex);
            }
            return result;
        }

        public int getCommentID(int posterID, DateTime dateCreated)
        {
            int result = 0;
            try
            {
                using (var context = new DB_PASTEBOOKEntities())
                {
                    result = context.PB_COMMENT.Where(x => x.POSTER_ID == posterID && x.DATE_CREATED.CompareTo(dateCreated)>0)
                                                                                        .Select(x=>x.ID)                                    
                                                                                        .SingleOrDefault();
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