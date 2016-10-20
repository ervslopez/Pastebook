using PastebookApp.Models;
using PastebookApp.PastebookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookApp.Mapper
{
    public static class UserMapper
    {
        public static User ToUser(UserModel user)
        {
            return new User() {
                ABOUT_ME = user.ABOUT_ME,
                BIRTHDAY =user.BIRTHDAY,
                COUNTRY_ID = user.COUNTRY_ID,
                DATE_CREATED = user.DATE_CREATED,
                EMAIL = user.EMAIL,
                FIRST_NAME = user.FIRST_NAME,
                GENDER = user.GENDER,
                ID = user.ID,
                LAST_NAME = user.LAST_NAME,
                MOBILE_NO = user.MOBILE_NO,
                PASSWORD = user.PASSWORD,
                PROFILE_PIC = user.PROFILE_PIC,
                USER_NAME = user.USER_NAME
            };
        }

        public static UserModel ToUserModel(User user)
        {
            return new UserModel()
            {
                ABOUT_ME = user.ABOUT_ME,
                BIRTHDAY = user.BIRTHDAY,
                COUNTRY_ID = user.COUNTRY_ID,
                DATE_CREATED = user.DATE_CREATED,
                EMAIL = user.EMAIL,
                FIRST_NAME = user.FIRST_NAME,
                GENDER = user.GENDER,
                ID = user.ID,
                LAST_NAME = user.LAST_NAME,
                MOBILE_NO = user.MOBILE_NO,
                PASSWORD = user.PASSWORD,
                PROFILE_PIC = user.PROFILE_PIC,
                USER_NAME = user.USER_NAME
            };
        }
    }
}