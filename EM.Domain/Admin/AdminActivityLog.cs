using EM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Admin
{
    public class AdminActivityLog
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public User Admin { get; set; }
        public string EntityAffected { get; set; }
        public DateTime ActionTime { get; set; }
    }
}
