using System;

namespace WebVendas.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}