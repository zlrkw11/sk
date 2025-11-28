using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Data
{
    public class SKRepo : ISKRepo
    {
        private readonly SKDbContext _context;

        public SKRepo(SKDbContext context)
        {
            _context = context;
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
        }

        public bool ValidLogin(string userName, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            return user != null;
        }

        public void AddRecord(Record record)
        {
            // Implementation for adding a record
        }

        public IEnumerable<Record> GetAllRecords()
        {
            // Implementation for retrieving all records
            return new List<Record>();
        }

        public Record GetRecordById(string id)
        {
            // Implementation for retrieving a record by ID
            return null;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}