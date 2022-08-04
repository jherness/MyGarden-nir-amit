import torch


def generate():
    AVG_TEMP = 25.0 # celsius
    monthly_temp_multiplier = torch.tensor([0.35, 0.4, 0.5, 1, 1.2, 1.3, 1.35, 1.25, 1.1, 1.0, 0.75, 0.6])
    daily_temp_multiplier = torch.Tensor([0.8, 1, 1.2, 0.95, 0.8])

    first_part = torch.ones(5) * AVG_TEMP * daily_temp_multiplier[0]
    second_part = torch.linspace(AVG_TEMP * daily_temp_multiplier[0], AVG_TEMP * daily_temp_multiplier[1], 7)
    third_part = torch.linspace(daily_temp_multiplier[1] * AVG_TEMP ,daily_temp_multiplier[2] *AVG_TEMP, 4)
    fourth_part = torch.linspace(daily_temp_multiplier[2] * AVG_TEMP, daily_temp_multiplier[3] * AVG_TEMP, 4)
    fifth_part = torch.ones(4) * daily_temp_multiplier[4] * AVG_TEMP

    hourly_temp_means = torch.cat([first_part, second_part, third_part, fourth_part, fifth_part])

    january = torch.Tensor()
    march = torch.Tensor()
    may = torch.Tensor()
    july = torch.Tensor()
    august = torch.Tensor()
    october = torch.Tensor()
    december = torch.Tensor()
    april = torch.Tensor()
    june  = torch.Tensor()
    september = torch.Tensor()
    november = torch.Tensor()
    february = torch.Tensor()

    for i in range(31):
      january = torch.cat([january, hourly_temp_means * monthly_temp_multiplier[0]])
      march = torch.cat([march, hourly_temp_means * monthly_temp_multiplier[2]])
      may =  torch.cat([may, hourly_temp_means * monthly_temp_multiplier[4]])
      july  = torch.cat([july, hourly_temp_means * monthly_temp_multiplier[6]])
      august = torch.cat([august, hourly_temp_means * monthly_temp_multiplier[7]])
      october = torch.cat([october, hourly_temp_means * monthly_temp_multiplier[9]])
      december = torch.cat([december, hourly_temp_means * monthly_temp_multiplier[11]])

    for i in range(30):
      april =  torch.cat([april, hourly_temp_means * monthly_temp_multiplier[3]])
      june  = torch.cat([june, hourly_temp_means * monthly_temp_multiplier[5]])
      september = torch.cat([september, hourly_temp_means * monthly_temp_multiplier[8]])
      november =  torch.cat([november, hourly_temp_means * monthly_temp_multiplier[10]])

    for i in range(28):
      february = torch.cat([february, hourly_temp_means * monthly_temp_multiplier[1]])

    std= torch.ones(744) * 0.1
    std_30 = torch.ones(720) * 0.1
    std_28 = torch.ones(672) * 0.1

    january = torch.normal(mean=january, std=std)
    march = torch.normal(mean=march, std=std)
    may = torch.normal(mean=may, std=std)
    july = torch.normal(mean=july, std=std)
    august = torch.normal(mean=august, std=std)
    october = torch.normal(mean=october, std=std)
    december = torch.normal(mean=december, std=std)
    april = torch.normal(mean=april, std=std_30)
    june = torch.normal(mean=june, std=std_30)
    september = torch.normal(mean=september, std=std_30)
    november = torch.normal(mean=november, std=std_30)
    february = torch.normal(mean=february, std=std_28)

    yearly_temp = torch.cat([january, february, march, april, may, june, july, august, september, october, november,december])
    return yearly_temp