from scipy.integrate import quad
import numpy as np

i = 0
j = 0

def inv_sqrt(x):
    global i
    i+=1
    return 1/np.sqrt(x)

def log_sqrt(x):
    global j
    j+=1
    return np.log(x)/np.sqrt(x)

ysqrt = quad(inv_sqrt, 0, 1)
ylog = quad(log_sqrt, 0, 1)

print("1/sqrt(x) python iterations: ", i)
print("log(x)/sqrt(x) python iterations: ", j)
