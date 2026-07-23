using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.Responses {
    public class ErrorResponse {
        public bool Success { get; init; } = false;

        public int StatusCode { get; init; }

        public string Message { get; init; } = string.Empty;

        public DateTime Timestamp { get; init; } = DateTime.Now;
    }
}
