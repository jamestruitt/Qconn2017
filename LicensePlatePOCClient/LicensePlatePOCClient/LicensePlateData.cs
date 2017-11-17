using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicensePlatePOCClient
{
    class LicensePlateData
    {
        public string plate;
        public string state;
        public string body_type;
        public string color;
        public string make;
        public string make_model;
        public string image_bytes;
        public string image_bytes_prefix;
        public ObjectId _id;

    }
}
