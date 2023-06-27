using System;
namespace BestBlogs.Application.ViewModels.Commons
{
    public class SuccessResponseViewModel
    {
        public SuccessResponseViewModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}