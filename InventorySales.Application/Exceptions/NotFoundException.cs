using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.Exceptions {
    public class NotFoundException : Exception {
        public NotFoundException(string entityName, object key) 
            : base($"{entityName} with Id '{key}' was not found.") { }

        public NotFoundException(string entityName)
            : base($"{entityName} not found.") { }
    }
}
