using System;
using System.Collections.Generic;
using System.Linq;
using FamilyFun.Helpers;

namespace FamilyFun.Web.Models
{
    public interface IPageColorDeterminer
    {
        void DetermineMenuItemColors(int length, out string bacgroundColor, out IEnumerable<string> textColors);
        IEnumerable<string> DeterminePageBackgroundColors();
    }

    internal class PageColorDeterminer : IPageColorDeterminer
    {
        private readonly IEnumerable<string> _colors;
        private readonly IEnumerable<string> _pageBackgroundColors;

        private readonly ICollection<string> _menuItemBackgroundColors;

        public PageColorDeterminer(IEnumerable<string> colors)
        {
            _colors = colors ?? throw new ArgumentNullException(nameof(colors));
            _pageBackgroundColors = colors.RandomSubset(3, new Random());

            _menuItemBackgroundColors = new List<string>();
        }

        private IEnumerable<string> AvailableMenuItemBackgroundColors => _colors.Except(_pageBackgroundColors).Except(_menuItemBackgroundColors);

        public void DetermineMenuItemColors(int length, out string bacgroundColor, out IEnumerable<string> textColors)
        {
            string[] bannedColors = new string[2];

            bacgroundColor = AvailableMenuItemBackgroundColors.ElementAt(new Random().Next(0, AvailableMenuItemBackgroundColors.Count() - 1));
            _menuItemBackgroundColors.Add(bacgroundColor);

            bannedColors[0] = bacgroundColor;
            bannedColors[1] = "";
            string[] textColorsArray = new string[length];

            for (int i = 0; i < length; i++)
            {
                string textColor = _colors.Except(bannedColors).ElementAt(new Random().Next(0, _colors.Except(bannedColors).Count() - 1));
                bannedColors[1] = textColor;
                textColorsArray[i] = textColor;
            }

            textColors = textColorsArray;
        }

        public IEnumerable<string> DeterminePageBackgroundColors()
        {
            return _pageBackgroundColors;
        }
    }
}