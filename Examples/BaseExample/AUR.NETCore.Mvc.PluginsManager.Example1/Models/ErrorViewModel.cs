using System;

namespace AUR.NETCore.Mvc.PluginsManager.BaseExample.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}