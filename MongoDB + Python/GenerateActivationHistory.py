import pymongo

def get_collection_from_db(collection_name:str, client_address:str):
    collection = {}
    client = pymongo.MongoClient(client_address)
    db = client["MongoFinal"]
    col = db[collection_name]
    for i,x in enumerate(col.find()):
        collection[str(i+1)] = x[str(i+1)]
    return collection


def check_sample(sample):
    MOIST_MIN = 25
    LIGHT_MIN = 400
    MAX_TEMP = 35
    MIN_ATMOS = 1009
    moist_sensors_avg = (sample['first_moist_sensor'] + sample['second_moist_sensor'] +
                         sample['third_moist_sensor']) / 3
    atmosphere_pressure_avg = (sample['first_atmosphere_sensor_data'] + sample['second_atmosphere_sensor_data']) / 2

    if(sample['light_sensor_data'] > LIGHT_MIN and moist_sensors_avg > MOIST_MIN and
    atmosphere_pressure_avg > MIN_ATMOS and sample['temperature_sensor_data']<MAX_TEMP):
        return '1'
    elif(sample['light_sensor_data'] < LIGHT_MIN and moist_sensors_avg < MOIST_MIN and
    atmosphere_pressure_avg < MIN_ATMOS and sample['temperature_sensor_data']>MAX_TEMP):
        return '2'
    elif(sample['light_sensor_data'] > LIGHT_MIN and moist_sensors_avg < MOIST_MIN and
    atmosphere_pressure_avg < MIN_ATMOS and sample['temperature_sensor_data']>MAX_TEMP):
        return '3'
    elif(sample['light_sensor_data'] < LIGHT_MIN and moist_sensors_avg > MOIST_MIN and
    atmosphere_pressure_avg < MIN_ATMOS and sample['temperature_sensor_data']>MAX_TEMP):
        return '4'
    elif(sample['light_sensor_data'] < LIGHT_MIN and moist_sensors_avg < MOIST_MIN and
    atmosphere_pressure_avg > MIN_ATMOS and sample['temperature_sensor_data']>MAX_TEMP):
        return '5'
    elif(sample['light_sensor_data'] < LIGHT_MIN and moist_sensors_avg < MOIST_MIN and
    atmosphere_pressure_avg < MIN_ATMOS and sample['temperature_sensor_data']<MAX_TEMP):
        return '6'
    elif(sample['light_sensor_data'] < LIGHT_MIN and moist_sensors_avg > MOIST_MIN and
    atmosphere_pressure_avg > MIN_ATMOS and sample['temperature_sensor_data']>MAX_TEMP):
        return '7'
    elif(sample['light_sensor_data'] < LIGHT_MIN and moist_sensors_avg > MOIST_MIN and
          atmosphere_pressure_avg > MIN_ATMOS and sample['temperature_sensor_data'] < MAX_TEMP):
        return '8'
    elif(sample['light_sensor_data'] < LIGHT_MIN and moist_sensors_avg > MOIST_MIN and
          atmosphere_pressure_avg < MIN_ATMOS and sample['temperature_sensor_data'] < MAX_TEMP):
        return '9'
    elif(sample['light_sensor_data'] < LIGHT_MIN and moist_sensors_avg < MOIST_MIN and
          atmosphere_pressure_avg > MIN_ATMOS and sample['temperature_sensor_data'] < MAX_TEMP):
        return '10'
    elif(sample['light_sensor_data'] > LIGHT_MIN and moist_sensors_avg > MOIST_MIN and
          atmosphere_pressure_avg < MIN_ATMOS and sample['temperature_sensor_data'] > MAX_TEMP):
        return '11'
    elif(sample['light_sensor_data'] > LIGHT_MIN and moist_sensors_avg < MOIST_MIN and
          atmosphere_pressure_avg > MIN_ATMOS and sample['temperature_sensor_data'] > MAX_TEMP):
        return '12'
    elif(sample['light_sensor_data'] > LIGHT_MIN and moist_sensors_avg < MOIST_MIN and
          atmosphere_pressure_avg < MIN_ATMOS and sample['temperature_sensor_data'] < MAX_TEMP):
        return '13'
    elif(sample['light_sensor_data'] > LIGHT_MIN and moist_sensors_avg > MOIST_MIN and
    atmosphere_pressure_avg > MIN_ATMOS and sample['temperature_sensor_data'] > MAX_TEMP):
        return '14'
    elif(sample['light_sensor_data'] > LIGHT_MIN and moist_sensors_avg > MOIST_MIN and
    atmosphere_pressure_avg < MIN_ATMOS and sample['temperature_sensor_data'] < MAX_TEMP):
        return '15'
    elif(sample['light_sensor_data'] > LIGHT_MIN and moist_sensors_avg < MOIST_MIN and
    atmosphere_pressure_avg > MIN_ATMOS and sample['temperature_sensor_data'] < MAX_TEMP):
        return '16'


def generate(samples_collection):
    activation_history_collection = []
    activation_reason_collection = get_collection_from_db("activation_reason", f'mongodb://127.0.0.1:27017/')
    handle_expection_collection = get_collection_from_db("handle_expection", f'mongodb://127.0.0.1:27017/')
    index = 0
    for sample in samples_collection:
        sample_code = check_sample(sample)
        if (sample_code == '1'):
            # TODO:"Create a function that sends to drivers a list of [False,False,False,False]
            #  so that any handled exception transmission will stop working"
            continue
        else:
            mongo_obj = {}
            mongo_obj['id'] = index
            mongo_obj['datime_of_activation'] = sample['datetime_of_sample']
            mongo_obj['activation_reason'] = activation_reason_collection[sample_code]
            mongo_obj['handle_code'] = handle_expection_collection[sample_code]
            index += 1
            activation_history_collection.append(mongo_obj)
    return activation_history_collection


