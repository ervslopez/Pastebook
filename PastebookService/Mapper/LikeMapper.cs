using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public static class LikeMapper
    {
        public static PB_LIKE ToPB_LIKE(Like like)
        {
            return new PB_LIKE()
            {
                ID = like.ID,
                POST_ID = like.POST_ID,
                LIKED_BY = like.LIKED_BY
            };
        }

        public static Like ToLike(PB_LIKE like)
        {
            return new Like()
            {
                ID = like.ID,
                POST_ID = like.POST_ID,
                LIKED_BY = like.LIKED_BY
            };
        }
        
    }
}