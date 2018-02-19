using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTVSettingsAdmin.Classes
{
    public class Group
    {
        private String _name;
        private String _fileName; //TODO: still necessary???
        private List<Channel> _channels;
        private bool _wanted = true; //TODO: still necessary???

        public String Name {
            set {
                _name = value;
            }
            get {
                return _name;
            }
        }

        public String NameAndCount {
            get {
                return _name + " (" + _channels.Count.ToString() + ")";
            }
        }

        public String FileName {
            set {
                _fileName = value;
            }
            get {
                return _fileName;
            }
        }

        public List<Channel> Channels {
            set {
                _channels = value;
            }
            get { 
                return _channels;
            }
        }

        public bool Wanted {
            set
            {
                _wanted = value;
            }
            get {
                return _wanted;
            }
        }

        public Group() { 
            //Default constructor
            _channels = new List<Channel>();
        }

        public Group(String name) {
            _channels = new List<Channel>();
            _name = name;
        }
    }
}
