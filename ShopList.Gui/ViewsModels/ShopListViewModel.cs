using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopList.Gui.Models;

namespace ShopList.Gui.ViewsModels
{
    public class ShopListViewModel
    {
        public ObservableCollection<Item> Items { get; }
    public ShopListViewModel() { 
            
            Items = new ObservableCollection<Item>();
            CargarDatos();
        }

        private void CargarDatos()
        {
            Items.Add(new Item() { Id = 1, Nombre = "leche", Cantidad=2, });
            Items.Add(new Item() { Id = 2, Nombre = "pan de caha", Cantidad = 1, });
            Items.Add(new Item() { Id = 3, Nombre = "Jamon", Cantidad = 500, });
        }
    }
}
