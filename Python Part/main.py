from datetime import datetime

from Board import Board
from Problem import Problem
from Solution import Solution
from State import State
from Search import Search
import ast

if __name__ == '__main__':

    # config base on your system and task
    test_case_number = 2
    search_algo_name = 'bfs'
    username_of_your_system = 'Kimiya'


    print("Calculating... Hee Hee Hee")
    test_path = f'./tests/{test_case_number}.txt'
    start_time = datetime.now()
    file = open(test_path, 'r')
    p = ''
    for i in file.readlines():
        a = i.replace('\n', '')
        a = a.replace(' ', '')
        p += a
    lst = ast.literal_eval(p)
    s = Search.bfs(Problem(State(Board(len(lst), len(lst[0]), lst), None, 0, None, None)))
    if s is None:
        s = Solution(None, None, start_time)
    
    s.save_to_json_file(f'C:/Users/{username_of_your_system}/AppData/LocalLow/KimiyaPzsh/AISearchProject/solution',search_algo_name, f'{test_case_number}.txt')
    print(f'Finished in {datetime.now() - start_time}')