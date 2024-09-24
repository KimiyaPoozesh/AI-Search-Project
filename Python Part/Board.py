from Block import Block


class Board:
    def __init__(self, width: int, height: int, gird: list):
        self.width = width
        self.height = height
        self.gird = gird
        self.blocks = []
        self.red_block = None
        self.gird_to_blocks()

    def gird_to_blocks(self):
        n = 1
        for r in range(self.height):
            for c in range(self.width):
                if self.gird[r][c] == n:
                    if self.height > r + 1 and self.gird[r + 1][c] == n:
                        self.blocks.append(Block([[r, c], [r + 1, c]]))
                    elif self.width > c + 1 and self.gird[r][c + 1] == n:
                        self.blocks.append(Block([[r, c], [r, c + 1]]))
                    n += 1
                elif self.gird[r][c] == -1 and self.gird[r][c + 1] == -1:
                    self.red_block = Block([[r, c], [r, c + 1]])

    def print_board(self):
        for i in self.gird:
            for j in i:
                if j == -1:
                    print('*', end=' ')
                else:
                    print(j, end=' ')
            print()

    def __hash__(self):
        hash_string = ''
        for i in self.gird:
            for j in i:
                hash_string += str(j) + '###'
            hash_string += '$$$'
        return hash_string
