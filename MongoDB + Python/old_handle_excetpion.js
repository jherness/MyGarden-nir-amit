/Guider
/0- light
/1-moist
/2-irrigiation 
/3-fan




use MongoFinal

db.handle_exception.drop()
db.createCollection("handle_expection")


db.handle_expection.insertMany([
{
    1: [false, false, false, false] 
},
{
    2: [true, true, true, true]
},
{
    3: [false, true, true, true]  
},
{
    4: [true, false, true, true] 
},
{
    5: [true, true, false, true] 
},
{
    6: [true, true, true, false]
},
{
    7: [true, false, false, true] 
},
{
    8: [true, false, false, false]
},
{
    9: [true, false, true, false]
},
{
    10: [true, true, false, false]
},
{
    11: [false, false, true, true]
},
{
    12: [false, true, false, true]
},
{
    13: [false, true, true, false]
},
{
    14: [false, false, false, true]
},
{
    15: [false, false, true, false]
},
{
    16: [false, true, false, false]
}
])