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
using System.Windows.Shapes;

namespace Lapushok.ListModule
{
    /// <summary>
    /// Логика взаимодействия для AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        ProductWindowUseCases _productWindowUseCases;

        Product _product;

        List<Material> _materials;

        Action _action;

        public AddEditWindow()
        {
            InitializeComponent();

            _productWindowUseCases = new ProductWindowUseCases();
        }

        private async Task LoadMaterials()
        {
            _materials = await _productWindowUseCases.GetMaterials();
            cbMaterials.ItemsSource = _materials;
        }

        public Product OpenForAdd()
        {
            this.ShowDialog();

            return _product;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadMaterials();
        }

        private void btnPickPhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddMaterial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteMaterial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
