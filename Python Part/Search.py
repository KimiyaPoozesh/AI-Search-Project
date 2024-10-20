from Solution import Solution
from Problem import Problem
from datetime import datetime


class Search:
    @staticmethod
    def bfs(prb: Problem) -> Solution:  # this method get a first state of Problem and do bfs for find solution if no
        # solution is find return None else return the solution
        start_time = datetime.now()
        queue = []
        state = prb.initState
        queue.append(state)
        max_counter =20000
        while len(queue) > 0 or max_counter > 0:
            max_counter -= 1
            state = queue.pop(0)
            neighbors = prb.successor(state)
            for c in neighbors:
                if prb.goal_test(c):
                    print(max_counter)
                    return Solution(c, prb, start_time)
                queue.append(c)
        
        return None

    @staticmethod
    def dfs(prb: Problem) -> Solution:
        start_time = datetime.now()
        queue = []
        state = prb.initState
        queue.append(state)
        max_counter = 200
        while len(queue) > 0 or max_counter > 0:
            max_counter -= 1
            state = queue.pop()
            neighbors = prb.successor(state)
            for c in neighbors:
                if prb.goal_test(c):
                    return Solution(c, prb, start_time)
                queue.append(c)
        return None


    @staticmethod
    def dfs_with_explore(
            prb: Problem) -> Solution:
        start_time = datetime.now()
        queue = []
        state = prb.initState
        queue.append(state)
        exp = {}
        while len(queue) > 0:
            state = queue.pop()
            exp[state.__hash__()] = 1
            neighbors = prb.successor(state)
            for c in neighbors:
                if prb.goal_test(c):
                    return Solution(c, prb, start_time)
                if not c.__hash__() in exp:
                    queue.append(c)
        return None

    @staticmethod
    def __dfs_with_limit(prb: Problem,
                         limit: int) -> Solution:
        start_time = datetime.now()
        queue = []
        state = prb.initState
        queue.append(state)
        while len(queue) > 0:
            state = queue.pop()
            neighbors = prb.successor(state)
            for c in neighbors:
                if prb.goal_test(c):
                    return Solution(c, prb, start_time)
                if c.g_n <= limit:
                    queue.append(c)
        return None

    @staticmethod
    def ids(prb: Problem) -> Solution:
        i = 1
        while True:
            res = Search.__dfs_with_limit(prb, i)
            if res is not None:
                return res
            i += 1
        return None

    @staticmethod
    def ucs(prb: Problem) -> Solution:
        start_time = datetime.now()
        queue = PriorityQueue()
        state = prb.initState
        queue.put([state.g_n, state])
        while not queue.empty():
            state = queue.get()[1]
            neighbors = prb.successor(state)
            for c in neighbors:
                if prb.goal_test(c):
                    return Solution(c, prb, start_time)
                queue.put([c.g_n, c])
        return None
    @staticmethod
    def gbfs(prb: Problem) -> Solution:
        # Greedy Best-First Search
        start_time = datetime.datetime.now()
        queue = PriorityQueue()
        state = prb.initState
        queue.put((state.h_n(), state))
        
        while not queue.empty():
            state = queue.get()[1]
            neighbors = prb.successor(state)
            for c in neighbors:
                if prb.goal_test(c):
                    return Solution(c, prb, start_time)
                queue.put((c.h_n(), c))
        
        return None

    @staticmethod
    def aStar(prb: Problem) -> Solution:
        # A* Search
        start_time = datetime.datetime.now()
        queue = PriorityQueue()
        state = prb.initState
        queue.put((state.f_n(), state))
        
        while not queue.empty():
            state = queue.get()[1]
            neighbors = prb.successor(state)
            for c in neighbors:
                if prb.goal_test(c):
                    return Solution(c, prb, start_time)
                queue.put((c.f_n(), c))
        
        return None

    @staticmethod
    def limit_astar(prb: Problem, cutoff: int) -> Solution:
        # A* with cutoff
        start_time = datetime.datetime.now()
        queue = PriorityQueue()
        state = prb.initState
        non = PriorityQueue()
        queue.put((state.f_n(), state))
        
        while not queue.empty():
            state = queue.get()[1]
            if state.f_n() <= cutoff:
                neighbors = prb.successor(state)
                for c in neighbors:
                    if prb.goal_test(c):
                        return Solution(c, prb, start_time)
                    queue.put((c.f_n(), c))
            else:
                non.put((c.f_n(), c))
        
        return non.get()[0]

    @staticmethod
    def idaStar(prb: Problem) -> Solution:
        # Iterative Deepening A*
        limit = prb.initState.f_n()
        while True:
            res = Search.limit_astar(prb, limit)
            if isinstance(res, Solution):
                return res
            limit = res