import torch

def generate():
    x = torch.ones(8760)
    moists_1 = torch.normal(mean=50, std=10, size=x.shape).tolist()
    moists_2 = torch.normal(mean=50, std=10, size=x.shape).tolist()
    moists_3 = torch.normal(mean=50, std=10, size=x.shape).tolist()
    return moists_1,moists_2,moists_3