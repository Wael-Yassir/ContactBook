using System.Windows;

namespace ContactBook.WPF.Base
{
    public class MVVMBehavior
    {
        public static string GetLoadedMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadedMethodNameProperty);
        }

        public static void SetLoadedMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadedMethodNameProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadedMethodName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadedMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadedMethodName", typeof(string), typeof(MVVMBehavior), new PropertyMetadata(null, onLoaded));

        private static void onLoaded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;

            if (element != null)
            {
                element.Loaded += (sender, arge) =>
                {
                    var viewModel = element.DataContext;
                    if (viewModel == null)
                        return;

                    var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());
                    if (methodInfo != null)
                        methodInfo.Invoke(viewModel, null);
                };
            }
        }
    }
}
