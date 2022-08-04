0 - light
1 -moist
2 - irrigiation 
3 - fan


use MongoFinal

db.activation_reason.drop()
db.createCollection("activation_reason")

db.activation_reason.insertMany([
{
	_id : "1",
    msg: "Everthing Is Under Control"
},
{
	_id : "2",
    msg: "Houston Is Under Control"
},
{
	_id : "3",
    msg: "Dry Surface , Low Pressure And Hot Temperature "
},
{
	_id : "4",
    msg: "No Light , Low Pressure And Hot Temperature" 
},
{
	_id : "5",
    msg: "No Light , Dry Surface And Hot Temperature"
},
{
	_id : "6",
    msg: "No Light , Dry Surface And Low Pressure"
},
{
	_id : "7",
    msg: "No Light And Hot Temperature"
},
{
	_id : "8",
    msg: "No Light"
},
{
	_id : "9",
    msg: "No Light And Low Pressure" 
},
{
	_id : "10",
    msg: "No Light And Dry Surface"
},
{
	_id : "11",
    msg: "Low Pressure And Hot Temperature"
},
{
	_id : "12",
    msg: "Dry Surface And Hot Outside" 
},
{
	_id : "13",
    msg: "Dry Surface And Low Pressure"
},
{
	_id : "14",
    msg: "Hot Temperature"
},
{
	_id : "15",
    msg: "Low Pressure"
},
{
	_id : "16",
    msg: "Dry Surface"
},
{
	_id : "17",
    msg: "Scheduled Activition"
},
{
	_id : "18",
    msg: "Manual Activition"
}])