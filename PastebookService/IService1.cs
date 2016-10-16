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
    }
}
