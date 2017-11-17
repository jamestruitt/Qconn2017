var express = require('express');
var router = express.Router();
var storeLicensePlate = require('../libs/storeLicensePlate');

/* GET home page. */
router.get('/',function(req, res, next) {
  storeLicensePlate.getAllLicensePlates(function(err,result){
    if(err) throw err;
    res.render('index', { title: 'License Plate POC', plate: result });
  });
});

module.exports = router;
