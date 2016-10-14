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
        [OperationContract]
        StatusResponse CreateUserAccount(UserRequest request);

        [OperationContract]
        LoginResponse LoginUserAccount(UserRequest request);

    }
}
