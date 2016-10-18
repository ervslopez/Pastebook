using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PastebookService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //User Account Related Services
        AccountManager accountManager = new AccountManager();

        public CreateUserResponse CreateUserAccount(UserRequest request)
        {
            return accountManager.CreateUserAccount(request);
        }

        public LoginResponse LoginUserAccount(LoginRequest request)
        {
            return accountManager.LoginUserAccount(request);
        }

        public EditUserResponse EditUserProfile(UserRequest request)
        {
            return accountManager.UpdateUserAccount(request);
        }

        public EditUserResponse EditUserPasswordOrEmail(EditPasswordOrEmailRequest request)
        {
            return accountManager.UpdatePasswordOrEmail(request); 
        }

        //Post Related Services
        PostManager postManager = new PostManager();

        public StatusResponse CreatePost(PostRequest request)
        {
            return postManager.CreatePost(request);
        }

        public GetPostListResponse GetUserRelatedPosts(GetPostsRequest request)
        {
            GetPostListResponse resp = new GetPostListResponse();
            resp =  postManager.GetUserRelatedPosts(request);

            foreach (var item in resp.postList)
            {
                resp.completePostList.Add(new CompletePost() {
                    post = item,
                    commentsList = GetPostComments(new GetPostLikesRequest() {
                        POST_ID = item.ID
                    }).commentsList,
                    likeList = GetPostLikes(new GetPostLikesRequest()
                    {
                        POST_ID = item.ID
                    }).likeList
                });
            }
            return resp;
        }

        public GetPostListResponse GetUserAndFriendsPosts(GetPostsRequest request)
        {
            //GetPostListResponse resp = new GetPostListResponse();
            //resp = postManager.GetUserRelatedPosts(request);

            //foreach (var item in resp.postList)
            //{
            //    resp.completePostList.Add(new CompletePost()
            //    {
            //        post = item,
            //        commentsList = GetPostComments(new GetPostLikesRequest()
            //        {
            //            POST_ID = item.ID
            //        }).commentsList,
            //        likeList = GetPostLikes(new GetPostLikesRequest()
            //        {
            //            POST_ID = item.ID
            //        }).likeList
            //    });
            //}
            //return resp;
            throw new NotImplementedException();
        }
        
        //Like Related Services

        public StatusResponse LikePost(LikePostRequest request)
        {
            return postManager.LikePost(request);
        }

        public GetPostLikesResponse GetPostLikes(GetPostLikesRequest request)
        {
            return postManager.GetPostLikes(request);
        }

        //Comment Related Services

        public StatusResponse CommentOnPost(CommentOnPostRequest request)
        {
            return postManager.CommentOnPost(request);
        }

        public GetPostCommentsResponse GetPostComments(GetPostLikesRequest request)
        {
            return postManager.GetPostComments(request);
        }

        //Friend Related Services
        FriendManager friendManager = new FriendManager();
        public FriendResponse RequestFriendship(FriendRequest request)
        {
            return friendManager.RequestFriendship(request);
        }

        public FriendResponse AcceptFriendship(FriendRequest request)
        {
            return friendManager.AcceptFriendship(request);
        }

        public FriendResponse BlockAccount(FriendRequest request)
        {
            return friendManager.BlockAccount(request);
        }

        public ViewFriendsListResponse ViewFriendsList(ViewFriendsListRequest request)
        {
            return friendManager.ViewFriendsList(request);
        }
    }
}
