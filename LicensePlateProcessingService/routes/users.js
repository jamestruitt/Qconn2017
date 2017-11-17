var express = require('express');
var router = express.Router();
var storeLicensePlate = require('../libs/storeLicensePlate');

/* GET users listing. */
router.get('/', function(req, res, next) {
  storeLicensePlate.getAllLicensePlates(function(err,results){
    if(err) throw err;

    res.send(results);
    
  });
  

});

module.exports = router;
