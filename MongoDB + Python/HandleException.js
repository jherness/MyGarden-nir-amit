/Guider
/0- light
/1-moist
/2-irrigiation 
/3-fan




use MongoFinal

db.handle_exception.drop()
db.createCollection("handle_exception")


db.handle_exception.insertMany([
{
	_id : "1",
    code: [false, false, false, false] 
},
{
	_id : "2",
     code: [true, true, true, true]
},
{
	_id : "3",
	code: [false, true, true, true] 
},
{
	_id : "4",
	code: [true, false, true, true] 
},
{
	_id : "5",
	code: [true, true, false, true] 
},
{
	_id : "6",
    code: [true, true, true, false]
},
{
	_id : "7",
    code: [true, false, false, true] 
},
{
	_id : "8",
    code: [true, false, false, false]
},
{
	_id : "9",
    code: [true, false, true, false] 
},
{
	_id : "10",
    code: [true, true, false, false]
},
{
	_id : "11",
    code: [false, false, true, true]
},
{
	_id : "12",
    code: [false, true, false, true] 
},
{
	_id : "13",
    code: [false, true, true, false]
},
{
	_id : "14",
    code: [false, false, false, true] 
},
{
	_id : "15",
    code: [false, false, true, false]
},
{
	_id : "16",
    code: [false, true, false, false]
}])