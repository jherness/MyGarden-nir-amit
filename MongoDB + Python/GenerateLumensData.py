import torch
from matplotlib import pyplot as plt


def generate():
  x = torch.arange(8760)#יוצר מערך מסוג tensor (מבנה נתונים של pytorch) המכיל את כל המספרים השלמים מ1-8760
  first_part = torch.ones(5) * 380
  second_part = torch.linspace(400, 800, 7)
  third_part = torch.linspace(800,750, 4)
  fourth_part = torch.linspace(750, 400, 4)
  fifth_part = torch.ones(4) * 380

  jan_march = torch.linspace(200, 400, 90 * 24)
  april_august = torch.linspace(400, 550, 153 * 24)
  sep_dec = torch.linspace(550, 180, 122 * 24)

  means = torch.cat([jan_march, april_august, sep_dec])
  stds = torch.full_like(x, 10)

  d = torch.normal(mean=means, std=stds)
  # plt.plot(d)#גרף המציג את הממומצע של כמות האור היומית לאורך השנה
  # plt.xlabel("1.1.2021 - 31.12.2021")
  # plt.ylabel("Lumens")
  # plt.xticks([730, 730*2, 730 * 3,730 *  4,730 *  5,
  #             730 * 6,730 *  7,730 *  8,730 *  9,730 *  10,730 *  11, 730 * 12],
  #            ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
  #                        'Jul', 'Aug', 'Sep', 'Oct', 'Nov','Dec'],
  #      rotation=20)
  # plt.title("Yearly lumens avg 2021")
  # plt.savefig("Yearly lumens avg 2021.png")


  hourly_means = torch.cat([first_part, second_part, third_part, fourth_part, fifth_part])
  monthly_multiplier = torch.Tensor([0.8, 0.85, 0.9, 1.0, 1.0, 1.2, 1.3, 1.2, 1.1, 0.9, 0.8, 0.75])
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
    january = torch.cat([january, hourly_means * monthly_multiplier[0]])
    march = torch.cat([march, hourly_means * monthly_multiplier[2]])
    may =  torch.cat([may, hourly_means * monthly_multiplier[4]])
    july  = torch.cat([july, hourly_means * monthly_multiplier[6]])
    august = torch.cat([august, hourly_means * monthly_multiplier[7]])
    october = torch.cat([october, hourly_means * monthly_multiplier[9]])
    december = torch.cat([december, hourly_means * monthly_multiplier[11]])

  for i in range(30):
    april =  torch.cat([april, hourly_means * monthly_multiplier[3]])
    june  = torch.cat([june, hourly_means * monthly_multiplier[5]])
    september = torch.cat([september, hourly_means * monthly_multiplier[8]])
    november =  torch.cat([november, hourly_means * monthly_multiplier[10]])

  for i in range(28):
    february = torch.cat([february, hourly_means * monthly_multiplier[1]])

  std= torch.ones(744)
  std_30 = torch.ones(720)
  std_28 = torch.ones(672)

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

  yearly = torch.cat([january, february, march, april, may, june, july, august, september, october, november,december])
  # plt.close()
  # plt.plot(yearly)
  # plt.xlabel("Months")
  # plt.ylabel("Lumens")
  # plt.xticks([400, 550*2, 600 * 3,620 *  4,650 *  5,
  #             660 * 6,680 *  7,690 *  8,690 *  9,700 *  10,700 *  11, 700 * 12],
  #            ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
  #                        'Jul', 'Aug', 'Sep', 'Oct', 'Nov','Dec'],
  #        rotation=20)
  # plt.title("Monthly lumens mins and maxs for 2021")
  # plt.savefig("Monthly lumens mins and maxs for 2021.png")

  return yearly.tolist()

