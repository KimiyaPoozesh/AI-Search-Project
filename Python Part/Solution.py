from Problem import Problem
from State import State
from datetime import datetime
import json


class Solution:
    def __init__(self, state: State, problem: Problem, start_time):
        self.state = state
        self.problem = problem
        self.duration = datetime.now() - start_time

    def print_path(self):  # this for show path of every search how it's done
        queue = []
        state = self.state.parent
        while state is not None:
            queue.insert(0, state)
            state = state.parent
        print('Init State')
        self.problem.print_state(queue[0])
        for state in queue[1:]:
            print('---------\n')
            self.problem.print_state(state)
        print('---------\n')
        print('Solution State')
        self.problem.print_state(self.state)
        print('duration = ' + str(self.duration))

    def save_to_json_file(self, name: str, algo: str, test_name: str):
        output = {'algorithm': algo, 'test_case': test_name, 'duration': str(self.duration), "moves": [],
                  'is_done': True}
        if self.state is None:
            output['is_done'] = False
        else:
            queue = []
            state = self.state.parent
            while state is not None:
                queue.insert(0, state)
                state = state.parent
            for state in queue[1:]:
                output['moves'].append({"piece": state.piece, "direction": state.direction})
            output['moves'].append({"piece": self.state.piece, "direction": self.state.direction})

        with open(f'{name}.json', 'w') as json_file:
            json.dump(output, json_file, indent=4)
