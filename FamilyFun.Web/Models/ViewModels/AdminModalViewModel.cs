using System;

namespace FamilyFun.Web.Models.ViewModels
{
    public class AdminModalViewModel
    {
        public AdminModalViewModel(string adminPartialViewName, object adminPartialViewModel)
        {
            AdminPartialViewName = adminPartialViewName ?? throw new ArgumentNullException(nameof(adminPartialViewName));
            AdminPartialViewModel = adminPartialViewModel ?? throw new ArgumentNullException(nameof(adminPartialViewModel));
        }

        public string AdminPartialViewName { get; }
        public object AdminPartialViewModel { get; }
    }
}
