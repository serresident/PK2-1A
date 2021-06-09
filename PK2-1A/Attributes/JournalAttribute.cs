using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK2_1A.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class JournalAttribute : Attribute
    {
        private string message;

        public JournalAttribute(string message)
        {
            this.message = message;
        }

        public virtual string Message
        {
            get { return message; }
        }


    }

}
