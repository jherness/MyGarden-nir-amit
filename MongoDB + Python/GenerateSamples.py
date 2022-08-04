import datetime
import GenrateRainData as is_raining_generator
import GenerateLumensData as lumens_generator
import GenerateMoistData as humidity_generator
import GenerateTempData as temperature_generator
import GenerateAtmosData as atmosphere_pressure_generator


def generate():
  """
  Randomizes and generates data according to our project demands.
  Data generated is considered of time of the day, season, amount of days in months and so on..
  :return: A list of dictionary's (documents)
  """
  yearly_lumens_data = lumens_generator.generate()
  first_moist_sensor, second_moist_sensor, third_moist_sensor = humidity_generator.generate()
  yearly_temp = temperature_generator.generate()
  atmosphere_sensor_data = atmosphere_pressure_generator.generate()
  is_raining = is_raining_generator.generate(atmosphere_sensor_data, yearly_temp)

  collection = []
  yearly_temp = yearly_temp.tolist()  # yearly_temp is currently a tensor, must be converted.
  atmosphere_sensor_data = atmosphere_sensor_data.tolist()  # currently a tensor, must be converted.
  ts = datetime.datetime(2021,1,1,0,0,0)  # The begging of our samples datetime
  delta = datetime.timedelta(hours=1,)  # the amount of which we increase our ts. the diff between each sample
  # is precisely one hour

  for i in range(8760):  # 8760 is the amount of samples we get for one sample every hour, for a year (365 * 24)
    mongo_obj = {}
    mongo_obj['id'] = i
    mongo_obj['datetime_of_sample'] = str(ts + delta * i)  # delta * i will give us the last sample created + one hour.
    mongo_obj['light_sensor_data'] = yearly_lumens_data[i]
    mongo_obj['first_moist_sensor'] = first_moist_sensor[i]
    mongo_obj['second_moist_sensor'] = second_moist_sensor[i]
    mongo_obj['third_moist_sensor'] = third_moist_sensor[i]
    mongo_obj['first_atmosphere_sensor_data'] = atmosphere_sensor_data[i]
    mongo_obj['second_atmosphere_sensor_data'] = atmosphere_sensor_data[i]
    mongo_obj['is_raining'] = is_raining[i]
    mongo_obj['temperature_sensor_data'] = yearly_temp[i]
    collection.append(mongo_obj)
  return collection














