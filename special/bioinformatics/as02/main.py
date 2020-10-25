import numpy as np
import matplotlib.pyplot as plt


def plot_graph(x, y, M):

    X = np.ones(np.shape(M), dtype=int)
    M = X - M

    fig, ax = plt.subplots()
    im = ax.imshow(M, cmap='gray', vmin=0, vmax=1, origin="upper")

    # We want to show all ticks...
    ax.set_xticks(np.arange(len(x)))
    ax.set_yticks(np.arange(len(y)))
    # ... and label them with the respective list entries
    ax.set_xticklabels(x)
    ax.set_yticklabels(y)

    xaxis = ax.get_xaxis()

    xaxis.tick_top()

    # Rotate the tick labels and set their alignment.
    # plt.setp(ax.get_xticklabels(), rotation=45, ha="right",
    #          rotation_mode="anchor")

    # # Loop over data dimensions and create text annotations.
    # for i in range(len(vegetables)):
    #     for j in range(len(farmers)):
    #         text = ax.text(j, i, harvest[i, j],
    #                        ha="center", va="center", color="w")

    ax.set_title("Dot Plot")
    fig.tight_layout()
    plt.savefig('out.png')
    plt.show()


def gen_matrix(s1, s2):
    x = list(s1)
    y = list(s2)

    xlen = len(x)
    ylen = len(y)

    M = np.zeros((ylen, xlen), dtype=int)

    return (x, y, M)

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

# plot_graph(["A", "C", "T", "G"], ["A", "C", "T", "G"], np.array([[]]))


# import numpy as np
# import matplotlib
# import matplotlib.pyplot as plt
# # sphinx_gallery_thumbnail_number = 2

# vegetables = ["cucumber", "tomato", "lettuce", "asparagus",
#               "potato", "wheat", "barley"]
# farmers = ["Farmer Joe", "Upland Bros.", "Smith Gardening",
#            "Agrifun", "Organiculture", "BioGoods Ltd.", "Cornylee Corp."]

# harvest = np.array([[0.8, 2.4, 2.5, 3.9, 0.0, 4.0, 0.0],
#                     [2.4, 0.0, 4.0, 1.0, 2.7, 0.0, 0.0],
#                     [1.1, 2.4, 0.8, 4.3, 1.9, 4.4, 0.0],
#                     [0.6, 0.0, 0.3, 0.0, 3.1, 0.0, 0.0],
#                     [0.7, 1.7, 0.6, 2.6, 2.2, 6.2, 0.0],
#                     [1.3, 1.2, 0.0, 0.0, 0.0, 3.2, 5.1],
#                     [0.1, 2.0, 0.0, 1.4, 0.0, 1.9, 6.3]])


# fig, ax = plt.subplots()
# im = ax.imshow(harvest)

# # We want to show all ticks...
# ax.set_xticks(np.arange(len(farmers)))
# ax.set_yticks(np.arange(len(vegetables)))
# # ... and label them with the respective list entries
# ax.set_xticklabels(farmers)
# ax.set_yticklabels(vegetables)

# # Rotate the tick labels and set their alignment.
# plt.setp(ax.get_xticklabels(), rotation=45, ha="right",
#          rotation_mode="anchor")

# # Loop over data dimensions and create text annotations.
# for i in range(len(vegetables)):
#     for j in range(len(farmers)):
#         text = ax.text(j, i, harvest[i, j],
#                        ha="center", va="center", color="w")

# ax.set_title("Harvest of local farmers (in tons/year)")
# fig.tight_layout()
# plt.show()