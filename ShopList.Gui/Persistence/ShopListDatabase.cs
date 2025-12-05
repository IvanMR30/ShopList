using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ShopList.Gui.Persistence.Cofiguration;
using ShopList.Gui.Models;

namespace ShopList.Gui.Persistence
{
    public class ShopListDatabase
    {
        private ISQLiteAsyncConnection? _connection;
        private async Task InitAsync()
        {
            if (_connection != null)
            {
                return;
            }
            _connection = new SQLiteAsyncConnection(Constants.DatabasePath,Constants.Flags);
            await _connection.CreateTableAsync<Item>();
        }
        public async Task<int> SaveItemAsync(Item item)
        {
            await InitAsync();
            return await _connection!.InsertAsync(item);
        }
        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            await InitAsync();
            return await _connection!.Table<Item>().ToListAsync();
        }
        public async Task<int>RemoveItemAsync(Item item)
        {
            await InitAsync();
            return await _connection!.DeleteAsync(item);
        }
    }
}
