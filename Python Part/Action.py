from Block import Block
from Board import Board


class Action:

    @staticmethod
    def up(block: Block, board: Board):
        board.gird[block.position[1][0]][block.position[1][1]] = 0
        block.position[0][0] -= 1
        block.position[1][0] -= 1
        board.gird[block.position[0][0]][block.position[0][1]] = board.gird[block.position[1][0]][block.position[1][1]]

    @staticmethod
    def down(block: Block, board: Board):
        board.gird[block.position[0][0]][block.position[0][1]] = 0
        block.position[0][0] += 1
        block.position[1][0] += 1
        board.gird[block.position[1][0]][block.position[1][1]] = board.gird[block.position[0][0]][block.position[0][1]]

    @staticmethod
    def left(block: Block, board: Board):
        board.gird[block.position[1][0]][block.position[1][1]] = 0
        block.position[0][1] -= 1
        block.position[1][1] -= 1
        board.gird[block.position[0][0]][block.position[0][1]] = board.gird[block.position[1][0]][block.position[1][1]]

    @staticmethod
    def right(block: Block, board: Board):
        board.gird[block.position[0][0]][block.position[0][1]] = 0
        block.position[0][1] += 1
        block.position[1][1] += 1
        board.gird[block.position[1][0]][block.position[1][1]] = board.gird[block.position[0][0]][block.position[0][1]]
