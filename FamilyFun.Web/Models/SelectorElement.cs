using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace FamilyFun.Web.Models
{
    public class SelectorElement
    {
        internal SelectorElement(ElementType get, string name, string controller, string action, string id, string imagePath)
            : this(get, name, controller, action, id, ImmutableDictionary<string, string>.Empty, imagePath) { }

        internal SelectorElement(ElementType get, string name, string controller, string action, string id, IPageColorDeterminer colorDeterminer)
            : this (get, name, controller, action, id, ImmutableDictionary<string, string>.Empty, colorDeterminer) { }

        internal SelectorElement(ElementType type, string name, string controller, string action, string id, IDictionary<string, string> defaultFields, IPageColorDeterminer colorDeterminer)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DeflaultFields = defaultFields ?? throw new ArgumentNullException(nameof(defaultFields));
            colorDeterminer.DetermineMenuItemColors(name.Length, out string bacgroundColor, out IEnumerable<string> textColors);
            TargetAction = action ?? throw new ArgumentNullException(nameof(action));
            TargetController = controller ?? throw new ArgumentNullException(nameof(controller));
            TargetId = id ?? throw new ArgumentNullException(nameof(id));

            BackgroundColor = bacgroundColor;
            TextColors = textColors;
            ElementType = type;

            if(BackgroundColor is null || TextColors is null || TextColors.Count() != name.Length)
            {
                throw new InvalidOperationException("Something not right with the colors");
            }
        }

        internal SelectorElement(ElementType type, string name, string controller, string action, string id, IDictionary<string, string> defaultFields, string imagePath)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            DeflaultFields = defaultFields ?? throw new ArgumentNullException(nameof(defaultFields));
            ImagePath = imagePath ?? throw new ArgumentNullException(nameof(imagePath));
            TargetAction = action ?? throw new ArgumentNullException(nameof(action));
            TargetController = controller ?? throw new ArgumentNullException(nameof(controller));
            TargetId = id ?? throw new ArgumentNullException(nameof(id));
            ElementType = type;
        }

        public ElementType ElementType { get;  }
        public string Name { get; }
        public IDictionary<string,string> DeflaultFields { get; }
        public string TargetController { get; }
        public string TargetAction { get; }
        public string TargetId { get; }
        public string? ImagePath { get; }
        public string? BackgroundColor { get; }
        public IEnumerable<string>? TextColors { get; }
    }

    public enum ElementType
    {
        Get,Post
    }
}
