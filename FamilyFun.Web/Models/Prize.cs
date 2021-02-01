using System;

namespace FamilyFun.Web.Models
{
    public class Prize
    {
        public int Id { get; }
        public string Name { get; }
        public int CostInPoints { get; }
        public string ImageFileName { get; }

        public Prize(int id, string memberName, int points, string imageFileName)
        {
            Id = id;
            Name = memberName ?? throw new ArgumentNullException(nameof(memberName)); ;
            CostInPoints = points;
            ImageFileName = imageFileName ?? throw new ArgumentNullException(nameof(imageFileName));
        }
    }
}
