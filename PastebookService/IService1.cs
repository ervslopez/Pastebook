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
        StatusResponse EditUserProfile(UserRequest request);

        [OperationContract]
        StatusResponse EditUserPassword(EditPasswordOrEmailRequest request);

        //Post Related Services
        [OperationContract]
        StatusResponse CreatePost(PostRequest request);

        [OperationContract]                                                    //not yet done
        GetPostListResponse GetUserRelatedPosts(GetPostsRequest request);      //Posts on user's timeline

        [OperationContract]                                                    // not yet done
        GetPostListResponse GetUserAndFriendsPosts(GetPostsRequest request);   //Posts of user and friends

        //Like Related Service
        [OperationContract]
        StatusResponse LikePost(LikePostRequest request);

        [OperationContract]
        GetPostLikesResponse GetPostLikes(GetPostLikesRequest request);

        //Comment Related Services
        [OperationContract]
        StatusResponse CommentOnPost(CommentOnPostRequest request);

        [OperationContract]
        GetPostCommentsResponse GetPostComments(GetPostLikesRequest request);

    }
}
