using Lapushok.ListModule.UseCases;
using Lapushok.Models.DBEntities;
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

namespace Lapushok.ListModule
{
    /// <summary>
    /// Логика взаимодействия для ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        private readonly ProductListUseCases _productListUseCases;
        public ListPage()
        {
            _productListUseCases = new ProductListUseCases();
            InitializeComponent();
        }

        private async Task RefreshProductsList()
        {
            lvProducts.ItemsSource = await _productListUseCases.GetProducts(cbSort.SelectedItem as string, cbMaterial.SelectedItem as Material, tbSearch.Text);
        }

        private void FillSortCB()
        {
            cbSort.ItemsSource = ProductListUseCases.SortTypes;
            cbSort.SelectedIndex = 0;
        }

        private async Task FillMaterialCB()
        {
            var materials = new List<Material>()
            {
                new Material { Title = "Все" }
            };

            materials.AddRange(await _productListUseCases.GetMaterials());

            cbMaterial.ItemsSource = materials;
            cbMaterial.SelectedIndex = 0;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FillSortCB();
            await FillMaterialCB();
            await RefreshProductsList();

            tbSearch.TextChanged += tbSearch_TextChanged;
            cbMaterial.SelectionChanged += cbSort_SelectionChanged;
            cbSort.SelectionChanged += cbSort_SelectionChanged;
        }

        private async void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            await RefreshProductsList();
        }

        private async void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await RefreshProductsList();
        }

        private async void tbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            await RefreshProductsList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddEditWindow().OpenForAdd();
        }
    }
}
