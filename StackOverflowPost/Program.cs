using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowPost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput;

            Console.WriteLine("A - Ver / Votar posts");
            Console.WriteLine("B - Criar post");
            userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case "a":

                    List<Post> posts = Post.GetAllPosts();

                    if(posts.Count == 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Posts");
                        Console.ResetColor();
                        Main(args);
                        break;
                    }
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("a - Return");
                        Console.WriteLine("Insert ID Post number to vote");
                        Console.ResetColor();
                        Console.WriteLine("");

                    foreach (Post post in posts)
                    {
                        Console.WriteLine("Id: " + post.Id);
                        Console.WriteLine("Title: " + post.Title);
                        Console.WriteLine("Description: " + post.Description);
                        Console.WriteLine("Date: " + post.DateTime);
                        Console.WriteLine("Up Votes: " + post.UpVote);
                        Console.WriteLine("Down Votes: " + post.DownVote);
                        Console.WriteLine("----------------------");
                    }

                    string inputUser;

                    inputUser = Console.ReadLine().ToLower();

                    if (inputUser == "a")
                    {
                        Console.Clear();
                        Main(args);
                    }
                    else
                    {
                        try
                        {
                            if(int.Parse(inputUser) <= posts.Count)
                            {
                                Post.VotePost(int.Parse(inputUser));
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Voted!");
                                Console.ResetColor();

                                Main(args);
                            }
                            else {Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Invalid ID"); Console.ResetColor(); Main(args); }
                            
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid ID");
                            Console.ResetColor();
                            Main(args);
                        }
                    }
                    break;

                case "b":

                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Insert Post Title: ");
                    string postTitle = Console.ReadLine();
                    Console.WriteLine("Insert Post Description: ");
                    string postDescription = Console.ReadLine();

                    //Create a new post
                    Post newPost = new Post(postTitle, postDescription, DateTime.Now);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Post Created");
                    Console.ResetColor();
                    Main(args);

                    break;
            }

        }
    }
}
