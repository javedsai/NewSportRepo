using SportDirect.Data.Models.Response;
using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SportDirect.Assets
{

    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Customer_Add>().Wait();
            _database.CreateTableAsync<Customer_Sqlite>().Wait();
            _database.CreateTableAsync<Mycart>().Wait();

        }

        public Task<int> SaveNoteAsync(Customer_Add note)
        {

            if (Convert.ToString(note.Cus_id) != "0")
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }
        public Task<List<Customer_Add>> GetNoteAsync()
        {
            //  _database.CreateTableAsync<Customer_Add>().Wait();
            return _database.Table<Customer_Add>().ToListAsync();
        }
        public Task<int> DeleteNoteAsync(Customer_Add note)
        {
            //  _database.CreateTableAsync<Customer_Add>().Wait();
            return _database.DeleteAsync(note);
        }
        public Task<int> SaveCustomerAsync(Customer_Sqlite note)
        {

            if (Convert.ToString(note.id) != "0")
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }
        public Task<List<Customer_Sqlite>> GetCustomer()
        {
            //  _database.CreateTableAsync<Customer_Add>().Wait();
            return _database.Table<Customer_Sqlite>().ToListAsync();
        }
        public Task<int> DeleteCustomer(Customer_Sqlite note)
        {
            //  _database.CreateTableAsync<Customer_Add>().Wait();
            return _database.DeleteAsync(note);
        }

        public Task<int> SaveCart(Mycart note)
        {

            if (Convert.ToString(note.Id) != "0")
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }
        public Task<List<Mycart>> GetCart()
        {
            //  _database.CreateTableAsync<Customer_Add>().Wait();
            return _database.Table<Mycart>().ToListAsync();
        }
        public Task<int> DeleteCart(Mycart note)
        {
            //  _database.CreateTableAsync<Customer_Add>().Wait();
            return _database.DeleteAsync(note);
        }

        public Task<int> DeleteCart()
        {
            return _database.DeleteAllAsync<Mycart>();
        }
        public Task<int> DeleteAdd()
        {
            return _database.DeleteAllAsync<Customer_Add>();
        }
        public Task<int> DeleteCus()
        {
            return _database.DeleteAllAsync<Customer_Sqlite>();
        }
    }
}
