using System;
using ValidationFactory.Validators;

namespace ValidationFactory.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class EmailData : System.Attribute
    {
        public EmailData()
        {
        }
        public EmailValidateType type { get; set; }
    }
}

