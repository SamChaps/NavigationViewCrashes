using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace NavigationViewCrashes
{
    public class Separator { }

    public class Menu
    {
        public string Name { get; set; }
        public IconSource Icon { get; set; }

        public ObservableCollection<Menu> SubMenus { get; set; }

    }

    public sealed partial class MainPage : Page
    {
        private const int MaxNestingDepth = 5;
        private const int SubMenusCount = 5;

        ObservableCollection<Menu> Menus { get; set; }

        public MainPage()
        {
            InitializeComponent();
            BuildMenus();
        }

        private void BuildMenus()
        {
            Menus = new ObservableCollection<Menu>();

            for (int i = 0; i < 3; i++)
            {
                Menus.Add(new Menu { Name = $"Menu {i}", Icon = new FontIconSource { Glyph = "\uE783" } });
            }

            BuildNestedMenus(Menus, 0);
        }

        private void BuildNestedMenus(ObservableCollection<Menu> menus, int currentNestingDepth)
        {
            if (currentNestingDepth == MaxNestingDepth)
            {
                return;
            }

            foreach (var menu in menus)
            {
                menu.SubMenus = new ObservableCollection<Menu>();

                for (int i = 0; i < 3; i++)
                {
                    menu.SubMenus.Add(new Menu { Name = $"Menu {i}", Icon = new FontIconSource { Glyph = "\uE783" } });
                }

                BuildNestedMenus(menu.SubMenus, currentNestingDepth + 1);
            }
        }
    }
}
