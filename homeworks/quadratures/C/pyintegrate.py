from scipy.integrate import quad
import numpy as np

def inv_xsq(x):
    return 1/(x*x)

def x_ex(x):
    return x*np.exp(-x*x)

def inv_xsq(x):
    return 1/(1+x*x)


y1, err1, inf1 = quad(inv_xsq, 1, np.inf, full_output=True)
y2, err2, inf2 = quad(x_ex, -np.inf, np.inf, full_output=True)
y3, err3, inf3 = quad(inv_xsq, -np.inf, 0, full_output=True)
print("python 1/x^2:", y1, "error:", err1, "iterations:", inf1["neval"])
print("python x_e^-x^2:", y2, "error:", err2, "iterations:", inf2["neval"])
print("python 1/(1-x*x)", y3, "error:", err3, "iterations:", inf3["neval"])
