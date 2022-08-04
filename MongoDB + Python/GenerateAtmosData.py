import torch

def generate():
    x = torch.ones(8760)
    atmosphere_sensor_data = torch.normal(1012.5, 3.46, x.shape)
    return atmosphere_sensor_data