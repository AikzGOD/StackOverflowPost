using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowPost
{
    internal class Post
    {
        //Create a program where we should be able to
        //Upvote , Downvote a post , See current vote value.
        //in the main method, create a post, up-vote and down-vote it a feew times
        //and then display the current vote value


        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }


        private static List<Post> AllPosts = new List<Post>();

        public Post(string PostTitle , string PostDescription , DateTime PostDate)
        {
            Title = PostTitle; Description = PostDescription; DateTime = PostDate;
            Id = AllPosts.Count;
            AllPosts.Add(this);
        }

        public static List<Post> GetAllPosts()
        {
            return AllPosts;
        }

        public static Post VotePost(int Id)
        {
            Console.WriteLine("Vote with key Arrows (Up - Upvote , Down - Downvote)");
            var keyInfo = Console.ReadKey();

            switch (keyInfo.Key.ToString())
            {
                case "DownArrow":

                    int DownvoteNumber = AllPosts[Id].DownVote;

                    DownvoteNumber = DownvoteNumber + 1;

                    AllPosts[Id].DownVote = DownvoteNumber;

                    return AllPosts[Id];

                break;

                case "UpArrow":

                    int UpvoteNumber = AllPosts[Id].UpVote;

                    UpvoteNumber = UpvoteNumber + 1;

                    AllPosts[Id].UpVote = UpvoteNumber;

                    return AllPosts[Id];


                break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Input!");
                    VotePost(Id);
                    break;
            }


            return AllPosts[Id];
        }



        

        



    }
}
