using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using BookPlatform.Context;
using BookPlatform.Models;
using BookPlatform.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BookPlatform.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private void Debug(bool debug)
        {
            if (debug && Debugger.IsAttached == false)
            {
                Debugger.Launch();
            }
        }

        protected override void Seed(BookContext context)
        {
            Debug(false);

            //external file to import authors
            string resourceName = "BookPlatform.App_Data.authors_data.author_array_1000.json";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            JsonTextReader reader = new JsonTextReader(new StreamReader(stream));

            UnitOfWork unitOfWork = new UnitOfWork(new BookContext());
            JArray authors = JArray.Load(reader);
            Random bookAmount = new Random();
            Random pageAmount = new Random();
            Random randomTag = new Random();
            Random randomTagAmount = new Random();

            string[] tagWords = {
                "tag1", "tag2", "tag3", "tag4", "tag5", "tag6"
            };

            foreach (string tagWord in tagWords)
            {
                unitOfWork.Tags.Add(new Tag()
                {
                    Name = tagWord
                });
            }

            unitOfWork.Complete();

            IEnumerable<Tag> dbTags = unitOfWork.Tags.GetAll();

            foreach (JObject item in authors)
            {
                List<Book> books = new List<Book>();

                //add author
                Author author = new Author()
                {
                    Email = (string)item.GetValue("email"),
                    Name = (string)item.GetValue("first_name"),
                    LastName = (string)item.GetValue("last_name"),
                };

                //books
                for (int j = 0; j < bookAmount.Next(1, 10); j++)
                {

                    List<Tag> tags = new List<Tag>();
                    int tagAmount = randomTagAmount.Next(2, 8);

                    //add tags many-to-many
                    for (int k = 0; k < tagAmount; k++)
                    {
                        tags.Add(dbTags.ElementAt(randomTag.Next(0, dbTags.Count())));
                    }

                    //add cover one-to-one
                    Cover cover = new Cover()
                    {
                        ImageUrl = "Images/200x250.png"
                    };

                    Book book = new Book()
                    {
                        Title = $"title_{author.Name}_{j}",
                        Description = "lorem ipsum",
                        Isbn = $"00-{j}-00000-000-0",
                        Pages = (short)pageAmount.Next(50, 500),
                        PublishingDate = DateTime.Now,
                        Author = author,
                        Cover = cover,
                        Tags = tags
                    };

                    books.Add(book);
                }

                author.Books = books;
                unitOfWork.Authors.Add(author);
            }
            
            unitOfWork.Complete();
        }
    }
}
