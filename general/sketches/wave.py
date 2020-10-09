import matplotlib
import matplotlib.pyplot as plt
import numpy as np

A = 1
f = 1
# phi = 0
phi = np.pi/2
Fs = 44100
t = np.arange(0, 2, 1.0/Fs)
s = A * np.sin(2*np.pi * f * t + phi)

# plt.plot(t, s)

def findF(signal, f, phi):
    # L = len(signal)
    x = np.arange(0, 2, 1.0/Fs)
    z = np.exp(x*1j*f+phi)
    F = signal * z
    Freal = [i.real for i in F]
    Fimag = [i.imag for i in F]
    return (Freal, Fimag, sum(Freal) + sum(Fimag))

# fsearch = np.arange(max(f-5, 0.1), f+5, 0.1)
# for ff in fsearch:
#     Freal, Fimag, Fval = findF(s, ff, 0)
#     print(ff, Fval)
    # plt.plot(Freal, Fimag)

Freal, Fimag, Fval = findF(s, 2, 0)
print(2, Fval)
plt.plot(Fimag, Freal)

# Freal, Fimag, Fval = findF(s, 3, 0)
# print(3, Fval)
# plt.plot(Fimag, Freal)

# Freal, Fimag, Fval = findF(s, 4, 0)
# print(4, Fval)
# plt.plot(Fimag, Freal)

plt.show()

# # Data for plotting
# t = np.arange(0.0, 2.0, 0.01)
# s = 1 + np.sin(2 * np.pi * t)

# # Note that using plt.subplots below is equivalent to using
# # fig = plt.figure() and then ax = fig.add_subplot(111)
# fig, ax = plt.subplots()
# ax.plot(t, s)

# ax.set(xlabel='time (s)', ylabel='voltage (mV)',
#        title='About as simple as it gets, folks')
# ax.grid()

# fig.savefig("test.png")
# plt.show()