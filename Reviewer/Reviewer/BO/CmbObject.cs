using System;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Web;

namespace BO
{

    public class MyListItem
    {
        private string _name;
        private object _value;

        public MyListItem(string name, object value)
        {
            _name = name;
            _value = value;
        }
        public object value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override string ToString()
        {
            return _name;
        }
    }

}