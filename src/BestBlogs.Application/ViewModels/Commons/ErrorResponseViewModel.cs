using System;

namespace BestBlogs.Application.ViewModels.Commons
{
    public class ErrorResponseViewModel
    {
        public ErrorResponseViewModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}