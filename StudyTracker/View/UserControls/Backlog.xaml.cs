using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudyTracker.View
{
    /// <summary>
    /// Логика взаимодействия для Backlog.xaml
    /// </summary>
    public partial class Backlog : UserControl
    {
        public Backlog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Mouse double click action. Crear treeView selection items.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void BackList_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            ClearTreeViewItemsControlSelection(BackList.Items, BackList.ItemContainerGenerator);
        }

        /// <summary>
        /// Clear treeView selection items.
        /// </summary>
        /// <param name="ic">Collection of items.</param>
        /// <param name="icg">Generator of item collection.</param>
        private static void ClearTreeViewItemsControlSelection(ItemCollection ic, ItemContainerGenerator icg)
        {
            if ((ic != null) && (icg != null))
                for (int i = 0; i < ic.Count; i++)
                {
                    TreeViewItem tvi = icg.ContainerFromIndex(i) as TreeViewItem;
                    if (tvi != null)
                    {
                        ClearTreeViewItemsControlSelection(tvi.Items, tvi.ItemContainerGenerator);
                        tvi.IsSelected = false;
                    }
                }
        }
    }
}
