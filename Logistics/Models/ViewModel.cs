using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics.Models
{
    public class ViewModel
    {
        public IEnumerable<Booking> BookingModel { get; set; }

        public IEnumerable<Complaint> ComplaintModel { get; set; }

        public IEnumerable<Delivery> DeliveryModel { get; set; }

        public IEnumerable<Dispatch> DispatchtModel { get; set; }

        public IEnumerable<LogDetail> LogDetailModel { get; set; }

        public IEnumerable<Process> ProcessModel { get; set; }

        public IEnumerable<Storage> StorageModel { get; set; }

        public IEnumerable<User> UserModel { get; set; }

    }
}