
use MongoFinal

db.samples.drop()
db.createCollection("samples")
/*insert samples manually, in reality there's a python program
that will handle the loading of data to the DB (loader).
all the data in this colllection is already calibrated to the correct format
by the Python drivers and loader (the loader is the python program that activates and
"sends" the data from the drivers to the DB using MQTT format)
Formats:

Date = yyyy-mm-dd hh:mm:ss, represents date and time in one obj.
	d.getFullYear() returns full year(2022), d.getMonth() returns 0-11,
	d.getDate returns day of month, d.getUTCHours() returns 0-23,
	getUTCMinutes() returns 0-59, getUTCSecondes returns 0-59.
	
light sensor data = float number, representing lumens measurement.
	Everything abouve 400 is considered day light, anything below is night light

moist sensors data = float number, representing the amount of water vapor in the air(humidity).
	0-100 (in percentages). diffrent data from diffrent sensors could be the result
	of sensors deployed at diffrent locations
	
atmosphere sensors data = float number, representing the atmospheric pressure(inMd).
    high pressure is associated with clear skies and calm weather(x>1022.689),
	normal pressure is associated with steady weather.(1022.689>x>1009.144), 
	low pressure is associated with warm air and rainstorms(x>1009.144).
	diffrent data from diffrent sensors could be the result
	of sensors deployed at diffrent locations although it is higly unlikely.
	
tempreature sensor data = float number, representing degrees in celcius.
	
isRaining data = Boolean.
	data calculated from atmosphere data and tempreature data*/

db.samples.insertMany(
)