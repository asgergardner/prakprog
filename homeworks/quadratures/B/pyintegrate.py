from scipy.integrate import quad
import numpy as np

def inv_sqrt(x):
    return 1/np.sqrt(x)

def log_sqrt(x):
    return np.log(x)/np.sqrt(x)

delta = 0.001
eps = 0.001
y1, err1, inf1 = quad(inv_sqrt, 0, 1, full_output=True, epsabs=delta, epsrel=eps)
y2, err2, inf2 = quad(log_sqrt, 0, 1, full_output=True, epsabs=delta, epsrel=eps)

print(" 1/sqrt(x) python iterations: ", inf1["neval"])
print(" log(x)/sqrt(x) python iterations: ", inf2["neval"])
