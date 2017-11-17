
var storteLicensePlate = require('./storeLicensePlate');

var processMessage = {

  processUploadMessage: function (message) {


    // Setup Call for OpenALPR
    var OpenalprApi = require('openalpr_api');

    var apiInstance = new OpenalprApi.DefaultApi();

    var imageUrl = message.URL; // String | A URL to an image that you wish to analyze 

    var secretKey = process.env.OPENALPRAPI_SECRET; // String | The secret key used to authenticate your account.  You can view your  secret key by visiting  https://cloud.openalpr.com/ 

    var country = "us"; // String | Defines the training data used by OpenALPR.  \"us\" analyzes  North-American style plates.  \"eu\" analyzes European-style plates.  This field is required if using the \"plate\" task  You may use multiple datasets by using commas between the country  codes.  For example, 'au,auwide' would analyze using both the  Australian plate styles.  A full list of supported country codes  can be found here https://github.com/openalpr/openalpr/tree/master/runtime_data/config 

    var opts = {
      'recognizeVehicle': 1, // Integer | If set to 1, the vehicle will also be recognized in the image This requires an additional credit per request 
      'state': "", // String | Corresponds to a US state or EU country code used by OpenALPR pattern  recognition.  For example, using \"md\" matches US plates against the  Maryland plate patterns.  Using \"fr\" matches European plates against  the French plate patterns. 
      'returnImage': 1, // Integer | If set to 1, the image you uploaded will be encoded in base64 and  sent back along with the response 
      'topn': 10, // Integer | The number of results you would like to be returned for plate  candidates and vehicle classifications 
      'prewarp': "" // String | Prewarp configuration is used to calibrate the analyses for the  angle of a particular camera.  More information is available here http://doc.openalpr.com/accuracy_improvements.html#calibration 
    };

    var callback = function (error, data, response, url) {
      if (error) {
        console.error(error);
      } else {

        if (data.results[0].plate) {
          console.log('Successful API Open Alpr Api call');
          console.log('Plate: ' + data.results[0].plate);
          console.log('Region: ' + data.results[0].region);
          console.log("Body Type: " + data.results[0].vehicle.body_type[0].name);
          console.log("Color: " + data.results[0].vehicle.color[0].name);
          console.log("Make: " + data.results[0].vehicle.make[0].name);
          console.log("Make_Model: " + data.results[0].vehicle.make_model[0].name);
          console.log("Image_Bytes_prefix: " + response.body.image_bytes_prefix);

          var licensePlateinfo = {};
          licensePlateinfo.plate = data.results[0].plate;
          licensePlateinfo.state = data.results[0].region;
          licensePlateinfo.body_type = data.results[0].vehicle.body_type[0].name;
          licensePlateinfo.color = data.results[0].vehicle.color[0].name;
          licensePlateinfo.make = data.results[0].vehicle.make[0].name;
          licensePlateinfo.make_model = data.results[0].vehicle.make_model[0].name;
          licensePlateinfo.image_bytes = response.body.image_bytes;
          licensePlateinfo.image_bytes_prefix = response.body.image_bytes_prefix;

          // Store License Plate info
          storteLicensePlate.saveLicensePlate(licensePlateinfo);
        } else {
          console.log('No Plate Found: ' + message.URL);
        };
      }
    };

    // Make API Call
    apiInstance.recognizeUrl(imageUrl, secretKey, country, opts, callback);
  }
};

module.exports = processMessage