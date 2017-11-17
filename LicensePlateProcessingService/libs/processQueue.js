
var azure = require('azure-storage');
var processMessage = require('./processMessage')

var processQueue = {    
    
    processUploadQueue:function () { 
        
        var inputQueue = process.env.LICENSE_PLATE_INPUT_QUEUE;
        
        console.log('Checking the Upload Queue');
        var queueSvc = azure.createQueueService();
          
        queueSvc.getMessage(inputQueue, function(error, result, response){
            if(!error){
                if(result){

                    // Message text is in messages.messageText
                    var rawMessage = result;

                    // Delete Message from Queue
                    queueSvc.deleteMessage(inputQueue, result.messageId, result.popReceipt, function(error, response){
                        if(!error){
                        console.log("messageID deleted: " + result.messageId);
                          }
                     });
                    
                    console.log(rawMessage.messageText)

                    // Create Object from JSON in Message Text
                    var messageObj = JSON.parse(rawMessage.messageText);

                    // Process the Message
                    processMessage.processUploadMessage(messageObj);
              } else
              {
                  console.log("No messages were found");
              }
            }
         });
    }
};

module.exports = processQueue