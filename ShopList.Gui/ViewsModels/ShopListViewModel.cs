using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
//using System.Windows.Input;
using ShopList.Gui.Models;
using ShopList.Gui.Persistence;
using System.Threading.Tasks;

namespace ShopList.Gui.ViewsModels
{
    public partial class ShopListViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _nombreDelArticulo = string.Empty;
        [ObservableProperty]
        private int _cantidadAComprar = 1;
        [ObservableProperty]
        private Item? _elementoSeleccionado = null;
        [ObservableProperty]
        private ObservableCollection<Item> _items = null;
        private ShopListDatabase? _database = null;

        public ShopListViewModel()
        {
            _database = new ShopListDatabase();
            Items = new ObservableCollection<Item>();
            GetItems();
            if (Items.Count > 0)
            {
                ElementoSeleccionado = Items.First();
            }
            else
            {
                ElementoSeleccionado=null;
            }
        }
        [RelayCommand]
        private void CargarDatos()
        {
            Items.Add(new Item() { Id = 1, Nombre = "Leche", Cantidad = 2, Comprado = true });
            Items.Add(new Item() { Id = 2, Nombre = "Pan de caja", Cantidad = 1, Comprado = false });
            Items.Add(new Item() { Id = 3, Nombre = "Jamon", Cantidad = 500, Comprado = false });
        }

        [RelayCommand]
        public void EliminarShopListItem()
        {
            var indice = Items.IndexOf(_elementoSeleccionado);
            Item? nuevoSeleccionado;
            if (Items.Count > 1)
            {
                if (indice < Items.Count - 1)
                {
                    nuevoSeleccionado = Items[indice + 1];
                }
                else
                {
                    nuevoSeleccionado = Items[indice - 1];
                }
            }
            else
            {
                nuevoSeleccionado = null;
            }
            Items.Remove(_elementoSeleccionado);
            ElementoSeleccionado = nuevoSeleccionado;
        }

        [RelayCommand]
        public async void AgregarShopListItem()
        {
            if (string.IsNullOrEmpty(NombreDelArticulo) || CantidadAComprar <= 0)
            {
                return;
            }
            var item = new Item
            {
                //Id = generador.Next(),
                Nombre = NombreDelArticulo,
                Cantidad = CantidadAComprar,
                Comprado = false,
            };
            //Items.Add(item);
            await _database.SaveItemAsync(item);
            GetItems();
            _elementoSeleccionado = item;
            NombreDelArticulo = string.Empty;
            CantidadAComprar = 1;
        }
        private async void GetItems()
        {
            IEnumerable<Item> itemFromdb = await _database.GetAllItemsAsync();
            Items = new ObservableCollection<Item>(itemFromdb);
            //foreach (Item item in itemFromdb)
            //{
            //    Items.Add(item);
            //}
        }
    }
} 

