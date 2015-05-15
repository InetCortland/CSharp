using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLibrary
{
    public class ProgressChangedEventArgs : EventArgs
    {

        private string data;

        public ProgressChangedEventArgs(string value)
        {
            data = value;
        }


        public string Data
        {
            get { return data; }
            
        }

        public string Stuff
        {
            get
            {
                return "here is some stuff";
            }
        }

    }
}
