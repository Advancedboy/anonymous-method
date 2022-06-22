using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    internal class Lesson
    {
        public string Name { get; }
        public DateTime Begin { get; private set; }

        public event EventHandler<DateTime> Started;

        public Lesson(string name)
        {
            if(name == null) { throw new ArgumentNullException("name"); }
            Name = name;
        }

        public void Start()
        {
            Begin = DateTime.Now;
            Started?.Invoke(this, Begin);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
