using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace NavigationViewCrashes.Selectors
{
    [ContentProperty(Name = "ItemTemplate")]
    public class MenuItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            return item is Separator ? SeparatorTemplate : ItemTemplate;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return item is Separator ? SeparatorTemplate : ItemTemplate;
        }

        internal DataTemplate SeparatorTemplate = (DataTemplate)XamlReader.Load(
    @"<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>
                    <NavigationViewItemSeparator />
                  </DataTemplate>");

    }
}
