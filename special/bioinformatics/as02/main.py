import numpy as np
import matplotlib.pyplot as plt


## Plot the graph given the matrix of ones and zeros and also the x and y axes
def plot_graph(x, y, M):
    X = np.ones(np.shape(M), dtype=int)
    M = X - M

    fig, ax = plt.subplots()
    im = ax.imshow(M, cmap='gray', vmin=0, vmax=1, origin="upper")

    ax.set_xticks(np.arange(len(x)))
    ax.set_yticks(np.arange(len(y)))
    ax.set_xticklabels(x)
    ax.set_yticklabels(y)

    xaxis = ax.get_xaxis()

    xaxis.tick_top()

    ax.set_title("Dot Plot")
    fig.tight_layout()
    plt.savefig('out.png')
    plt.show()

## given two strings get a matrix of zeros and x and y as two lists
def gen_matrix(s1, s2):
    x = list(s1)
    y = list(s2)

    xlen = len(x)
    ylen = len(y)

    M = np.zeros((ylen, xlen), dtype=int)

    return (x, y, M)

## implements the window and search criteria plotting
def cal_sub_dot_plot(x, y, M, x_index, y_index, ws, sc):
    xSub = x[x_index:x_index+ws]
    ySub = y[y_index:y_index+ws]

    tc = 0
    for i in range(ws):
        if xSub[i] == ySub[i]:
            tc += 1

    mid_x_index = x_index+(ws//2)
    mid_y_index = y_index+(ws//2)

    mark_index = [mid_x_index, mid_y_index]

    if tc >= sc:
        M[mark_index[1], mark_index[0]] = 1

## iteratively calls cal_sub_dot_plot giving it the correct indexes each time
def cal_dot_plot(x, y, M, ws, sc):

    x_index = 0
    y_index = 0
    x_len = len(x)
    y_len = len(y)

    while y_index + ws <= y_len:
        x_index = 0
        while x_index + ws <= x_len:
            cal_sub_dot_plot(x, y, M, x_index, y_index, ws, sc)
            x_index += 1
        y_index += 1

if __name__ == "__main__":
    s1 = input("Input Sequence 1: ")
    s2 = input("Input Sequence 2: ")
    ws = int(input("Window Size: "))
    sc = int(input("Search Criteria: "))
    (x, y, M) = gen_matrix(s1, s2)
    cal_dot_plot(x, y, M, ws, sc)
    plot_graph(x, y, M)