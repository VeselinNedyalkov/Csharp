using System;
using System.Reflection.Metadata;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputTCA = Console.ReadLine().Split(", ");
            int numberCmd = int.Parse(Console.ReadLine());

            Article article = new Article(inputTCA[0], inputTCA[1], inputTCA[2]);

            
            
            for (int i = 0; i < numberCmd; i++)
            {
                string[] cmd = Console.ReadLine().Split(": ");
                string inputCmd = cmd[0];
                string inputData = cmd[1];

                switch (inputCmd)
                {
                    case "Edit":
                        article.Edit(inputData);
                        break;

                    case "ChangeAuthor":
                        article.ChangeAuthor(inputData);
                        break;

                    case "Rename":
                        article.Rename(inputData);
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine(article);
        }
    }//class program

    class Article
    {
        private string titleClass_;
        private string contentClass_;
        private string authorClass_;

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title 
        {
            get => titleClass_;
            set => titleClass_ = value; 
        }
        public string Content 
        { 
            get => contentClass_; 
            set => contentClass_ = value; 
        }
        public string Author 
        { 
            get => authorClass_; 
            set => authorClass_ = value; 
        }

        public  void Edit(string content)
        {
            Content = content;
        }

        public  void ChangeAuthor(string author)
        {
            Author = author;
        }

        public  void Rename(string title)
        {
            Title = title;
        }

        public override string ToString()
{
            return $"{Title} - {Content}: {Author}";
        }
    }//class Article
}
