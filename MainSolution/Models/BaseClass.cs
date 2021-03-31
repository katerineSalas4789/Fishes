using System;

namespace MainSolution.Models
{
    public abstract class BaseClass
    {
        public string id { get; }

        public BaseClass()
        {
            id = Guid.NewGuid().ToString();
        }

    }
}
