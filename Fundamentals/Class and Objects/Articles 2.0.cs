using System;
using System.Linq;
using System.Collections.Generic;


namespace Articles2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Articles> articles = new List<Articles>();
            int numberArticles = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberArticles; i++)
            {
                string[] inputArticles = Console.ReadLine().Split(", ");
                Articles articlesClass = new Articles(inputArticles[0], inputArticles[1], inputArticles[2]);
                articles.Add(articlesClass);
            }

            string orderBy = Console.ReadLine();
            switch (orderBy)
            {
                case "title":
                    List<Articles> byTitle = articles.OrderBy(x => x.Title).ToList();
                    foreach (var item in byTitle)
{
                        Console.WriteLine($"{item.Title} - {item.Content}: {item.Author}");
                    }
                    break;

                case "content":
                    List<Articles> byContent = articles.OrderBy(x => x.Content).ToList();
                    foreach (var item in byContent)
                    {
                        Console.WriteLine($"{item.Title} - {item.Content}: {item.Author}");
                    }
                    break;

                case "author":
                    List<Articles> byAuthor = articles.OrderBy(x => x.Author).ToList();
                    foreach (var item in byAuthor)
                    {
                        Console.WriteLine($"{item.Title} - {item.Content}: {item.Author}");
                    }
                    break;

                default:
                    break;
            }

        }
    }

    class Articles
    {
        public Articles(string title , string content , string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
