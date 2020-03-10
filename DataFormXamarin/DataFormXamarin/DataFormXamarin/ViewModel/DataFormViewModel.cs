using System;
using System.Collections.Generic;
using System.Text;

namespace DataFormXamarin
{
    class DataFormViewModel
    {
        private DataFormModel contacts;

        public DataFormModel Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }
        public DataFormViewModel()
        {
            this.contacts = new DataFormModel();
        }
    }
}
