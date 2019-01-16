using System.ComponentModel;

namespace PersonenManager
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private bool _verheiratet;
        public bool Verheiratet
        {
            get { return _verheiratet; }
            set { _verheiratet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Verheiratet)));
            }
        }

        private string _nameEhepartner;
        public string NameEhepartner
        {
            get { return _nameEhepartner; }
            set { _nameEhepartner = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NameEhepartner)));
            }
        }

        public Person()
        {

        }

        public Person(string name, bool verheiratet, string nameEhepartner = "")
        {
            Name = name;
            Verheiratet = verheiratet;
            NameEhepartner = nameEhepartner;
        }
    }
}