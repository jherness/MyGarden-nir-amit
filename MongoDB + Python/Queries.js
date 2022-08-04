
/*
Before starting please read README-TAMI
*/


// data of date and time is currently set to string,
// first please run these functions to change to date.
use MongoFinal

db.samples.find().forEach(function(d){
	d.datetime_of_sample = new ISODate(d.datetime_of_sample);
	db.samples.save(d)
})

db.activation_history.find().forEach(function(d){
	d.datime_of_activation = new ISODate(d.datime_of_activation);
	db.activation_history.save(d)
})



------- Queries: --------
use MongoFinal

/*
Calculate all the "raw samples" to calculated(avg of all sensors)
avg_samples collection.
*/
use MongoFinal
db.avg_samples.drop()

db.samples.find().forEach((sample) => {
	mongoObj = {}
	mongoObj["id"] = sample.id
	mongoObj["datetime_of_sample"] = sample.datetime_of_sample
	mongoObj["temperature_sensor_data"] = sample.temperature_sensor_data
	mongoObj["light_sensor_data"] = sample.light_sensor_data
	mongoObj["atmosphere_sensors_data"] = (sample.first_atmosphere_sensor_data
	+ sample.second_atmosphere_sensor_data)/2
	mongoObj["moist_sensors_data"] = (sample.first_moist_sensor
	+ sample.second_moist_sensor + sample.third_moist_sensor)/3
	mongoObj["is_raining"] = sample["is_raining"]
	db.avg_samples.insert(mongoObj)
})





/*
Query to count how many times the system was activated
*/
use MongoFinal
var MOIST_MIN = 25, MIN_ATMOS = 1009, LIGHT_MIN = 400, MAX_TEMP = 35;
db.avg_samples.find( {$or: [{temperature_sensor_data: { $gt: MAX_TEMP }},{light_sensor_data : {$lte: LIGHT_MIN}},{atmosphere_sensors_data : { $lte: MIN_ATMOS }},{moist_sensors_data : { $lte: MOIST_MIN }}]}).count()


/*
Function that returns the activation_reason & handle_expction code for a bad sample 
*/
use MongoFinal
var checkSample = (sample) => {
	let code
	if(sample.light_sensor_data > LIGHT_MIN && sample.moist_sensors_data > MOIST_MIN &&
    sample.atmosphere_sensors_data > MIN_ATMOS && sample.temperature_sensor_data<MAX_TEMP)
        code = "1"
    else if(sample.light_sensor_data < LIGHT_MIN && sample.moist_sensors_data < MOIST_MIN &&
    sample.atmosphere_sensors_data < MIN_ATMOS && sample.temperature_sensor_data>MAX_TEMP)
        code = "2"
    else if(sample.light_sensor_data > LIGHT_MIN && sample.moist_sensors_data < MOIST_MIN &&
    sample.atmosphere_sensors_data < MIN_ATMOS && sample.temperature_sensor_data>MAX_TEMP)
        code = "3"
    else if(sample.light_sensor_data < LIGHT_MIN && sample.moist_sensors_data > MOIST_MIN &&
    sample.atmosphere_sensors_data < MIN_ATMOS && sample.temperature_sensor_data>MAX_TEMP)
        code = "4"
    else if(sample.light_sensor_data < LIGHT_MIN && sample.moist_sensors_data < MOIST_MIN &&
    sample.atmosphere_sensors_data > MIN_ATMOS && sample.temperature_sensor_data>MAX_TEMP)
        code = "5"
    else if(sample.light_sensor_data < LIGHT_MIN && sample.moist_sensors_data < MOIST_MIN &&
    sample.atmosphere_sensors_data < MIN_ATMOS && sample.temperature_sensor_data<MAX_TEMP)
        code = "6"
    else if(sample.light_sensor_data < LIGHT_MIN && sample.moist_sensors_data > MOIST_MIN &&
    sample.atmosphere_sensors_data > MIN_ATMOS && sample.temperature_sensor_data>MAX_TEMP)
        code = "7"
    else if(sample.light_sensor_data < LIGHT_MIN && sample.moist_sensors_data > MOIST_MIN &&
          sample.atmosphere_sensors_data > MIN_ATMOS && sample.temperature_sensor_data < MAX_TEMP)
        code = "8"
    else if(sample.light_sensor_data < LIGHT_MIN && sample.moist_sensors_data > MOIST_MIN &&
          sample.atmosphere_sensors_data < MIN_ATMOS && sample.temperature_sensor_data < MAX_TEMP)
        code = "9"
    else if(sample.light_sensor_data < LIGHT_MIN && sample.moist_sensors_data < MOIST_MIN &&
          sample.atmosphere_sensors_data > MIN_ATMOS && sample.temperature_sensor_data < MAX_TEMP)
        code = "10"
    else if(sample.light_sensor_data > LIGHT_MIN && sample.moist_sensors_data > MOIST_MIN &&
          sample.atmosphere_sensors_data < MIN_ATMOS && sample.temperature_sensor_data > MAX_TEMP)
        code = "11"
    else if(sample.light_sensor_data > LIGHT_MIN && sample.moist_sensors_data < MOIST_MIN &&
          sample.atmosphere_sensors_data > MIN_ATMOS && sample.temperature_sensor_data > MAX_TEMP)
        code = "12"
    else if(sample.light_sensor_data > LIGHT_MIN && sample.moist_sensors_data < MOIST_MIN &&
          sample.atmosphere_sensors_data < MIN_ATMOS && sample.temperature_sensor_data < MAX_TEMP)
        code = "13"
    else if(sample.light_sensor_data > LIGHT_MIN && sample.moist_sensors_data > MOIST_MIN &&
    sample.atmosphere_sensors_data > MIN_ATMOS && sample.temperature_sensor_data > MAX_TEMP)
        code = "14"
    else if(sample.light_sensor_data > LIGHT_MIN && sample.moist_sensors_data > MOIST_MIN &&
    sample.atmosphere_sensors_data < MIN_ATMOS && sample.temperature_sensor_data < MAX_TEMP)
        code = "15"
    else if(sample.light_sensor_data > LIGHT_MIN && sample.moist_sensors_data < MOIST_MIN &&
    sample.atmosphere_sensors_data > MIN_ATMOS && sample.temperature_sensor_data < MAX_TEMP)
        code = "16"
	return code;
}



