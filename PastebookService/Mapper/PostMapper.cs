using PastebookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookService
{
    public static class PostMapper
    {
        public static PB_POST ToPB_POST(Post post)
        {
            return new PB_POST()
            {
                ID = post.ID,
                CONTENT = post.CONTENT,
                CREATED_DATE = post.CREATED_DATE,
                PROFILE_OWNER_ID = post.PROFILE_OWNER_ID,
                POSTER_ID = post.POSTER_ID
            };
        }

        public static Post ToPost(PB_POST post)
        {
            return new Post()
            {
                ID = post.ID,
                CONTENT = post.CONTENT,
                CREATED_DATE = post.CREATED_DATE,
                PROFILE_OWNER_ID = post.PROFILE_OWNER_ID,
                POSTER_ID = post.POSTER_ID
            };
        }

        public static List<GetNewsfeed_Result> toGetNewsfeed_Result(List<GetAccountRelatedPosts_Result> postResult)
        {
            List<GetNewsfeed_Result> resultList = new List<GetNewsfeed_Result>();
            foreach (var result in postResult)
            {
                resultList.Add(new GetNewsfeed_Result()
                {
                    ID = result.ID,
                    CONTENT = result.CONTENT,
                    POSTER_ID = result.POSTER_ID,
                    PROFILE_OWNER_ID = result.PROFILE_OWNER_ID,
                    Like_Count = result.Like_Count,
                    Comment_Count = result.Comment_Count,
                    CREATED_DATE = result.CREATED_DATE
                });
            }
            return resultList;
        }

        public static List<GetAccountRelatedPosts_Result> toGetNewsfeed_Result(List<GetNewsfeed_Result> postResult)
        {
            List<GetAccountRelatedPosts_Result> resultList = new List<GetAccountRelatedPosts_Result>();
            foreach (var result in postResult)
            {
                resultList.Add(new GetAccountRelatedPosts_Result()
                {
                    ID = result.ID,
                    CONTENT = result.CONTENT,
                    POSTER_ID = result.POSTER_ID,
                    PROFILE_OWNER_ID = result.PROFILE_OWNER_ID,
                    Like_Count = result.Like_Count,
                    Comment_Count = result.Comment_Count,
                    CREATED_DATE = result.CREATED_DATE
                });
            }
            return resultList;
        }

    }
}