
var MongoClient = require('mongodb').MongoClient;
var url = process.env.MONGO_DATABASE;
var collection = process.env.MONGO_DB_COLLECTION;
var ObjectID = require('mongodb').ObjectID;

var storeLicensePlate = {    
    
    saveLicensePlate: function (licenseplate) {
        
        // Create New ID
        licenseplate._id = new ObjectID;

        MongoClient.connect(url, function(err, db) {
            if (err) throw err;
            db.collection(collection).insertOne(licenseplate, function(err, res) {
              if (err) throw err;
              console.log("1 document inserted");
              db.close();
            });
          });
 
    },
    getAllLicensePlates: function(callback){
        MongoClient.connect(url,function(err,db){
            if(err) throw err;

            db.collection(collection).find({}).toArray(function(err,result){
                if (err) throw err;
                 callback(null,result[0]);
                db.close();
            })
        })
    }
};

module.exports = storeLicensePlate