using System.Collections.Generic;

namespace Shared.ResponseModels
{
    public class ListOfEntityResult<Type> where Type : class
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public List<Type> Data { get; set; }
    }
}
