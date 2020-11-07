using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Inmueble
    {
        private string _id;
        private string title;
        private string description;
        private string address;
        private string ubication;
        private float price;
        private int stars;
        private string uri;

        public Inmueble(string _id, string title, string description, string address, string ubication, float price, string uri) 
        {
            this._id = _id;
            this.title = title;
            this.description = description;
            this.address = address;
            this.ubication = ubication;
            this.price = price;
            this.uri = uri;
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Ubication
        {
            get { return ubication; }
            set { ubication = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Stars
        {
            get { return stars; }
            set { stars = value; }
        }

        public string Uri
        {
            get { return uri; }
            set { uri = value; }
        }
    }
}
