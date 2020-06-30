using System;

namespace FamilyFun.Persistence.Models
{
    public class MenuItem
    {
        public MenuItem(int id, string name, string controller, string action, string? imagePath)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Controller = controller ?? throw new ArgumentNullException(nameof(controller));
            Action = action ?? throw new ArgumentNullException(nameof(action));
            Id = id;
            ImagePath = imagePath;
        }

        public string Name { get; }
        public string Controller { get; }
        public string Action { get; }
        public string? ImagePath { get; }
        public int Id { get; set; }
    }
}
