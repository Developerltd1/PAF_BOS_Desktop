using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAF_BOS.Classes
{
    public class ModelForExcel
    {


        public string Name
        {
            get { return Name; }
            set {
                 if(string.IsNullOrEmpty(value))
                    throw new ArgumentException
                    ("Name cannot be blank","Name");
                 Name = value;
                }
        }

        public string CadetName { get; set; }
        public string Fname { get; set; }
        public string PakNo { get; set; }
        public string Address { get; set; }
        public string Cnic { get; set; }
        public string Blood { get; set; }
        public string Contact { get; set; }
        public string Mobile { get; set; }
        public string Pic { get; set; }
        public string RFID { get; set; }
        public string SQN_UserID { get; set; }
        public string Course_ID { get; set; }
        public string Tape_ID { get; set; }
        public string Role_ID { get; set; }

    }
}
