using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PastebookService
{
    [ServiceContract]
    public interface IService1
    {
        //User Account Related Services
        [OperationContract]
        CreateUserResponse CreateUserAccount(UserRequest request);

        [OperationContract]
        LoginResponse LoginUserAccount(LoginRequest request);

        [OperationContract]
        EditUserResponse EditUserProfile(UserRequest request);

        [OperationContract]
        EditUserResponse EditUserPasswordOrEmail(EditPasswordOrEmailRequest request);

        [OperationContract]
        GetAccountProfileResponse GetAccountProfile(GetAccountProfileRequest request);       //not yet done

        //Post Related Services
        [OperationContract]
        StatusResponse CreatePost(PostRequest request);
        
        [OperationContract]
        GetPostListResponse GetNewsfeed(GetPostsRequest request);

        [OperationContract]
        GetPostListResponse GetAccountRelatedPosts(GetPostsRequest request);

        //Like Related Service
        [OperationContract]
        StatusResponse LikePost(LikePostRequest request);

        [OperationContract]
        GetPostLikesResponse GetPostLikes(GetPostLikesRequest request);

        //Comment Related Services
        [OperationContract]
        CommentOnPostResponse CommentOnPost(CommentOnPostRequest request);

        [OperationContract]
        GetPostCommentsResponse GetPostComments(GetPostLikesRequest request);

        //Friend Related Services
        [OperationContract]
        FriendResponse RequestFriendship(FriendRequest request);

        [OperationContract]
        FriendResponse AcceptFriendship(FriendRequest request);

        [OperationContract]
        FriendResponse BlockAccount(FriendRequest request);

        [OperationContract]
        ViewFriendsListResponse ViewFriendsList(ViewFriendsListRequest request);

        //Notification Related Services
        [OperationContract]
        GetAllNotificationsResponse GetAllNotifications(GetAllNotificationsRequest request);
    }
}
