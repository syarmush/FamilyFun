using FamilyFun.Persistence.Models;
using FamilyFun.Web.Models;
using System;
using System.Collections.Generic;

namespace FamilyFun.Web
{
    public class PrizeResultViewModel
    {
        public FamilyMember Member { get; }
        public int TotalPoints { get { return ApprovedPoints + PendingPoints; } }
        public IEnumerable<Prize> Prizes { get; }
        public int ApprovedPoints { get; }
        public int PendingPoints { get; }
        public string ImageDirectoryPath { get; }

        internal PrizeResultViewModel(FamilyMember member, int approvedPoints, int pendingPoints, IEnumerable<Prize> prizes, string imageDirectoryPath)
        {
            Member = member ?? throw new ArgumentNullException(nameof(member));
            Prizes = prizes ?? throw new ArgumentNullException(nameof(prizes));
            ImageDirectoryPath = imageDirectoryPath ?? throw new ArgumentNullException(nameof(imageDirectoryPath));
            ApprovedPoints = approvedPoints;
            PendingPoints = pendingPoints;
        }
    }
}