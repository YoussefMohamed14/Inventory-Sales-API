using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.Exceptions {
    public class ConflictException : Exception {
        public ConflictException(string entityName) 
            : base($"{entityName} already exists!!") {
            
        }
    }
}
