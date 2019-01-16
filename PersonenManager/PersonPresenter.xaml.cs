using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PersonenManager
{
    public sealed partial class PersonPresenter : UserControl
    {
        //Snippet: propdp
        public Person Person
        {
            get { return (Person)GetValue(PersonProperty); }
            set { SetValue(PersonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Person.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PersonProperty =
            DependencyProperty.Register(nameof(Person), typeof(Person), typeof(PersonPresenter), new PropertyMetadata(null,PersonChanged));

        private static void PersonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is PersonPresenter presenter)
            {
                if (e.NewValue is Person person && person.Verheiratet == true)
                    presenter.grid.Background = new SolidColorBrush(Colors.Red);
            }
        }

        public PersonPresenter()
        {
            this.InitializeComponent();
        }

        private void Grid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            tblockName.Visibility = Visibility.Collapsed;
            tboxName.Visibility = Visibility.Visible;
        }
    }
}
