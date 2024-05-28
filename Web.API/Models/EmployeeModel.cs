using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Web.API.Models
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
        public string state { get; set; }
        public string phonenumber { get; set; }
        public int userID { get; set; }
    }
}
