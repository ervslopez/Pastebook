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
        NotificationManager notificationManager = new NotificationManager();

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

        public GetAccountProfileResponse GetAccountProfile(GetAccountProfileRequest request)
        {
            return accountManager.GetAccountProfile(request);
        }

        public StatusResponse ConfirmOldPassword(ConfirmOldPasswordRequest request)
        {
            return new StatusResponse()
            {
                Status = accountManager.ConfirmOldPassword(request.userID, request.oldPassword)
            };
        }

        public SearchUsersResponse SearchUsers(SearchUsersRequest request)
        {
            SearchUsersResponse resp = new SearchUsersResponse();
            resp.userList = accountManager.SearchUsers(request.name);
            return resp;
        }

        //Post Related Services
        PostManager postManager = new PostManager();

        public StatusResponse CreatePost(PostRequest request)
        {
            return postManager.CreatePost(request);
        }

        public GetPostListResponse GetNewsfeed(GetPostsRequest request)
        {
            return postManager.GetNewsfeed(request);
        }

        public GetPostListResponse GetAccountRelatedPosts(GetPostsRequest request)
        {
            return postManager.GetAccountRelatedPosts(request);
        }

        public GetPostResponse GetPost(GetPostRequest request)
        {
            return postManager.GetPost(request);
        }
        //Like Related Services

        public StatusResponse LikePost(LikePostRequest request)
        {
            StatusResponse stat = postManager.LikePost(request);
            if (stat.Status && stat.errorList.Count == 0)
            {
                int postOwnerID = postManager.GetPostOwnerID(request.like.POST_ID);
                if (postOwnerID != request.like.LIKED_BY)
                {
                    if (!notificationManager.LikeNotification(request.like.POST_ID, request.like.LIKED_BY, postOwnerID))
                    {
                        stat.errorList.Add("Like Notification Failed To Send");
                    }
                }                
            }
            return stat;
        }

        //Comment Related Services

        public CommentOnPostResponse CommentOnPost(CommentOnPostRequest request)
        {
            CommentOnPostResponse stat = postManager.CommentOnPost(request);
            if (stat.Status && stat.errorList.Count == 0)
            {
                int postOwnerID = postManager.GetPostOwnerID(request.comment.POST_ID);
                if (postOwnerID != request.comment.POSTER_ID)
                {
                    if (!notificationManager.CommentNotification(request.comment.POST_ID,
                                                            request.comment.POSTER_ID,
                                                            postOwnerID,
                                                            postManager.getCommentID(request.comment.POSTER_ID,
                                                            stat.commentDateTime)))
                    {
                        stat.errorList.Add("Comment Notification Failed To Send");
                    }
                }
            }
            return stat;
        }

        //Friend Related Services

        FriendManager friendManager = new FriendManager();
        public FriendResponse RequestFriendship(FriendRequest request)
        {
            FriendResponse stat = friendManager.RequestFriendship(request);
            if (stat.Status && stat.errorList.Count == 0)
            {
                if (!notificationManager.FriendNotification(request.friend.USER_ID, request.friend.FRIEND_ID))
                {
                    stat.errorList.Add("Friend Notification Failed To Send");
                }
            }
            return stat;
        }

        public FriendResponse AcceptFriendship(FriendRequest request)
        {
            return friendManager.AcceptFriendship(request);
        }

        public FriendResponse DeclineFriendship(FriendRequest request)
        {
            return friendManager.DeclineFriendship(request);
        }

        public FriendResponse BlockAccount(FriendRequest request)
        {
            return friendManager.BlockAccount(request);
        }

        public ViewFriendsListResponse ViewFriendsList(ViewFriendsListRequest request)
        {
            return friendManager.ViewFriendsList(request);
        }

        public GetFriendshipStatusResponse GetFriendshipStatus(FriendRequest request)
        {
            return friendManager.GetFriendshipStatus(request);
        }

        //Notification Related Services

        public GetAllNotificationsResponse GetAllNotifications(GetAllNotificationsRequest request)
        {
            return notificationManager.GetRecentNotifications(request.userID);
        }

        public GetNotificationCountResponse GetNotificationCount(GetAllNotificationsRequest request)
        {
            return new GetNotificationCountResponse() { count = notificationManager.GetNotifCount(request.userID) };
        }

        //Utilities

        public GetCountriesResponse GetCountries()
        {
            return accountManager.GetCountries();
        }

        public EditUserResponse UpdateUserPassword(UserRequest request)
        {
            return accountManager.UpdateUserPassword(request);
        }
    }
}
