
def generate(atmosphere_sensor_data, yearly_temp):
    is_raining = atmosphere_sensor_data <= 1009
    is_raining_2 = yearly_temp < 20
    is_raining = is_raining * is_raining_2
    return is_raining.tolist()