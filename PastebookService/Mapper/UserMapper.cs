using PastebookModel;

namespace PastebookService
{
    public static class UserMapper
    {
        public static PB_USER ToPB_USER(User user)
        {
            return new PB_USER()
            {
                ID = user.ID,
                USER_NAME = user.USER_NAME,
                PASSWORD = user.PASSWORD,
                SALT = user.SALT,
                FIRST_NAME = user.FIRST_NAME,
                LAST_NAME = user.LAST_NAME,
                BIRTHDAY = user.BIRTHDAY,
                COUNTRY_ID = user.COUNTRY_ID,
                MOBILE_NO = user.MOBILE_NO,
                GENDER = user.GENDER.ToString(),
                PROFILE_PIC = user.PROFILE_PIC,
                DATE_CREATED = user.DATE_CREATED,
                ABOUT_ME = user.ABOUT_ME,
                EMAIL = user.EMAIL
            };
        }

        public static User ToUser(PB_USER user)
        {
            return new User()
            {
                ID = user.ID,
                USER_NAME = user.USER_NAME,
                PASSWORD = user.PASSWORD,
                SALT = user.SALT,
                FIRST_NAME = user.FIRST_NAME,
                LAST_NAME = user.LAST_NAME,
                BIRTHDAY = user.BIRTHDAY,
                COUNTRY_ID = (int)user.COUNTRY_ID,
                MOBILE_NO = user.MOBILE_NO,
                GENDER = user.GENDER[0],
                PROFILE_PIC = user.PROFILE_PIC,
                DATE_CREATED = user.DATE_CREATED,
                ABOUT_ME = user.ABOUT_ME,
                EMAIL = user.EMAIL
            };
        }
    }
}