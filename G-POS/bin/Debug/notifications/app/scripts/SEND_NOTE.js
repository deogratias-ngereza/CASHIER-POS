var http = require('http');
var Faye = require('faye');
var PORT = 8888;

var client = new Faye.Client('http://localhost:8888/');

var conn = client.publish('/NEW_KITCHEN_ORDER', {
  data: 'NO : '  + Math.random(1000)
});
conn.then(function(s){
	console.log("SUCCESS");
	process.exit();
},function(e){
	console.log("ERROR : " + e);
	process.exit();
});