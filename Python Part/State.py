# this class only for the first time setup init state for problem and is given to every search
from Board import Board


class State:
    def __init__(self, board: Board, parent, g_n: int, direction: str, piece: int):
        self.board = board
        self.parent = parent
        self.g_n = g_n
        self.direction = direction
        self.piece = piece

    def __hash__(self):
        return self.board.__hash__()

    def __lt__(self, other):
        return 0
    def __h_n__(self):
        return (self.board.width - 1) - self.board.red_block.position[1][1]