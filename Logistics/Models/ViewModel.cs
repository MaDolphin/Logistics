using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Logistics.Models
{
    public class AllModel
    {
        public IEnumerable<Booking> BookingModel { get; set; }

        public IEnumerable<Complaint> ComplaintModel { get; set; }

        public IEnumerable<Delivery> DeliveryModel { get; set; }

        public IEnumerable<Dispatch> DispatchtModel { get; set; }

        public IEnumerable<LogDetail> LogDetailModel { get; set; }

        public IEnumerable<Process> ProcessModel { get; set; }

        public IEnumerable<Stock> StockModel { get; set; }

        public IEnumerable<Storage> StorageModel { get; set; }

        public IEnumerable<User> UserModel { get; set; }

    }

    public class CommunicateModel
    {
        public Booking BookingModel { get; set; }

        public User UserModel { get; set; }
    }

    public class CourierModel
    {
        public IEnumerable<LogDetail> LogDetailModel { get; set; }

        public IEnumerable<Process> ProcessModel { get; set; }

        public IEnumerable<User> UserModel { get; set; }

    }

    public class NetWorkModel
    {
        public IEnumerable<Dispatch> DispatchtModel { get; set; }

        public IEnumerable<Delivery> DeliveryModel { get; set; }

        public IEnumerable<LogDetail> LogDetailModel { get; set; }

        public IEnumerable<Process> ProcessModel { get; set; }

        public IEnumerable<User> UserModel { get; set; }

    }

    public class StoragerModel
    {
        public IEnumerable<LogDetail> LogDetailModel { get; set; }

        public IEnumerable<Process> ProcessModel { get; set; }

        public IEnumerable<Stock> StockModel { get; set; }

        public IEnumerable<Storage> StorageModel { get; set; }

        public IEnumerable<User> UserModel { get; set; }

    }

    public class CoustomerModel
    {
        public IEnumerable<Process> ProcessModel { get; set; }

        public IEnumerable<Complaint> ComplaintModel { get; set; }
    }
}
