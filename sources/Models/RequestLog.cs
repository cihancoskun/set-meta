﻿namespace SetMeta.Web.Models
{
    public class RequestLog : BaseEntity
    {
        public string Token { get; set; }
        public string IP { get; set; }
        public string Url { get; set; }
    }
}