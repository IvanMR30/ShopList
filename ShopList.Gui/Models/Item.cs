using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ShopList.Gui.Models
{
    [SQLite.Table("ShopList")]
    public class Item
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Nombre { get; set; }=string.Empty;
        [DefaultValue(1)]
        [NotNull]
        public int Cantidad { get; set; }
        [NotNull]
        public bool Comprado { get; set; } = false;
        public override string ToString()
        {
            return $"{Nombre} ( {Cantidad} )";
        }
    }
}
