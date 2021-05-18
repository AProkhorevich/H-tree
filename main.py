import numpy as np
import matplotlib.pyplot as plt

fig = plt.figure()
# plt.xticks(np.linspace(-4, 4, 9))
# plt.yticks(np.linspace(-4, 4, 9))
# _scale = 2
# plt.xlim(-_scale, _scale)
# plt.ylim(-_scale, _scale)
plt.xticks(np.linspace(-4, 4, 41))
plt.yticks(np.linspace(-4, 4, 41))
plt.xlim(-1.9, -1.4)
plt.ylim(0.8, 1.3)
plt.gca().set_aspect('equal', adjustable='box')

h_list = []
v_list = []
n = int(input('input n parameter > '))
k = float(input('input k parameter > '))
q = float(input('input q parameter > '))
h_list.append((0, 0))
line_len: float = 2.0
while n != 0:
    point: tuple[int, int]
    if h_list:
        for point in h_list:
            delta_left = line_len / (q + 1)
            delta_right = (line_len / (q + 1)) * q
            if line_len > 1:
                plt.hlines(point[1], point[0] - delta_left, point[0] + delta_right, colors='Brown')
            else:
                plt.hlines(point[1], point[0] - delta_left, point[0] + delta_right, colors='Green')
            v_list.append((point[0] + delta_right, point[1]))
            v_list.append((point[0] - delta_left, point[1]))
        h_list.clear()
        line_len /= k
        n -= 1
        # plt.show()
    elif v_list:
        for point in v_list:
            delta_up = line_len / (q + 1)
            delta_down = (line_len / (q + 1)) * q
            plt.vlines(point[0], point[1] - delta_up, point[1] + delta_down, colors='Brown')
            if line_len < 1:
                plt.vlines(point[0], point[1] - delta_up, point[1] + delta_down, colors='Green')
            h_list.append((point[0], point[1] + delta_down))
            h_list.append((point[0], point[1] - delta_up))
        v_list.clear()
        line_len /= k
        n -= 1
        # plt.show()

plt.show()

if input('Would you like to save it to .jpeg? [y/n] > ').lower() == 'y':
    fig.savefig(f"{input('Specify name of the file > ').strip()}.jpeg", bbox_inches='tight')