/*
Creating activation history collection based on the avg_samples
collection, and creating the activation history of the system.
*/
use MongoFinal
db.activation_history.drop()

var MOIST_MIN = 25, MIN_ATMOS = 1009,LIGHT_MIN = 400, MAX_TEMP = 35, id = 0;
var cursor = db.avg_samples.find( {$or: [{temperature_sensor_data: { $gt: MAX_TEMP }},{light_sensor_data : {$lte: LIGHT_MIN}},{atmosphere_sensors_data : { $lte: MIN_ATMOS }},{moist_sensors_data : { $lte: MOIST_MIN }}]})
while(cursor.hasNext()){
	let sample = cursor.next()
	let newDoc = {}, code = checkSample(sample)
	newDoc["id"] = id++;
	newDoc["datetime_of_activation"] = sample.datetime_of_sample
	newDoc["activation_reason"] = db.activation_reason.findOne({"_id":code}).msg,
    newDoc["handle_code"] = db.handle_exception.findOne({"_id":code}).code
	db.activation_history.insert(newDoc)
}

/*calculating how many times each "exception"(temp too high, dry....) occurred.*/
use MongoFinal
db.activation_history.mapReduce(
	function(){emit(this.activation_reason, 1)},
	function(key, values) { return Array.sum(values)},{
		 out: "ex_counters"
	 }
)


/*
Get most commen exception that triggered the system.
*/
use MongoFinal
db.ex_counters.find().sort({value:-1}).limit(1)



/*
Export data to csv useing command line.
*/
use MongoFinal
mongoexport --db=MongoFinal --collection=avg_samples --type=csv --fields=id, datetime_of_sample,temperature_sensor_data, light_sensor_data,atmosphere_sensors_data, moist_sensors_data,is_raining  --out=data/avg_samples.csv



/*
Get the lateset sample and check if valid
*/
use MongoFinal
db.samples.find().sort({datetime_of_sample:-1}).limit(1).map(
	(ls) => {
		if(checkSample(ls) != "1")
			return false;
		return true;
	}
)


/*
Check if rainning
*/
use MongoFinal
var isRaining = (sample) => {
	if(sample.atmosphere_sensors_data < MIN_ATMOS && sample.temperature_sensor_data < 20)
		return true
	return false
} 





















