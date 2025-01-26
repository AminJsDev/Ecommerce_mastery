using EM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Admin
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Entity { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
        public int AdminId { get; set; }
        public User Admin { get; set; }
        public DateTime ActionTime { get; set; }
    }
}
