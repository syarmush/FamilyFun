using System;

namespace FamilyFun.Web.Models
{
    public class MenuItem
    {
        public MenuItem(string name, string link, string imagePath)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Link = link ?? throw new ArgumentNullException(nameof(link));
            ImagePath = imagePath ?? throw new ArgumentNullException(nameof(imagePath));
        }

        public string Name { get; set; }
        public string Link { get; set; }
        public string ImagePath { get; set; }
    }
}
