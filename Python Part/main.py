from datetime import datetime

from Board import Board
from Problem import Problem
from Solution import Solution
from State import State
from Search import Search
import ast

if __name__ == '__main__':
    test_path = './tests/test2.txt'
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
    else:
        s.print_path()
    s.save_to_json_file('test1', 'bfs', 'test2.txt')
