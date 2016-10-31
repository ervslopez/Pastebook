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
        EditUserResponse UpdateUserPassword(UserRequest request);

        [OperationContract]
        EditUserResponse EditUserPasswordOrEmail(EditPasswordOrEmailRequest request);

        [OperationContract]
        GetAccountProfileResponse GetAccountProfile(GetAccountProfileRequest request);       

        [OperationContract]
        StatusResponse ConfirmOldPassword(ConfirmOldPasswordRequest request);

        [OperationContract]
        SearchUsersResponse SearchUsers(SearchUsersRequest request);

        //Post Related Services
        [OperationContract]
        StatusResponse CreatePost(PostRequest request);
        
        [OperationContract]
        GetPostListResponse GetNewsfeed(GetPostsRequest request);

        [OperationContract]
        GetPostListResponse GetAccountRelatedPosts(GetPostsRequest request);

        [OperationContract]
        GetPostResponse GetPost(GetPostRequest request);

        //Like Related Service
        [OperationContract]
        StatusResponse LikePost(LikePostRequest request);
        
        //Comment Related Services
        [OperationContract]
        CommentOnPostResponse CommentOnPost(CommentOnPostRequest request);
        
        //Friend Related Services
        [OperationContract]
        FriendResponse RequestFriendship(FriendRequest request);

        [OperationContract]
        FriendResponse AcceptFriendship(FriendRequest request);

        [OperationContract]
        FriendResponse DeclineFriendship(FriendRequest request);

        [OperationContract]
        FriendResponse BlockAccount(FriendRequest request);

        [OperationContract]
        ViewFriendsListResponse ViewFriendsList(ViewFriendsListRequest request);

        [OperationContract]
        GetFriendshipStatusResponse GetFriendshipStatus(FriendRequest request);

        //Notification Related Services
        [OperationContract]
        GetAllNotificationsResponse GetAllNotifications(GetAllNotificationsRequest request);

        [OperationContract]
        GetNotificationCountResponse GetNotificationCount(GetAllNotificationsRequest request);
        //Utilities
        [OperationContract]
        GetCountriesResponse GetCountries();
    }
}
