using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace MTODO.UserControls
{
    public sealed partial class BookPresenter : UserControl
    {


        public string ContextMenuText
        {
            get { return (string)GetValue(ContextMenuTextProperty); }
            set { SetValue(ContextMenuTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContextMenuText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContextMenuTextProperty =
            DependencyProperty.Register("ContextMenuText", typeof(string), typeof(BookPresenter), new PropertyMetadata(string.Empty));



        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(BookPresenter), new PropertyMetadata(null));


        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(BookPresenter), new PropertyMetadata(null));



        public ImageSource ImageURL
        {
            get { return (ImageSource)GetValue(ImageURLProperty); }
            set { SetValue(ImageURLProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageURL.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageURLProperty =
            DependencyProperty.Register("ImageURL", typeof(ImageSource), typeof(BookPresenter), new PropertyMetadata(null));


        public BookPresenter()
        {
            this.InitializeComponent();
        }
    }
}
