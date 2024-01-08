using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISO_Server.Models
{
    public class Iso8583Field
    {
        public string Format { get; }


        public int Length { get; }

        public string Name { get; }

        public string Value { get; set; }
        public Iso8583Field(string name, string format, int Len)
        {
            Name = name;
            Format = format;
            Length = Len;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
