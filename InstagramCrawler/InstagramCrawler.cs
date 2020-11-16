using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using InstagramCrawling;

namespace InstagramCrawler
{
    class InstagramCrawler
    {
        public static void Write(string content) {Console.Write(content);}
        public static void WriteLine(string content) {Console.WriteLine(content);}
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            WriteLine("Welcome to the INSTAGRAM CRWALER");
            WriteLine("Press any key to continue");
            Console.ReadKey();
            WriteLine("=================================");
            Write("Instagram profile internet address: ");
            string link = Console.ReadLine();
            Write("Saving path: ");
            string path = Console.ReadLine();
            if(!Directory.Exists(path))
            {
                WriteLine("Given directory is not exists. Would you want to make a directory(y/n): ");
                string c = Console.ReadLine();
                if (c.ToLower() == "y")
                {
                    Directory.CreateDirectory(path);
                }
                else
                {
                    WriteLine("Canceled");
                    return;
                }
            }
            string id;
            StringBuilder pwd = new StringBuilder();
            Write("Instagram Phone number, username or email: ");
            id = Console.ReadLine();
            Write("Password: ");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace) pwd.Remove(pwd.Length - 1, 1);
                pwd.Append(key.KeyChar);
            }
            WriteLine("\nPress any key to start");
            Console.ReadKey();
            try
            {
                Write("Initializing...\n");
                Crawler crawler = new Crawler();
                WriteLine("Completed");
                Write("Logging in...");
                crawler.Login(id, pwd.ToString(), link);
                WriteLine("Completed");
                WriteLine("Getting list of posts...");
                List<string> url = crawler.GetPhotoUrl();
                int cnt = 0;
                foreach (string s in url)
                {
                    WriteLine(s);
                }
                WriteLine("Completed");
                WriteLine("Total " + url.Count + "posts.");
                WriteLine("Getting list of images");
                List<string> finalLinks = new List<string>();
                foreach (string s in url)
                {
                    WriteLine("CRAWL FROM " + s);
                    List<string> lx = crawler.GetFrom(s);
                    foreach (string l in lx)
                    {
                        finalLinks.Add(l);
                    }
                    WriteLine(s + " Completed");
                }
                WriteLine("Completed");
                WriteLine("Downloading");
                foreach (string l in finalLinks)
                {
                    crawler.SaveAs(l, path, cnt);
                    WriteLine("Download from " + l);
                }
                WriteLine("\nTotal " + cnt + " pictures");
                WriteLine("Completed");
            } catch(Exception e)
            {
                Console.Error.WriteLine("Error: " + e.Message);
                Console.Error.Write("Crawling stopped");
                return;
            }
        }
    }
}
