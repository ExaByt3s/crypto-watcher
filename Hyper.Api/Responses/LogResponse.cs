﻿using System;
using Hyper.Domain.Models;


namespace Hyper.Api.Responses
{
    public class LogResponse
    {
        public Guid Id { get; set; }
        public LogLevel LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime CreationTime { get; set; }
    }
}