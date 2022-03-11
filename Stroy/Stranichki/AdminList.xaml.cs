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

namespace Stroy.Stranichki
{

    public partial class AdminList : Page
    {
        List<Material> List = DateBase.DB.Material.ToList();
        List<MaterialSupplier> MatSup = DateBase.DB.MaterialSupplier.ToList();
        public AdminList()
        {
            InitializeComponent();
            LVList.ItemsSource = List;
        }

        private void TBSup_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<MaterialSupplier> mtList = DateBase.DB.MaterialSupplier.Where(x => x.MaterialID == index).ToList();
            string str = "";
            foreach (MaterialSupplier item in mtList)
            {
                str += item.Supplier.Title + ", ";
            }
            if (mtList.Count == 0)
            {
                tb.Text = "Поставщик: отсутствует";
            }
            else
            {
                tb.Text = "Поставщик" + str.Substring(0, str.Length - 2);
            }
        }
        List<Material> MatFilter = new List<Material>();

        List<Material> MatPoisk = new List<Material>();

        private void TBPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBPoisk.Text != String.Empty)
            {
                MatPoisk = List.Where(x => x.Title.Contains(TBPoisk.Text)).ToList();
                FliterSort();
            }
            else
            {
                FliterSort();
            }
        }

        private void CBFil_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FliterSort();
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FliterSort();
        }

        private void FliterSort()
        {
            int filterIndex = CBFil.SelectedIndex;

            if (TBPoisk.Text != String.Empty)
            {
                if (filterIndex != 0)
                {
                    MatFilter = MatPoisk.Where(x => x.MaterialTypeID == filterIndex).ToList();
                }
                else
                {
                    MatFilter = MatPoisk;
                }
            }
            else
            {
                if (filterIndex != 0)
                {
                    MatFilter = List.Where(x => x.MaterialTypeID == filterIndex).ToList();
                }
                else
                {
                    MatFilter = List;
                }
            }

            switch (CBSort.SelectedIndex)
            {
                case 0:
                    MatFilter.Sort((x, y) => x.Title.CompareTo(y.Title));
                    break;
                case 1:
                    MatFilter.Sort((x, y) => x.Title.CompareTo(y.Title));
                    MatFilter.Reverse();
                    break;
                case 2:
                    MatFilter.Sort((x, y) => x.Cost.CompareTo(y.Cost));
                    break;
                case 3:
                    MatFilter.Sort((x, y) => x.Cost.CompareTo(y.Cost));
                    MatFilter.Reverse();
                    break;
                case 4:
                    MatFilter.Sort((x, y) => x.CountInStock.CompareTo(y.CountInStock));
                    break;
                case 5:
                    MatFilter.Sort((x, y) => x.CountInStock.CompareTo(y.CountInStock));
                    MatFilter.Reverse();
                    break;
            }
            LVList.ItemsSource = MatFilter;
            LVList.Items.Refresh();
        }

        private void LVList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }
}
