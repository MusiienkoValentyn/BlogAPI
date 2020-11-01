using System.Collections.Generic;
using TestTaskRestAPI.Authorization;

namespace TestTaskRestAPI.Models
{
    public class BlogModel
    {
        public static List<LoginModel> users = new List<LoginModel>
        {
            new LoginModel {Id=1,UserName="Meska",Password="1221" },
            new LoginModel {Id=2,UserName="Valentyn99",Password="2222"}
        };

        public static List<PostModel> posts = new List<PostModel>
            {
            new PostModel {Id=1,IdUser=2,Title="The best day",Content="Today I`ve visited London"},
            new PostModel  {Id=2,IdUser=1,Title="My first work day",Content="It was so cool. I`ve waited really long time for it.",Image=null}
            };

        public static List<CommentModel> comments = new List<CommentModel>
        {
            new CommentModel {Id=312,IdUser=1,IdPost=1,Content="It is awesome place!!!" },
            new CommentModel {Id=241,IdUser=2,IdPost=2,Content="I congratulate you, buddy"}
        };
    }
}
