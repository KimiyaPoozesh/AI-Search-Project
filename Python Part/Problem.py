import copy

from Action import Action
from Block import Block
from Board import Board
from State import State


class Problem:
    def __init__(self, initState: State):
        self.initState = initState

    @staticmethod
    def goal_test(state: State) -> bool:  # this method check this state is goal or not
        if state.board.red_block.position[1][1] == state.board.width - 1:
            return True
        return False

    @staticmethod
    def check_up(block: Block, board: Board) -> bool:
        if not block.is_vertical or block.position[0][0] == 0 or board.gird[block.position[0][0] - 1][
            block.position[0][1]] != 0:
            return False
        return True

    @staticmethod
    def check_down(block: Block, board: Board) -> bool:
        if not block.is_vertical or block.position[1][0] == board.height - 1 or board.gird[block.position[1][0] + 1][
            block.position[1][1]] != 0:
            return False
        return True

    @staticmethod
    def check_left(block: Block, board: Board) -> bool:
        if block.is_vertical or block.position[0][1] == 0 or board.gird[block.position[0][0]][
            block.position[0][1] - 1] != 0:
            return False
        return True

    @staticmethod
    def check_right(block: Block, board: Board) -> bool:
        if block.is_vertical or block.position[1][1] == board.width - 1 or board.gird[block.position[1][0]][
            block.position[1][1] + 1] != 0:
            return False
        return True

    # this method for every state gives every possible states form this self and return it
    def successor(self, state: State) -> list:
        child = []

        if Problem.check_left(state.board.red_block, state.board):
            temp_loc = state.board.gird[state.board.red_block.position[0][0]][state.board.red_block.position[0][1]]
            Action.left(state.board.red_block, state.board)
            child.append(State(copy.deepcopy(state.board), state, state.g_n + 1, 'left', temp_loc))
            Action.right(state.board.red_block, state.board)

        for i in state.board.blocks:
            temp_loc = state.board.gird[i.position[0][0]][i.position[0][1]]
            if Problem.check_up(i, state.board):
                Action.up(i, state.board)
                child.append(State(copy.deepcopy(state.board), state, state.g_n + 1, 'up', temp_loc))
                Action.down(i, state.board)

            if Problem.check_down(i, state.board):
                Action.down(i, state.board)
                child.append(State(copy.deepcopy(state.board), state, state.g_n + 1, 'down', temp_loc))
                Action.up(i, state.board)

            if Problem.check_left(i, state.board):
                Action.left(i, state.board)
                child.append(State(copy.deepcopy(state.board), state, state.g_n + 1, 'left', temp_loc))
                Action.right(i, state.board)

            if Problem.check_right(i, state.board):
                Action.right(i, state.board)
                child.append(State(copy.deepcopy(state.board), state, state.g_n + 1, 'right', temp_loc))
                Action.left(i, state.board)

        if Problem.check_right(state.board.red_block, state.board):
            temp_loc = state.board.gird[state.board.red_block.position[0][0]][state.board.red_block.position[0][1]]
            Action.right(state.board.red_block, state.board)
            child.append(State(copy.deepcopy(state.board), state, state.g_n + 1, 'right', temp_loc))
            Action.left(state.board.red_block, state.board)

        return child

    @staticmethod
    def print_state(state: State):
        state.board.print_board()

    def set_path_cost(self, cost: list):
        self.path_cost = cost
