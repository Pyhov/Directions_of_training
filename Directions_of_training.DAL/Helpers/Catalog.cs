using Directions_of_training.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Directions_of_training.DAL.EF;

namespace Directions_of_training.DAL.Helpers
{
    /// <summary>
    /// Костыль для заполнения каталога направлений,
    /// </summary>
    internal class Catalog
    {
        internal static bool Fill(DalContext context)
        {
            try
            {
                List<Record> records = new();
                using (StreamReader reader = new StreamReader("napravleniya-podgotovki-i-spetsialnosti.tsv"))
                {
                    string text = reader.ReadToEnd();
                    Regex regex = new Regex(@"(.+)  Код(.+)  (.+)\t(.+)\t(.+)\t(.+)");
                    Match match = regex.Match(text);
                    while (match.Success)
                    {
                        records.Add(new Record(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value, match.Groups[6].Value));
                        match = match.NextMatch();
                    }

                }
                foreach (var dirItem in records.GroupBy(o => o.Title))
                {
                    var rec = records.First(o => o.Title == dirItem.Key);
                    Direction direction = new Direction(rec.Title, rec.Code, rec.Qualification);
                    context.Directions.Add(direction);
                    foreach(var profItem in dirItem)
                    {
                        Profile profile = new Profile()
                        {
                            Name = profItem.Profile,
                            Faculty = profItem.Faculty,
                            Direction = direction
                        };
                        context.Profiles.Add(profile);
                    }
                }
                return true;
              }
            catch
            {
               
                return false;
            }


        }
    }
    struct Record
    {
        public Record(string title, string code, string qualification, string profile, string faculty)
        {
            Title = title;
            Code = code;
            Profile = profile;
            Faculty = faculty;
            switch (qualification)
            {
                case "Бакалавриат":
                    Qualification = QualificationEnum.Undergraduate;
                    break;
                case "Специалитет":
                    Qualification = QualificationEnum.Specialty;
                    break;
                default:
                    Qualification = QualificationEnum.Non;
                    break;
            }
        }

        public string Title { get; set; }
        public string Code { get; set; }
        public QualificationEnum Qualification { get; set; }
        public string Profile { get; set; }
        public string Faculty { get; set; }

    }
}
