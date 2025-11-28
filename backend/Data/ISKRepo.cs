using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;

namespace Backend.Data
{
    public interface ISKRepo
    {
        public void Register(User user);
        // public void RegisterAdmin(User admin);
        public bool ValidLogin(string userName, string password);
        public void AddRecord(Record record);
        public IEnumerable<Record> GetAllRecords();
        public Record GetRecordById(string id);
        public void SaveChanges();
    }
}
