using System.Collections.Generic;

namespace Shared.ResponseModels
{
    public class EntityResult<Type> where Type : class
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public Type Data { get; set; }
    }
}
